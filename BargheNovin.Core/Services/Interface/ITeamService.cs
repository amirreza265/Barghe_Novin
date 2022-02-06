using BargheNovin.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services.Interface
{
    public interface ITeamService
    {
        List<TeamMember> GetTeamMembersWhere(int? pageId = null, int? take = null, string username = "", string displayName = "");

        TeamMember GetTeamMember(int memberId, bool includeUser = true);
        TeamMember GetTeamMember(string username);

        TeamMember Update(TeamMember team, bool save = true);

        void FireAMember(TeamMember teamMember, bool isFired = true, bool save = true);
        void FireAMember(string username, bool isFired = true, bool save = true);
        void FireAMember(int memberId, bool isFired = true, bool save = true);

        TeamMember CreateTeamMember(string username, TeamMember member, bool save = true);
    }
}
