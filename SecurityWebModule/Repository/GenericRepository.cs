﻿using SecurityWebModule.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SecurityWebModule.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        SecurityDBEntities context = null;
        
        private IDbSet<T> entities = null;
        public GenericRepository(SecurityDBEntities context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetbyID(int id)
        {
            return entities.Find(id);
        }
        public void Create(T objRecord)
        {
            entities.Add(objRecord);
            context.SaveChanges();
        }

        public void Update(T objRecord)
        {
            entities.Attach(objRecord);
            context.Entry(objRecord).State = EntityState.Modified;
        }
        public void Delete(T objRecord)
        {
            context.Entry(objRecord).State=EntityState.Deleted;
            context.SaveChanges();
        }

      
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}