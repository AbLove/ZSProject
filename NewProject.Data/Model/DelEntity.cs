namespace NewProject.Data.Model
{
    public class DelEntity : Entity, IDel
    {
        public bool IsDeleted { get; set; }
    }
}