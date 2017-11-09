using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.Data.Model.MS;
using System.Collections.Generic;
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
            var schs = new List<User>();

            //var mlist = DataMigrations.GetMysqlSchool();
            //foreach (var item in mlist)
            //{
            //    schs.Add(new School { ID = item.school_id, Name = item.school_name, Type = item.type, Address = item.address, Tel = item.phone_number, Descp = item.description, Proviance = item.province, City = item.city, Area = item.county });
            //}
            //DataMigrations.AddMssqlSchool(schs);

            //var mlist = DataMigrations.GetMysqlCls();
            //foreach (var item in mlist)
            //{
            //    schs.Add(new Class { ClassID = item.class_id, ClassName = item.class_name, SchoolID = item.school_id, State = 1, Grade = "2017" });
            //}
            //DataMigrations.AddMssqlCls(schs);

            //var mlist = DataMigrations.GetMysqlStu();
            //foreach (var item in mlist)
            //{
            //    schs.Add(new Student { StudentID = item.student_id, Name = item.student_name, ClassID = item.class_id, Address = item.address, Birthday = System.DateTime.Parse(item.birthday), Phone = item.father_phone });
            //}
            //DataMigrations.AddMssqlStu(schs);

            //var mlist = DataMigrations.GetMysqlTeacher();
            //var i = 0;
            //foreach (var item in mlist)
            //{

            //    schs.Add(new User { UserID = System.Guid.NewGuid(), Name = "mysqlteachar" + (i++), ClassID = item.class_id, CreateDate = System.DateTime.Now, RoleID = 5, Password = "MTExMTEx", NickName = item.teacher_name, SchoolID = item.school_id, District = item.address });
            //}
            //DataMigrations.AddMssqlTeacher(schs);

            var s = _Service.GetAll();
            ViewBag.Title = "Home Page";
            return View();
        }
        public ActionResult List()
        {
            var s = _Service.GetAll();
            return View(s);
        }
        public ActionResult ProList() {
            var p = _pService.GetAll();
            return View(p);
        }
    }
}
