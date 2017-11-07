using System.Linq;
using NewMYYT.Core.Model;

namespace NewMYYT.Core.Repository
{
    public interface IUniRepo
    {
        T Insert<T>(T o) where T : Entity, new();

        void Save();

        T Get<T>(int id) where T : Entity;

        IQueryable<T> GetAll<T>(bool showDeleted) where T : DelEntity;
    }
}