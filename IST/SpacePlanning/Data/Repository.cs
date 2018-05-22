using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IST.SpacePlanning.Data
{
    /// <summary>
    /// Generic implementation of the repository pattern
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields...
        readonly ISTSpacePlanningContext _dbContext;
        readonly DbSet<TEntity> _dbSet;
        #endregion

        #region Constructors...
        public Repository(ISTSpacePlanningContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        #endregion

        #region Methods...
        /// <summary>
        /// Searchs and return an entity in the database.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public TEntity GetById(params Guid[] entityId)
        {
            if (entityId.Count() == 1)
            {
                return (TEntity)_dbContext.Find<TEntity>(entityId[0]);
            }
            else if (entityId.Count() == 2)
            {
                return (TEntity)_dbContext.Find<TEntity>(entityId[0], entityId[1]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Searchs and prepare to return all the entities of a repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll() => _dbSet.ToList();

        /// <summary>
        /// Adds entity to the repository (does not commit). The UnitOfWork to which the repositories belong is responsible for making the commit in the database.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Updates entity in the repository (does not commit). The UnitOfWork to which the repositories belong is responsible for making the commit in the database.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            if (_dbContext.Entry<TEntity>(entity).State == EntityState.Detached)
                _dbContext.Attach(entity);
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes entity from the repository (does not commit). The UnitOfWork to which the repositories belong is responsible for making the commit in the database.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            if (_dbContext.Entry<TEntity>(entity).State == EntityState.Detached)
                _dbContext.Attach(entity);
            _dbSet.Remove(entity);
        }
        #endregion
    }
}
