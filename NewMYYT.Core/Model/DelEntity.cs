namespace NewMYYT.Core.Model
{
    public class DelEntity : Entity, IDel
    {
        public bool IsDeleted { get; set; }
    }
}