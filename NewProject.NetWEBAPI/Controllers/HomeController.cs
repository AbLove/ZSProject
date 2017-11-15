using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.NetWEBAPI.Utils;
using System;
using System.Web.Mvc;

namespace NewProject.NetWEBAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICrudService<Users> _Service;
        private readonly ICrudService<Projects> _pService;

        public HomeController(ICrudService<Users> _Service, ICrudService<Projects> _pService)
        {
            this._Service = _Service;
            this._pService = _pService;
        }

        public ActionResult Index()
        {
          
            var s = _Service.GetAll();
            ViewBag.Title = "Home Page";
            return View();
        }
        public ActionResult List()
        {
            try
            {
                var ss = Convert.ToInt16("asd");
            }
            catch (System.Exception ex)
            {
                ex.Log();
                //throw;
            }
            var s = _Service.GetAll();
            return View(s);
        }
        public ActionResult ProList() {
            var p = _pService.GetAll();
            return View(p);
        }
    }
}
