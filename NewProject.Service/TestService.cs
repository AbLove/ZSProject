using NewProject.Data.IService;
using NewProject.Data.Model;
using System.Collections.Generic;

namespace NewProject.Service
{
    public class TestService<T> : ITestService<T> where T : new()
    {
        //private readonly IRepo<NUser> _IRepo;
        //public TestService(IRepo<NUser> _IRepo)
        //{
        //    this._IRepo = _IRepo;
        //}
        public List<T> Get()
        {
            //return this._IRepo.Where(t => true).ToList();
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
