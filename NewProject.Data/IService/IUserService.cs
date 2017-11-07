using NewProject.Data.Model;

namespace NewProject.Data.IService
{
    public interface IUserService : ICrudService<NUser>
    {
        bool IsUnique(string login);

        void ChangePassword(int id, string password);

        NUser Get(string login, string password);
    }
}