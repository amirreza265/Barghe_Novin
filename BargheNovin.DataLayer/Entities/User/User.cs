using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.Entities.User
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(100)]
        [Required]
        public string UserName { get; set; }
        [MaxLength(100)]
        [Required]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        [MaxLength(150)]
        [Required]
        public string Email { get; set; }
    }
}
