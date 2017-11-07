using System.ComponentModel.DataAnnotations;

namespace NewMYYT.CoreWebApi.ViewModels.Input
{
    public class SignInInput
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        // [Display(ResourceType = typeof(Mui), Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [UIHint("Password")]
        //   [Display(ResourceType = typeof(Mui), Name = "Password")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}