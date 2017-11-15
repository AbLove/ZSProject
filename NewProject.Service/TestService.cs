using NewProject.Common;
using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.Data.Repository;
using System.Collections.Generic;

namespace NewProject.Service
{
    public class TestService<T> : ITestService<T> where T : Entity,new ()
    {
        //private readonly IRepo<T> _IRepo;
        //public TestService(IRepo<T> _IRepo)
        //{
        //    this._IRepo = _IRepo;
        //}
        public IEnumerable<T> Get()
        {
            return IoC.Resolve<IRepo<T>>().Where(t => true);
            if (typeof(T) == typeof(string))
            {
                return new List<string> { "1", "2", "3", "4", "5" } as List<T>;
            }
            else if (typeof(T) == typeof(Users))
            {
                return new List<Users> { new Users { Id = 1, Name = "guest", IsDeleted = false }, new Users { Id = 1, Name = "admin", IsDeleted = false } } as List<T>;
            }
            else
            {
                return new List<base_school> { new base_school { school_id = 1, school_name = "guest", city = "111" }, new base_school { school_id = 2, school_name = "guest", city = "222" } } as List<T>;
            }
        }
    }
}
