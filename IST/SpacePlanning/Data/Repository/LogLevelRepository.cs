using IST.SpacePlanning.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IST.SpacePlanning.Data.Repository
{
    public class LogLevelRepository
    {
        private DbSet<LogLevel> _dbSetLogLevel;
        readonly ISTSpacePlanningContext _dbContext;

        public LogLevelRepository(ISTSpacePlanningContext dbContext)
        {
            _dbContext = dbContext;
            _dbSetLogLevel = _dbContext.Set<LogLevel>();
        }

        /// <summary>
        /// Gets the LogLevel by identifier
        /// </summary>
        /// <param name="id">log level identifier</param>
        /// <returns></returns>
        public LogLevel GetById(long id)
        {
            return _dbSetLogLevel.Find(id);
        }

        /// <summary>
        /// Adds new logLevel into Log_Level Table
        /// </summary>
        /// <param name="newLogLevel">new log level row</param>
        public void Add(LogLevel newLogLevel)
        {
            _dbSetLogLevel.Add(newLogLevel);
        }

        /// <summary>
        /// Updates log level 
        /// </summary>
        /// <param name="updateLogLevel">log level instance to update</param>
        public void Update(LogLevel updateLogLevel)
        {
            if (_dbContext.Entry<LogLevel>(updateLogLevel).State == EntityState.Detached)
                _dbContext.Attach(updateLogLevel);
            _dbContext.Entry<LogLevel>(updateLogLevel).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes log level from LogLevel table
        /// </summary>
        /// <param name="logDeleted"></param>
        public void Delete(LogLevel logDeleted)
        {
            if (_dbContext.Entry<LogLevel>(logDeleted).State == EntityState.Detached)
                _dbContext.Attach(logDeleted);
            _dbContext.Remove(logDeleted);
        }
    }
}
