using System.ComponentModel.DataAnnotations;

namespace BargheNovin.Web.Models.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name ="ایمیل یا نام کاربری")]
        [MaxLength(100, ErrorMessage ="حد اکثر تعداد کاراکتر مجاز برای {0} می تواند {1} کاراکتر باشد")]
        public string UserIndex { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "حد اکثر تعداد کاراکتر مجاز برای {0} می تواند {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "یاد آور من")]
        public bool RememberMe { get; set; }
    }
}
