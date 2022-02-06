﻿using BargheNovin.Core.Services.Interface;
using BargheNovin.DataLayer.DataBaseContext;
using BargheNovin.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly BargheNovinDBContext _context;

        public TeamService(BargheNovinDBContext context)
        {
            _context = context;
        }

        public void FireAMember(TeamMember teamMember, bool isFired = true, bool save = true)
        {
            teamMember.IsFired = isFired;

            if (save)
                _context.SaveChanges();
        }

        public void FireAMember(string username, bool isFired = true, bool save = true)
        {
            var member = GetTeamMember(username);
            FireAMember(member, isFired, save);
        }

        public void FireAMember(int memberId, bool isFired = true, bool save = true)
        {
            var member = GetTeamMember(memberId, false);
            FireAMember(member, isFired,save);
        }

        public TeamMember GetTeamMember(int memberId, bool includeUser = true)
        {
            IQueryable<TeamMember> members = _context.TeamMembers;

            if (includeUser)
                members = members.Include(m => m.User);

            return members.SingleOrDefault(m => m.MemberId == memberId);
        }

        public TeamMember GetTeamMember(string username)
        {
            return _context.TeamMembers
                .Include(t => t.User)
                .SingleOrDefault(tm => tm.User.UserName == username); 
        }

        public List<TeamMember> GetTeamMembersWhere(int? pageId = null, int? take = null, string username = "", string displayName = "")
        {
            IQueryable<TeamMember> teamMembers = _context.TeamMembers
                .Include(tm => tm.User)
                .AsSplitQuery();

            if (username is not (null or ""))
            {
                teamMembers = teamMembers
                    .Where(tm => EF.Functions.Like(tm.User.UserName, $"%{username}%"));
            }

            if (displayName is not (null or ""))
            {
                teamMembers = teamMembers
                    .Where(tm => EF.Functions.Like(tm.DisplayName, $"%{displayName}%"));
            }

            int? skip = null;
            if ((pageId is not null) || (take is not null))
            {
                skip = take * pageId;
            }

            teamMembers = teamMembers
                        .OrderByDescending(tm => tm.AddDate);

            if (skip is not null)
                teamMembers = teamMembers
                        .Skip((int)skip)
                        .Take((int)take);

            return teamMembers.ToList();
        }

        public TeamMember Update(TeamMember team, bool save = true)
        {
            _context.TeamMembers.Update(team);

            if (save)
                _context.SaveChanges();

            return team;
        }
    }
}
