using System.Collections.Generic;

namespace NewMYYT.Core.Model
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public virtual User Users { get; set; }
    }
}