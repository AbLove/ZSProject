using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewProject.Data.Model
{
    public class Role : Entity
    {
        //[MaxLength(100)]
        public string Name { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }
}