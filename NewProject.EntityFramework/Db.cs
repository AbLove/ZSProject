using NewProject.Data.Model.MS;
using System.Data.Entity;

namespace NewProject.EntityFramework
{
    public class Db : DbContext
    {
        public Db() : base("MysqlDefault")
        {
            //Database.SetInitializer<Db>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<School> Schools { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasMany(r => r.Roles).WithMany(o => o.Users).Map(f =>
        //    {
        //        f.MapLeftKey("UserId");
        //        f.MapRightKey("RoleId");
        //    });
        //    base.OnModelCreating(modelBuilder);
        //}

    }
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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasMany(r => r.Roles).WithMany(o => o.Users).Map(f =>
        //    {
        //        f.MapLeftKey("UserId");
        //        f.MapRightKey("RoleId");
        //    });
        //    base.OnModelCreating(modelBuilder);
        //}

    }

    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MysqlDb : DbContext
    {
        public MysqlDb() : base("MysqlDefault")
        {
            //Database.SetInitializer<Db>(null);
        }
        public DbSet<Model.base_teacher> b_teas { get; set; }
        public DbSet<Model.base_student> b_stus { get; set; }
        public DbSet<Model.base_school> b_schs { get; set; }
        public DbSet<Model.base_class> b_cls { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
           
        //    base.OnModelCreating(modelBuilder);
        //}

    }

}