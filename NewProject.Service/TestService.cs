using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.Data.Repository;
using NewProject.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace NewProject.Service
{
    public class TestService : ITestService
    {
        private readonly IRepo<NUser> _IRepo;
        public TestService(IRepo<NUser> _IRepo)
        {
            this._IRepo = _IRepo;
        }
        public List<NUser> Get()
        {
            return this._IRepo.Where(t => true).ToList();
            //return new List<string> { "1", "2", "3", "4", "5" };
        }
    }
}
