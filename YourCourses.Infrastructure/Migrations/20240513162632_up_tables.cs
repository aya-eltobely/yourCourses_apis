using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourCourses.Infrastructure.Migrations
{
    public partial class up_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Videos",
                newName: "Name_en");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Videos",
                newName: "Name_ar");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SubCategories",
                newName: "Name_en");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "Name_en");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Courses",
                newName: "Name_ar");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Name_en");

            migrationBuilder.AddColumn<string>(
                name: "Description_ar",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_en",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "isActivate",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name_ar",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_ar",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_en",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_ar",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_ar",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Description_en",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "isActivate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name_ar",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "Description_ar",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Description_en",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Name_ar",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Name_en",
                table: "Videos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_ar",
                table: "Videos",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name_en",
                table: "SubCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_en",
                table: "Courses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_ar",
                table: "Courses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name_en",
                table: "Categories",
                newName: "Name");
        }
    }
}
