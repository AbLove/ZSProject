using System.Linq;
using NewProject.Data.Model;

namespace NewProject.Data.Repository
{
    public interface IUniRepo
    {
        T Insert<T>(T o) where T : Entity, new();

        void Save();

        T Get<T>(int id) where T : Entity;

        IQueryable<T> GetAll<T>(bool showDeleted) where T : DelEntity;
    }
}