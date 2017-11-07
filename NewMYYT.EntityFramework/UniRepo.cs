using Microsoft.EntityFrameworkCore;
using NewMYYT.Core.Model;
using NewMYYT.Core.Repository;
using System.Linq;

namespace NewMYYT.EntityFramework
{
    public class UniRepo : IUniRepo
    {
        private readonly Db c;

        //public UniRepo(IDbContextFactory a)
        //{
        //    c = a.GetContext();
        //}
        public UniRepo()
        {
            c = new Db();
        }

        public T Insert<T>(T o) where T : Entity, new()
        {
            //var t = new T();
            //t.InjectFrom(o);
            c.Set<T>().Add(o);
            return o;
        }

        public void Save()
        {
            c.SaveChanges();
        }

        public T Get<T>(int id) where T : Entity
        {
            return c.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll<T>(bool showDeleted) where T : DelEntity
        {
            if (showDeleted)
            {
                return c.Set<T>();
            }

            return c.Set<T>().Where(o => !o.IsDeleted);
        }
    }
}