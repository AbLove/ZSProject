using System.ComponentModel.DataAnnotations;


namespace NewMYYT.CoreWebApi.ViewModels.Attributes
{
    public class StrLenAttribute : StringLengthAttribute
    {
        public StrLenAttribute(int maximumLength)
            : base(maximumLength)
        {
            ErrorMessageResourceName = "strlen";
        }
    }
}