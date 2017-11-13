using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewProject.Data.Model
{
    public class Users : DelEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public bool Sex { get; set; }
        public int Age { get; set; }
        [MaxLength(50)]
        public string NickName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Job { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string School { get; set; }
        [MaxLength(200)]
        public string PersonImg { get; set; }
        [MaxLength(500)]
        public string Love { get; set; }
        //public string Wife { get; set; }
        //public virtual List<Users> Sons { get; set; }
        public virtual int Parent { get; set; }
        [MaxLength(500)]
        public string Descript { get; set; }
        [MaxLength(500)]
        public string Summary { get; set; }
        public virtual ICollection<Projects> Pros { get; set; }
        //public virtual Projects Pro { get; set; }
    }
}
