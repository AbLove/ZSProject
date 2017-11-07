namespace NewProject.ConsoleData.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MSsql : DbContext
    {
        public MSsql()
            : base("name=MSsql")
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .Property(e => e.Descp)
                .IsUnicode(false);
        }
    }
}
