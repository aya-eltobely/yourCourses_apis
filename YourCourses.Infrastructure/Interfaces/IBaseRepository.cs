using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YourCourses.Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        //IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        //IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        //IEnumerable<T> GetAll(string includeProperties = "");

        //IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
        //   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //   string includeProperties = ""
        //   );


        public T Create(T entity);
        public List<T> CreateRange(List<T> entity);

        public bool Delete(T entity);
        public bool Update(T entity);
        public T GetById(int id);
    }
}
