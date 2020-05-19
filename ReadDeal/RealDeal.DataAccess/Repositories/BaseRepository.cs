﻿using System;
using System.Collections.Generic;
using System.Linq;
using RealDeal.AppLogic.Abstractions;

namespace RealDeal.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        protected readonly DataAccessDbContext dbContext;
        public BaseRepository(DataAccessDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Get( int id)
        {
            return dbContext.Find<T>(id);
        }

        public T Add(T itemToAdd)
        {
            var entity = dbContext.Add<T>(itemToAdd);
            dbContext.SaveChanges();
            return entity.Entity;
        }

        public bool Delete(T itemToDelete)
        {
            dbContext.Remove<T>(itemToDelete);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>()
                            .AsEnumerable();
        }

        public T Update(T itemToUpdate)
        {
            var entity = dbContext.Update<T>(itemToUpdate);
            dbContext.SaveChanges();
            return entity.Entity;
        }

        //public T Get(T itemToFind)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
