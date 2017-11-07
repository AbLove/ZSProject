using System.Collections.Generic;

namespace NewMYYT.Core.Model
{
    public class User_Role : DelEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}