using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.DataLayer.Entities.User
{
    public class TeamMember
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(150)]
        public string DisplayName { get; set; }
        public string Description { get; set; }


        public DateTime AddDate { get; set; }
        public DateTime? RemoveDate { get; set; } = null;

        public bool IsFired { get; set; } = false;

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
