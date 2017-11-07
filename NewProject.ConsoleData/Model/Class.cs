namespace NewProject.ConsoleData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("myc.Class")]
    public partial class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassID { get; set; }

        public int? SchoolID { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }

        [StringLength(50)]
        public string ClassType { get; set; }

        public int? State { get; set; }

        [StringLength(50)]
        public string Grade { get; set; }
    }
}
