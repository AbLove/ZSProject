using NewProject.Data.IService;
using NewProject.Data.Model;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace NewProject.NetWEBAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        // private readonly IUserService _Service;
        //private readonly ICrudService<NUser> _Service;
        private readonly ITestService<Users> _Service;
        private readonly ITestService<base_school> _cService;




        public ValuesController(ITestService<Users> _Service, ITestService<base_school> _cService)
        {
            this._Service = _Service;
            this._cService = _cService;
        }

        public dynamic Get()
        {
            return Json(new { v1 = "value1", v2 = "value2", users = _Service.Get(), scs = _cService.Get() });
        }

        // GET api/values/5
        public string Get(int id, HttpActionContext sa)
        {
            var ss = Request;
            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context
            HttpRequestBase request = context.Request;//定义传统request对象
            context.Cache["11"] = 11;
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
