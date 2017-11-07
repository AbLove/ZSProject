using Microsoft.AspNetCore.Mvc;
using NewMYYT.Core.Model;
using NewMYYT.Core.Repository;
using NewMYYT.Core.Service;
using NewMYYT.CoreWebApi.ViewModels.Input;
using System.Linq;

namespace NewMYYT.CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController :Controller
    {
        //private readonly IUserService Service;

        //public AccountController(IUserService Service)
        //{
        //    this.Service = Service;
        //}
        //private readonly ICrudService<User> Service;
        //public AccountController(ICrudService<User> Service) : base(Service)
        //{
        //    // this.Service = Service;
        //}
        private readonly ITestService Service;
        public AccountController(ITestService Service)
        {
            this.Service = Service;
        }

        //[HttpPost]
        //public bool SignIn(SignInInput input)
        //{

        //    User user = new NewMYYT.Core.Model.User { Login = "o", Password = "1" };

        //    if (input.Login == "o" && input.Password == "1")
        //    {
        //        user = new User { Login = "o", Roles = new[] { new Role { Name = "admin" } } };
        //    }
        //    else
        //    {
        //        user = userService.Get(input.Login, input.Password);
        //    }
        //    return true;
        //}
        [HttpGet]
        public dynamic Get()
        {
            //var m = service.GetAll();
            //return new[] { '1', 2, 3, 4 };
            return Service.Get();
        }
    }
}