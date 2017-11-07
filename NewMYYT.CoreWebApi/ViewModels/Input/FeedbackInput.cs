using System.ComponentModel.DataAnnotations;

using NewMYYT.CoreWebApi.ViewModels.Attributes;

namespace NewMYYT.CoreWebApi.ViewModels.Input
{
    public class FeedbackInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [StrLen(500)]
        [UIHint("TinyMCE")]
        public string Comments { get; set; }
    }
}