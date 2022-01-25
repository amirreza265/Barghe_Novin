using System.ComponentModel.DataAnnotations;

namespace BargheNovin.Core.DTOs.Portfolio
{
    public class InputCategoryViewModel
    {
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(150,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name ="نام گروه")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "نام فیلتر گروه")]
        [RegularExpression("^[^a-z]+$", ErrorMessage ="{0} باید فقط از حروف کوچک انگلیسی تشکیل شده باشد")]
        public string CategoryFilterName { get; set; }
    }
}
