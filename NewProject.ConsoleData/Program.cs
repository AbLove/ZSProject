using NewProject.ConsoleData.Model;
using NewProject.ConsoleData.Model.MS;
using NewProject.ConsoleData.Model.MY;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewProject.ConsoleData
{
    class Program
    {
        private static readonly MSsqlDb db = new MSsqlDb();
        private static readonly MysqlDb mydb = new MysqlDb();

        static void Main(string[] args)
        {
            Console.WriteLine("正在执行操作....");
            var schs = new List<School>();
            var mlist = GetMysqlSchool();
            //AddMssqlSchool(schs);
            var s = GetList();
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
        static List<School> GetList()
        {
            return db.Schools.ToList();
        }

        static void AddMssqlTeacher(List<User> users)
        {
            using (var scope = db.Database.BeginTransaction())
            {
                try
                {
                    db.Users.AddRange(users);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    scope.Rollback();
                    throw;
                }
            }
        }
        static void AddMssqlStu(List<Student> stus)
        {
            using (var scope = db.Database.BeginTransaction())
            {
                try
                {
                    db.Students.AddRange(stus);
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
        static void AddMssqlSchool(List<School> schs)
        {
            using (var scope = db.Database.BeginTransaction())
            {
                try
                {
                    db.Schools.AddRange(schs);
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
        static void AddMssqlCls(List<Class> cls)
        {
            using (var scope = db.Database.BeginTransaction())
            {
                try
                {
                    db.Classes.AddRange(cls);
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
        #endregion
    }
}
