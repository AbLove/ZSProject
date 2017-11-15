using System.ComponentModel.DataAnnotations;

namespace NewProject.Data.Model
{
    public class Projects : DelEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public int Price { get; set; }
        [MaxLength(10)]
        public string Color { get; set; }
        public virtual Users User { get; set; }
        //public virtual ICollection<Users> Usrs { get; set; }
    }
}
