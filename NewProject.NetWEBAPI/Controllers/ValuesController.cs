using NewProject.Data.IService;
using NewProject.Data.Model;
using System.Web.Http;

namespace NewProject.NetWEBAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        private readonly IUserService _Service;


        public ValuesController(IUserService _Service)
        {
            this._Service = _Service;
        }

        public dynamic Get()
        {
            return Json(new { v1 = "value1", v2 = "value2", users = _Service.GetAll() });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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
