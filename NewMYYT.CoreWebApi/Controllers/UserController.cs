using Microsoft.AspNetCore.Mvc;
using NewMYYT.Core.Model;
using NewMYYT.Core.Service;
using NewMYYT.CoreWebApi.ViewModels.Input;
using System.Linq;

namespace NewMYYT.CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Crudere<User, UserCreateInput, UserEditInput>
    {
        //private new readonly IUserService service;

        public UserController(ICrudService<User> service) : base(service)
        {
        }

        //[HttpPost]
        //public ActionResult ChangePassword(ChangePasswordInput input)
        //{
        //    service.ChangePassword(input.Id, input.Password);
        //    return Json(new { Login = service.Get(input.Id).Login });
        //}
        [HttpGet]
        public dynamic Get()
        {
            return service.GetAll();
        }
    }
}