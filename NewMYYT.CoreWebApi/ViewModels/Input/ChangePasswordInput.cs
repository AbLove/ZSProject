using System.ComponentModel.DataAnnotations;
using NewMYYT.CoreWebApi.ViewModels.Attributes;

namespace NewMYYT.CoreWebApi.ViewModels.Input
{
    public class ChangePasswordInput : Input
    {
        [Required(ErrorMessageResourceName = "required")]
        [StrLen(20)]
        [UIHint("password")]
        public string Password { get; set; }
    }
}