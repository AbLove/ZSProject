using Newtonsoft.Json;
using System.Web.Http;

namespace NewProject.NetWEBAPI.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        [AllowAnonymous]
        public dynamic Get()
        {
            var str = JsonConvert.SerializeObject(new { v1 = "value1", v2 = "value2" });
            var obj = JsonConvert.DeserializeObject(str);
            return Json(new { v1 = "value1", v2 = "value2" });
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
