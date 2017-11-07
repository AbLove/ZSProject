using System.ComponentModel.DataAnnotations;

using NewMYYT.CoreWebApi.ViewModels.Attributes;

namespace NewMYYT.CoreWebApi.ViewModels.Input
{
    public class CountryInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [StrLen(20)]
        [Display(ResourceType = typeof(string), Name = "Name")]
        public string Name { get; set; }
    }
}