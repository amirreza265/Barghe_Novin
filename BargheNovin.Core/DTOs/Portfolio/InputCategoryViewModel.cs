using System.ComponentModel.DataAnnotations;

namespace BargheNovin.Core.DTOs.Portfolio
{
    public class InputCategoryViewModel
    {
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(150,ErrorMessage ="{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name ="نام گروه")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Display(Name = "نام فیلتر گروه")]
        [RegularExpression(@"^[a-z]+$", ErrorMessage = "{0} باید فقط از حروف کوچک انگلیسی تشکیل شده باشد")]
        public string FilterName { get; set; }

        public int CategoryId { get; set; }
    }
}
