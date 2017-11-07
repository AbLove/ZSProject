using NewProject.Data.IService;
using System.Web.Mvc;

namespace NewProject.NetWEBAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _Service;

        public HomeController(IUserService _Service) {
            this._Service = _Service;
        }
        public ActionResult Index()
        {
            
            ViewBag.Title = "Home Page";
            return View();
        }
        public ActionResult List()
        {

            ViewBag.Title = "Home Page";
            return View(_Service.GetAll());
        }
    }
}
