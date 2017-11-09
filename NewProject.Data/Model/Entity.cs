using System.ComponentModel.DataAnnotations.Schema;

namespace NewProject.Data.Model
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
    }
}