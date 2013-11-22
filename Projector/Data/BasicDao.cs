using Projector.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projector.Data {
    public class BasicDao : IDisposable{
        public ProjectorDatabaseEntities db;

        public BasicDao() {
            db = new ProjectorDatabaseEntities();
        }

        public T Insert<T>(T item) where T : class {
            db.Set<T>().Add(item);
            db.Entry(item).State = EntityState.Added;
            db.SaveChanges();
            return item;
        }

        public void Update<T>(T item) where T : class {
            db.Set<T>().Attach(item);
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete<T>(int id) where T : class {
            var item = db.Set<T>().Find(id);

            db.Set<T>().Remove(item);
            db.SaveChanges();
        }

        public T Get<T>(int id) where T : class { 
            return db.Set<T>().Find(id) as T;
        }

        public ICollection<T> GetAll<T>() where T : class {

            return db.Set<T>().ToList<T>();

        }

        public void Dispose() {
            db.Dispose();
            db = null;
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BasicDao() {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                if (db != null) {
                    db.Dispose();
                    db = null;
                }
            }
        }
    }
}