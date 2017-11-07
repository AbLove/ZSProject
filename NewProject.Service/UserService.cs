using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.Data.Repository;
using Omu.Encrypto;
using System.Linq;

namespace NewProject.Service
{
    public class UserService : CrudService<NUser>, IUserService
    {
        private readonly IHasher hasher;

        public UserService(IRepo<NUser> repo, IHasher hasher)
            : base(repo)
        {
            this.hasher = hasher;
            hasher.SaltSize = 10;
        }

        public override int Create(NUser user)
        {
            user.Password = hasher.Encrypt(user.Password);
            return base.Create(user);
        }

        public bool IsUnique(string login)
        {
            return !repo.Where(o => o.Login == login, true).Any();
        }

        public NUser Get(string login, string password)
        {
            var user = repo.Where(o => o.Login == login && o.IsDeleted == false).FirstOrDefault();
            if (user == null || !hasher.CompareStringToHash(password, user.Password)) return null;
            return user;
        }

        public void ChangePassword(int id, string password)
        {
            repo.Get(id).Password = hasher.Encrypt(password);
            repo.Save();
        }
    }
}