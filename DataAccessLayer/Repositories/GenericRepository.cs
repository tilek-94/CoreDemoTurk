using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using Context c = new();
            _ = c.Remove(entity);
            _ = c.SaveChanges();
        }

        public T GetById(int id)
        {
            using Context c = new();
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using Context c = new();
            return c.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            using Context c = new();
            _ = c.Add(entity);
            _ = c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using Context c = new();
            return c.Set<T>()
                .Where(filter)
                .ToList();
        }

        public void Update(T entity)
        {
            using Context c = new();
            _ = c.Update(entity);
            _ = c.SaveChanges();
        } 
    }
}
