namespace NewProject.Data.Model.MS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("myc.User")]
    public partial class User
    {
        public Guid UserID { get; set; }

        [Key]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public int? RoleID { get; set; }

        [StringLength(512)]
        public string Email { get; set; }

        [StringLength(512)]
        public string Phone { get; set; }

        [StringLength(512)]
        public string QQ { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(512)]
        public string District { get; set; }

        [StringLength(512)]
        public string City { get; set; }

        public int? SchoolID { get; set; }

        public int? ClassID { get; set; }

        [StringLength(50)]
        public string NickName { get; set; }

        [StringLength(512)]
        public string Picture { get; set; }
    }
}
