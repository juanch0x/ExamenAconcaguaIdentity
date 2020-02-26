using ExamenAconcagua.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExamenAconcagua.Services
{
    public interface IRepository<T> where T: IEntity
    {
        /// <summary>
        /// Get object by id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T Get(long Id);
        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Get the single matching record or null.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T SingleOrDefault(Expression<Func<T,bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);

    }
}
