using System.ComponentModel.DataAnnotations;
using NewMYYT.CoreWebApi.ViewModels.Attributes;

namespace NewMYYT.CoreWebApi.ViewModels.Input
{
    public class UserCreateInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [StrLen(15)]
        public string Login { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [StrLen(20)]
        [UIHint("password")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [UIHint("MultiLookupDropdown")]
        public int[] Roles { get; set; }
    }
}