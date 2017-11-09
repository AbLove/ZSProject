using NewProject.ConsoleData.Model.MS;
using NewProject.ConsoleData.Model.MY;
using System.Data.Entity;

namespace NewProject.ConsoleData.Model
{
  
    public class MSsqlDb : DbContext
    {
        public MSsqlDb() : base("MssqlDefault")
        {
            //Database.SetInitializer<Db>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<School> Schools { get; set; }

    }

    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MysqlDb : DbContext
    {
        public MysqlDb() : base("MysqlDefault")
        {
            //Database.SetInitializer<Db>(null);
        }
        public DbSet<base_teacher> b_teas { get; set; }
        public DbSet<base_student> b_stus { get; set; }
        public DbSet<base_school> b_schs { get; set; }
        public DbSet<base_class> b_cls { get; set; }

    }

}