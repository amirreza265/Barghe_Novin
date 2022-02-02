using System.ComponentModel.DataAnnotations;

namespace BargheNovin.Web.Models.Users
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کتید")]
        [Display(Name = "نام کاربری")]
        [MaxLength(100, ErrorMessage = "حد اکثر تعداد کاراکتر مجاز برای {0} می تواند {1} کاراکتر باشد")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کتید")]
        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "حد اکثر تعداد کاراکتر مجاز برای {0} می تواند {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کتید")]
        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(100, ErrorMessage = "حد اکثر تعداد کاراکتر مجاز برای {0} می تواند {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
        
        [Required(ErrorMessage = "لطفا {0} را وارد کتید")]
        [Display(Name ="ایمیل")]
        [MaxLength(150, ErrorMessage ="حد اکثر تعداد کاراکتر مجاز برای {0} می تواند {1} کاراکتر باشد")]
        public string Email { get; set; }
    }
}
