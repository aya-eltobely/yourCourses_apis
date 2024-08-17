using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YourCourses.Data.Helpers;
using YourCourses.Data.Models;
using YourCourses.Infrastructure.Interfaces;
using YourCourses.Infrastructure.Repositories;
using YourCourses.Services.DTOs;
using YourCourses.Services.Interfaces;

namespace YourCourses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;

        public AccountController(UserManager<ApplicationUser> _userManager,
            IConfiguration _configuration,
            IUserService _userService,
            IUnitOfWork _unitOfWork)
        {
            userManager = _userManager;
            configuration = _configuration;
            userService = _userService;
            unitOfWork = _unitOfWork;
        }


        [HttpPost("register")] //api/account/register
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userDTO)
        {

            if (ModelState.IsValid)
            {

                using var transaction =  unitOfWork.BeginTransaction();


                try
                {

                    var userInSite = userService.GetUserByEmail(userDTO.Email);

                    if (userInSite != null)
                    {
                        return BadRequest("Not Allowed");
                    }

                    ApplicationUser user = new ApplicationUser()
                    {
                        UserName = userDTO.UserName,
                        Email = userDTO.Email,
                        firstName = userDTO.FirstName,
                        lastName = userDTO.LastName,
                        PhoneNumber = userDTO.PhoneNumber
                    };
                    IdentityResult res = await userManager.CreateAsync(user, userDTO.Password);
                    //asign role to user
                    if (userDTO.UserType == "Teacher")
                    {
                        userManager.AddToRoleAsync(user, WebSiteRoles.SiteTeacher).GetAwaiter().GetResult();
                        user.isActivate = 0;
                        Teacher teacher = new Teacher() { AppUserId = user.Id };
                        unitOfWork.Teacher.Create(teacher);
                    }
                    if (userDTO.UserType == "Student")
                    {
                        userManager.AddToRoleAsync(user, WebSiteRoles.SiteStudent).GetAwaiter().GetResult();
                        user.isActivate = 1;
                        Student student = new Student() { AppUserId = user.Id };
                        unitOfWork.Student.Create(student);
                    }


                    unitOfWork.Save();
                    transaction.Commit();
                    return Ok(new { message = "account created" });

                }
                catch (Exception)
                {

                    transaction.Rollback();
                    return BadRequest("Something Wrong");
                }
            }
            return BadRequest(ModelState);
        }



        [HttpPost("login")] //api/account/login
        public async Task<IActionResult> LogIn([FromBody] LoginUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                //check username
                ApplicationUser user = await userManager.FindByNameAsync(userDTO.UserName);
                if (user != null)
                {
                    //check pass
                    bool res = await userManager.CheckPasswordAsync(user, userDTO.Password);
                    if (res)
                    {

                        // Update LastLoginTime
                        user.LastLoginTime = DateTime.UtcNow;
                        await userManager.UpdateAsync(user);

                        //(2)
                        var Allclaims = new List<Claim>();
                        Allclaims.Add(new Claim(ClaimTypes.Name, user.UserName)); //custom claim


                        if (await userManager.IsInRoleAsync(user, WebSiteRoles.SiteAdmin))
                        {
                            Allclaims.Add(new Claim(ClaimTypes.Role, WebSiteRoles.SiteAdmin));
                        }
                        else if (await userManager.IsInRoleAsync(user, WebSiteRoles.SiteTeacher))
                        {
                            Allclaims.Add(new Claim(ClaimTypes.Role, WebSiteRoles.SiteTeacher));
                        }
                        else if (await userManager.IsInRoleAsync(user, WebSiteRoles.SiteStudent))
                        {
                            Allclaims.Add(new Claim(ClaimTypes.Role, WebSiteRoles.SiteStudent));
                        }

                        Allclaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id)); //custom claim
                        Allclaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); //predifne claims ==> token id

                        //(3)
                        SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:secretKey"]));
                        SigningCredentials signingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        //create token (1)
                        JwtSecurityToken myToken = new JwtSecurityToken(
                            issuer: configuration["JWT:issuer"], // web api server url
                            audience: configuration["JWT:audiance"], //angular url
                            claims: Allclaims,
                            expires: DateTime.Now.AddDays(2),
                            signingCredentials: signingCredential
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(myToken),
                            expiration = myToken.ValidTo,
                            isActivate= user.isActivate
                        }
                            );
                    }
                    else
                    {
                        return Unauthorized("Password Wrong");
                    }
                }
                else
                {
                    return Unauthorized("User Name not Found");
                }
            }
            else
            {
                //return Unauthorized();
                return BadRequest(ModelState);
            }
        }



    }
}
