using NewProject.Common;
using NewProject.Data.Model;
using NewProject.Data.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NewProject.EntityFramework
{
    public class Repo<T> : IRepo<T> where T : Entity, new()
    {
        protected readonly DbContext dbContext;
        private DbSet<T> table = null;
        protected DbSet<T> Table
        {
            get
            {
                return this.table;
            }
        }

        public Repo(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.table = dbContext.Set<T>();
        }
        public Repo(IDbContextFactory f)
        {
            dbContext = f.GetContext();
            this.table = dbContext.Set<T>();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
        
        public T Insert(T o)
        {
            var t = table.Create();
            //t.InjectFrom(o);
            this.table.Add(t);
            return t;
        }
       
        public virtual void Delete(T o)
        {
            if (o is IDel)
                (o as IDel).IsDeleted = true;
            else
                this.table.Remove(o);
        }

        public T Get(int id)
        {
            var entity = this.table.Find(id);
            if (entity == null) throw new Exception("this entity doesn't exist anymore");
            return entity;
        }

        public void Restore(T o)
        {
            if (o is IDel)
                IoC.Resolve<IDelRepo<T>>().Restore(o);
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            if (typeof(IDel).IsAssignableFrom(typeof(T)))
                return IoC.Resolve<IDelRepo<T>>().Where(predicate, showDeleted);
            return dbContext.Set<T>().Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            if (typeof(IDel).IsAssignableFrom(typeof(T)))
                return IoC.Resolve<IDelRepo<T>>().GetAll();
            return dbContext.Set<T>();
        }
    }
}