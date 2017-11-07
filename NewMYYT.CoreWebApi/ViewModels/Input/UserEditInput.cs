using System.ComponentModel.DataAnnotations;
namespace NewMYYT.CoreWebApi.ViewModels.Input
{
    public class UserEditInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [UIHint("MultiLookupDropdown")]
        public int[] Roles { get; set; }
    }
}