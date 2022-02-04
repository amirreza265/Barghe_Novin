using System;

namespace BargheNovin.Web.Areas.Admin.Models.User
{
    public class TeamMemberViewModel
    {
        public int MemberId { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public DateTime AddDate { get; set; }
    }
}
