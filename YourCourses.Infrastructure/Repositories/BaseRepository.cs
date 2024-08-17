using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourCourses.Infrastructure.Context;
using YourCourses.Infrastructure.Interfaces;

namespace YourCourses.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public ApplicationDBContext Context;
        public DbSet<T> Set;

        public BaseRepository(ApplicationDBContext context)
        {
            Context = context;
            Set = Context.Set<T>();
        }


        public IQueryable<T> GetAll()
        {
            return Set;
        }

        public T GetById(int id)
        {
            return Set.Find(id);
        }


        public T Create(T entity)
        {
            Set.Add(entity);
            return Context.SaveChanges() > 0 ? entity : null;
        }

        public List<T> CreateRange(List<T> entity)
        {
            Set.AddRange(entity);
            return Context.SaveChanges() > 0 ? entity : null;
        }

        public bool Delete(T entity)
        {
            Set.Remove(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            Set.Update(entity);
            return Context.SaveChanges() > 0;
        }

    }
}
