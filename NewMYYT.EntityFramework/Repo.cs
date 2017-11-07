using Microsoft.EntityFrameworkCore;
using NewMYYT.Core;
using NewMYYT.Core.Model;
using NewMYYT.Core.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NewMYYT.EntityFramework
{
    public class Repo<T> : IRepo<T> where T : Entity
    {
        protected readonly Db dbContext;
        //protected readonly IDelRepo<T> idelrepo;

        private DbSet<T> table = null;
        protected DbSet<T> Table
        {
            get
            {
                return this.table;
            }
        }

        public Repo(Db dbContext)
        {
            this.dbContext = dbContext;
            this.table = dbContext.Set<T>();
        }
        //public Repo(IDelRepo<T> idelrepo)
        //{
        //    this.dbContext = new Db();
        //    this.table = dbContext.Set<T>();
        //    this.idelrepo = idelrepo;
        //}
        //public Repo(IDbContextFactory f, IDelRepo<T> idelrepo)
        //{
        //    dbContext = f.GetContext();
        //    this.table = dbContext.Set<T>();
        //    this.idelrepo = idelrepo;
        //}

        public void Save()
        {
            dbContext.SaveChanges();
        }
        
        public T Insert(T o)
        {
            //var t = dbContext.Set<T>().Add();
            //t.InjectFrom(o);
            this.table.Add(o);
            return o;
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
            if (entity == null) throw new MYYTException("this entity doesn't exist anymore");
            return entity;
        }

        public void Restore(T o)
        {
            //if (o is IDel)
                //idelrepo.Restore(o);
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            //if (typeof(IDel).IsAssignableFrom(typeof(T)))
            //    return idelrepo.Where(predicate, showDeleted);
            return dbContext.Set<T>().Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            //if (typeof(IDel).IsAssignableFrom(typeof(T)))
            //    return idelrepo.GetAll();
            return dbContext.Set<T>();
        }
    }
}