using NewProject.Data.Model;
using NewProject.Data.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NewProject.EntityFramework
{
    public class DelRepo<T> : IDelRepo<T> where T : DelEntity
    {
        protected readonly DbContext dbContext;

        public DelRepo(IDbContextFactory dbContextFactory)
        {
            dbContext = dbContextFactory.GetContext();
        }
        public DelRepo(Db dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            var res = dbContext.Set<T>().Where(predicate);
            if (!showDeleted) res = res.Where(o => o.IsDeleted == false);
            return res;
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>().Where(o => o.IsDeleted == false);
        }

        public void Restore(T o)
        {
            o.IsDeleted = false;
        }
    }
}