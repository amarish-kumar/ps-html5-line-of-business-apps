using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodedHomes.Data
{
    /// <summary>
    /// interface for all the repos, only apply to classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Detach(T entity);
    }
}
