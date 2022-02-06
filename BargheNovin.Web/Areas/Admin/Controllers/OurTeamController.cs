using AutoMapper;
using BargheNovin.Core.Attributes;
using BargheNovin.Core.DTOs.Team;
using BargheNovin.Core.Services.Interface;
using BargheNovin.Web.Areas.Admin.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BargheNovin.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [AdminPanel()]
    [Route("/{area}/our-team/{action=index}")]
    public class OurTeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public OurTeamController(ITeamService teamService, IMapper mapper)
        {
            this._teamService = teamService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var members = _teamService.GetTeamMembersWhere();
            var membersVm = _mapper.Map<List<TeamMemberViewModel>>(members);
            return View(membersVm);
        }

        public IActionResult Edit(InputTeamMemberViewModel model)
        {
            if (!ModelState.IsValid)
                return ModelErrors;

            var member = _teamService.GetTeamMember(model.MemberId);
            if (member == null)
            {
                ModelState.AddModelError("", "عضو یافت نشد");
                return ModelErrors;
            }

            member.DisplayName = model.DisplayName;
            _teamService.Update(member);

            return Json(true);
        }


        private JsonResult ModelErrors
        {
            get => Json(ModelState.Values.SelectMany(val => val.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
