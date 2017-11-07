using System.ComponentModel.DataAnnotations;

using NewMYYT.CoreWebApi.ViewModels.Attributes;

namespace NewMYYT.CoreWebApi.ViewModels.Input
{
    public class MealInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(string))]
        [StrLen(50)]
        [Display(ResourceType = typeof(string), Name = "Name")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(string), Name = "Comments")]
        [StrLen(150)]
        [UIHint("TextArea")]
        public string Comments { get; set; }
    }
}