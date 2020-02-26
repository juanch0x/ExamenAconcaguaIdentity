using ExamenAconcagua.Models;
using ExamenAconcagua.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamenAconcagua.Services
{
    public class EntityRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;
        public EntityRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual T Get(long Id)
        {
            return DbSet.Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
