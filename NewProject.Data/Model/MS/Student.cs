namespace NewProject.Data.Model.MS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("myc.Student")]
    public partial class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }

        public int ClassID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool? Sex { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Birthday { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Proviance { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Area { get; set; }

        [StringLength(50)]
        public string FaceImgName { get; set; }

        public Guid? PersistedFaceId { get; set; }

        public Guid? PersistedFaceIdSchool { get; set; }

        public int? State { get; set; }
    }
}
