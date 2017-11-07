
using System.Data.Entity;

namespace NewProject.EntityFramework
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}