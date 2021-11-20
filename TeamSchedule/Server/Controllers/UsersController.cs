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
    [Route("api/v1.0/users")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;

        private readonly TeamScheduleContext context;

        public UsersController(ILogger<UsersController> logger, TeamScheduleContext context)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IEnumerable<TeamUser> GetUsersList()
        {
            this.logger.LogInformation($"GetUsersList - user '{User.Identity.Name}'");
            return this.context.Users;
        }
    }
}