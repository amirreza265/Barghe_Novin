using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.DTOs.Team
{
    public class InputTeamMemberViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کتید")]
        [Display(Name ="نام نمایشی")]
        [MaxLength(100, ErrorMessage ="حد اکثر تعداد کاراکتر مجاز برای {0} می تواند {1} کاراکتر باشد")]
        public string DisplayName { get; set; }
    }
}
