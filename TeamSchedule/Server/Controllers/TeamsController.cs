/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Identity.Web.Resource;
    using TeamSchedule.Shared.Core;
    using TeamSchedule.Shared.Model;

    [Authorize]
    [ApiController]
    [Route("api/v1.0/teams")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> logger;

        private readonly TeamScheduleContext context;

        public TeamsController(ILogger<TeamsController> logger, TeamScheduleContext context)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IEnumerable<Team> GetTeamsList()
        {
            this.logger.LogInformation($"GetTeamsList - user '{User.Identity.Name}'");
            return this.context.Teams;
        }

        [HttpPost]
        public IActionResult CreateTeam([FromBody]Team team)
        {
            this.logger.LogInformation($"{nameof(CreateTeam)} - user '{User.Identity.Name}'");
            var teamExists = !(this.context.Teams.FirstOrDefault(t => t.Name.Equals(team.Name)) is default(Team));
            if (teamExists)
            {
                return this.Conflict(new { Status = "conflict", Message = "Team already exists" });
            }

            if (Guid.Empty.Equals(team.Id))
            {
                team.Id = Guid.NewGuid();
            }

            team.CreatedAt = DateTime.UtcNow;
            team.CreatedBy = User.Identity.Name;

            this.context.Teams.Add(team);
            this.context.SaveChanges();

            return this.Ok(new { Status = "ok", Message = "Team created" });
        }

        [HttpPut]
        public IActionResult UpdateTeam([FromBody] Team team)
        {
            this.logger.LogInformation($"UpdateTeam - user '{User.Identity.Name}'");
            var teamWithNameExists = !(this.context.Teams.FirstOrDefault(t => !t.Id.Equals(team.Id) && t.Name.Equals(team.Name)) is default(Team));
            if (teamWithNameExists)
            {
                return this.Conflict(new { Status = "conflict", Message = "Team with provided name already exists" });
            }

            var existingTeam = this.context.Teams.FirstOrDefault(t => t.Id.Equals(team.Id));
            if (existingTeam is default(Team))
            {
                return this.BadRequest(new { Status = "bad_request", Message = "Team not exists" });
            }

            existingTeam.Name = team.Name;
            this.context.SaveChanges();

            return this.Ok(new { Status = "ok", Message = "Team updated" });
        }
    }
}
