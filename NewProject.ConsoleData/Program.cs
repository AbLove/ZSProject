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

            //var mlist = GetMysqlSchool();
            //var schs = new List<School>();
            //foreach (var item in mlist)
            //{
            //    schs.Add(new School { ID = item.school_id, Name = item.school_name, Type = item.type, Address = item.address, Tel = item.phone_number, Descp = item.description, Proviance = item.province, City = item.city, Area = item.county });
            //}
            //AddMssqlSchool(schs);

            //var clalist = GetMysqlCls();
            //var clas = new List<Class>();
            //foreach (var item in clalist)
            //{
            //    clas.Add(new Class { ClassID = item.class_id, ClassName = item.class_name, SchoolID = item.school_id, State = 1, Grade = "2017" });
            //}
            //AddMssqlCls(clas);

            //var stulist = GetMysqlStu();
            //var stus = new List<Student>();
            //foreach (var item in stulist)
            //{
            //    stus.Add(new Student { StudentID = item.student_id, Name = item.student_name, ClassID = item.class_id, Address = item.address, Birthday = System.DateTime.Parse(item.birthday), Phone = item.father_phone });
            //}
            //AddMssqlStu(stus);

            //var tlist = GetMysqlTeacher();
            //var users = new List<User>();
            //var i = 0;
            //foreach (var item in tlist)
            //{

            //    users.Add(new User { UserID = System.Guid.NewGuid(), Name = "mysqlteachar" + (i++), ClassID = item.class_id, CreateDate = System.DateTime.Now, RoleID = 5, Password = "MTExMTEx", NickName = item.teacher_name, SchoolID = item.school_id, District = item.address });
            //}
            //AddMssqlTeacher(users);

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
