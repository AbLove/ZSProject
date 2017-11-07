using NewMYYT.CoreWebApi.ViewModels.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NewMYYT.CoreWebApi.ViewModels.Input
{
    public class ChefInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [StrLen(15)]
        [Display(ResourceType = typeof(int), Name = "First_Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [StrLen(15)]
        [Display(ResourceType = typeof(int), Name = "Last_Name")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [UIHint("Odropdown")]
        [Display(ResourceType = typeof(int), Name = "Country")]
        public int? CountryId { get; set; }
    }
}