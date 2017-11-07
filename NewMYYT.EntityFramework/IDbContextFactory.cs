using Microsoft.EntityFrameworkCore;

namespace NewMYYT.EntityFramework
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}