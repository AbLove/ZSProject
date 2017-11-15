using NewProject.Data.Model;
using System.Data.Entity;

namespace NewProject.EntityFramework
{
    public class Db : DbContext
    {
        public Db() : base("Default")
        {
            Database.SetInitializer<Db>(null);
        }
        public DbSet<NUser> NUsers { get; set; }
        public DbSet<Role> Students { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<UserDevice> UserDevice { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NUser>().HasMany(r => r.RoleID).WithMany(o => o.Users).Map(f =>
            {
                f.MapLeftKey("UserId");
                f.MapRightKey("RoleID");
            });
            base.OnModelCreating(modelBuilder);
        }

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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
           
        //    base.OnModelCreating(modelBuilder);
        //}

    }

}