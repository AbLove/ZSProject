using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.NetWEBAPI.Controllers.API;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NewProject.NetWEBAPI.Controllers
{
    public class ValuesController : BaseApiController
    {
        // GET api/values

        private readonly IUserService _uService;
        private readonly ICrudService<Users> _Service;
        public ValuesController(ICrudService<Users> _Service, IUserService _uService)
        {
            this._Service = _Service;
            this._uService = _uService;
        }
        public dynamic Get()
        {
            //var users = IoC.Resolve<IRepo<Users>>().Where(t => true).ToList().Take(10);
            var users = _Service.Get(10);
            var u = _uService.GetAll().Take(10).ToList();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            return Json(new { v1 = "value1", v2 = "value2", users = JsonConvert.SerializeObject(users, settings), user = JsonConvert.SerializeObject(u, settings) });
        }

        // GET api/values/5
        public string Get(int id)
        {
            var ss = Request;
            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
            HttpRequestBase request = context.Request;//定义传统request对象
            context.Cache["11"] = id;
            var s = request["id"];
            var sss = HttpContext.Current.Items;
            return "value" + context.Cache["11"];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
