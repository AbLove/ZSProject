using NewProject.Data.Model;

namespace NewProject.Data.IService
{
    public interface IUserService : ICrudService<Users>
    {
        bool IsUnique(string login);

        void ChangePassword(int id, string password);

        Users Get(string login, string password);
    }
}