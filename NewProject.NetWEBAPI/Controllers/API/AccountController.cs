using NewProject.Common;
using NewProject.Data.IService;
using NewProject.Data.Model;
using System;
using System.Security.Cryptography;
using System.Web.Http;

namespace NewProject.NetWEBAPI.Controllers.API
{
    public class AccountController : ApiController
    {
        private IAuthenticationService _authenticationService => IoC.Resolve<IAuthenticationService>();
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost]
        public IHttpActionResult Login(dynamic model)
        {
            var user = userService.Get(model.Login, model.Pwd);
            if (model.Login == "1234" && model.Pwd == "1234")
            {
                //返回token给前台
                return Ok(new { Msg = "登陆成功", SessionKey = GenericTokenAndUpdate(user, 1) });
            }

            else
            {
                return BadRequest("账号或密码有误!");
            }
        }
        private string GenericTokenAndUpdate(Users user, int deviceType)
        {
            UserDevice existsDevice = _authenticationService.GetUserDevice(user.Id);
            int timeout = 60;
            if (existsDevice == null)
            {
                var passkey = MD5.Create(user.Login + DateTime.Now + Guid.NewGuid());
                existsDevice = new UserDevice()
                {
                    UserId = user.Id,
                    CreateTime = DateTime.Now,
                    ActiveTime = DateTime.Now,
                    ExpiredTime = DateTime.Now.AddMinutes(timeout),
                    DeviceType = deviceType,
                    SessionKey = passkey.ToString()
                };
                _authenticationService.AddUserDevice(existsDevice);
            }
            else
            {
                existsDevice.ActiveTime = DateTime.Now;
                existsDevice.ExpiredTime = DateTime.Now.AddMinutes(timeout);
                _authenticationService.UpdateUserDevice(existsDevice);
            }
            return existsDevice.SessionKey;
        }
    }
}
