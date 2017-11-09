//using Model;
using NewProject.Data.Model;
using NewProject.Data.Model.MS;
using NewProject.EntityFramework;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NewProject.NetWEBAPI.Utils
{
    public class DataMigrations
    {
        private static readonly MSsqlDb db = new MSsqlDb();
        private static readonly MysqlDb mydb = new MysqlDb();
        #region 查询mysql数据

        public static List<base_teacher> GetMysqlTeacher()
        {
            return mydb.b_teas.Where(t => true).ToList();
        }
        public static List<base_student> GetMysqlStu()
        {
            return mydb.b_stus.Where(t => true).ToList();
        }
        public static List<base_school> GetMysqlSchool()
        {
            return mydb.b_schs.Where(t => true).ToList();
        }
        public static List<base_class> GetMysqlCls()
        {
            return mydb.b_cls.Where(t => true).ToList();
        }
        #endregion

        #region 同步到mssql
        public static List<School> GetList()
        {
            return db.Schools.ToList();
        }

        public static void AddMssqlTeacher(List<User> users)
        {
            using (var scope = db.Database.BeginTransaction())
            {
                try
                {
                    db.Users.AddRange(users);
                    db.SaveChanges();
                    scope.Commit();

                }
                catch (SqlException e)
                {
                    scope.Rollback();
                    throw;
                }
            }
        }
        public static void AddMssqlStu(List<Student> stus)
        {
            using (var scope = db.Database.BeginTransaction())
            {
                try
                {
                    db.Students.AddRange(stus);
                    db.SaveChanges();
                    scope.Commit();

                }
                catch (SqlException e)
                {
                    scope.Rollback();
                    throw;
                }
            }
        }
        public static void AddMssqlSchool(List<School> schs)
        {
            using (var scope = db.Database.BeginTransaction())
            {
                try
                {
                    db.Schools.AddRange(schs);
                    db.SaveChanges();

                    scope.Commit();
                }
                catch (SqlException e)
                {
                    scope.Rollback();
                    throw;
                }
            }

        }
        public static void AddMssqlCls(List<Class> cls)
        {
            using (var scope = db.Database.BeginTransaction())
            {
                try
                {
                    db.Classes.AddRange(cls);
                    db.SaveChanges();

                    scope.Commit();
                }
                catch (SqlException e)
                {
                    scope.Rollback();
                    throw;
                }
            }
        }
        #endregion
    }
}