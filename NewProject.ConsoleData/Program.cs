using Model;
using NewProject.ConsoleData.Model;
using NewProject.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewProject.ConsoleData
{
    class Program
    {
        private static readonly MSsql db = new MSsql();
        private static readonly MysqlDb mydb = new MysqlDb();

        static void Main(string[] args)
        {
            Console.WriteLine("正在执行操作....");
            var schs = new List<Model.School>();
            //schs = GetList();
            foreach (var item in GetMysqlSchool())
            {
                schs.Add(new Model.School { ID = Convert.ToInt32(item.school_id), Name = item.school_name, Type = item.type, Address = item.address, Tel = item.phone_number, Descp = item.description, Proviance = item.province, City = item.city, Area = item.county });
            }
            //AddMssqlSchool(schs);
            Console.WriteLine("操作已完成");
            Console.ReadKey();
        }

        #region 查询mysql数据

        static List<base_teacher> GetMysqlTeacher()
        {
            return mydb.b_teas.Where(t => true).ToList();
        }
        static List<base_student> GetMysqlStu()
        {
            return mydb.b_stus.Where(t => true).ToList();
        }
        static List<base_school> GetMysqlSchool()
        {
            return mydb.b_schs.Where(t => true).ToList();
        }
        static List<base_class> GetMysqlCls()
        {
            return mydb.b_cls.Where(t => true).ToList();
        }
        #endregion

        #region 同步到mssql
        static List<Model.School> GetList()
        {
            return db.School.ToList();
        }

        static void AddMssqlTeacher(List<Model.User> users)
        {
            db.User.AddRange(users);
            db.SaveChanges();
        }
        static void AddMssqlStu(List<Model.Student> stus)
        {
            db.Student.AddRange(stus);
            db.SaveChanges();
        }
        static void AddMssqlSchool(List<Model.School> schs)
        {
            using (var scope = db.Database.BeginTransaction())
            {
                try
                {
                    db.School.AddRange(schs);
                    db.SaveChanges();
                    scope.Commit();
                }
                catch (Exception)
                {
                    scope.Rollback();
                    throw;
                }
            }

        }
        static void AddMssqlCls(List<Model.Class> cls)
        {
            db.Class.AddRange(cls);
            db.SaveChanges();
        }
        #endregion
    }
}
