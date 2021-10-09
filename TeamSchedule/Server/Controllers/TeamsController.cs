/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Web.Resource;
    using TeamSchedule.Server.Core.Storage;
    using TeamSchedule.Shared.Model;

    [Authorize]
    [ApiController]
    [Route("api/v1.0/teams")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> logger;

        private readonly TeamScheduleContext context;

        public TeamsController(ILogger<TeamsController> logger, TeamScheduleContext teamScheduleContext)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = teamScheduleContext ?? throw new ArgumentNullException(nameof(teamScheduleContext));
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
            this.logger.LogInformation($"CreateTeam - user '{User.Identity.Name}'");
            var teamExists = !(this.context.Teams.FirstOrDefault(t => t.Name.Equals(team.Name)) is default(Team));
            if (teamExists)
            {
                return this.Conflict(new { Status = "conflict", Message = "Team already exists" });
            }

            this.context.Teams.Add(team);
            this.context.SaveChanges();

            return this.Ok(new { Status = "ok", Message = "Team created" });
        }
    }
}
