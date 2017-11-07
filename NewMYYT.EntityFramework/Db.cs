using Microsoft.EntityFrameworkCore;
using NewMYYT.Core.Model;

namespace NewMYYT.EntityFramework
{
    public class Db : DbContext
    {
        public Db()
        {
            //Database.SetInitializer<Db>(null);
        }
        public Db(DbContextOptions<Db> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }

        //public DbSet<User_Role> User_Role { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Dinner>().HasMany(r => r.Meals).WithMany(o => o.Dinners).Map(f =>
            //{
            //    f.MapLeftKey("DinnerId");
            //    f.MapRightKey("MealId");
            //});

            //modelBuilder.Entity<User>().HasMany(r => r.Roles).WithOne(o => o.Users).HasForeignKey(ur => ur.Users);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=TestDb;user=root;password=123;");
        }

    }
}