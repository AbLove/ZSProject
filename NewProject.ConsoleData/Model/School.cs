namespace NewProject.ConsoleData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("myc.School")]
    public partial class School
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Lev { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(50)]
        public string Contacts { get; set; }

        [StringLength(50)]
        public string Charge { get; set; }

        [Column(TypeName = "text")]
        public string Descp { get; set; }

        public float? Lan { get; set; }

        public float? Lat { get; set; }

        public int? Statue { get; set; }

        [StringLength(10)]
        public string Proviance { get; set; }

        [StringLength(10)]
        public string City { get; set; }

        [StringLength(10)]
        public string Area { get; set; }
    }
}
