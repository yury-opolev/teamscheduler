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
    [Route("api/v1.0/users")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;

        private readonly TeamScheduleContext context;

        public UsersController(ILogger<UsersController> logger, TeamScheduleContext teamScheduleContext)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = teamScheduleContext ?? throw new ArgumentNullException(nameof(teamScheduleContext));
        }

        [HttpGet]
        public IEnumerable<TeamUser> GetUsersList()
        {
            this.logger.LogInformation($"GetUsersList - user '{User.Identity.Name}'");
            return this.context.Users;
        }
    }
}