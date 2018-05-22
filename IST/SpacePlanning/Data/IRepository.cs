using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data
{
    /// <summary>
    /// Allow decouple repositories from real implementations.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Entity class that corresponds to a table in the database.
    /// </typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(params Guid[] entityId);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}