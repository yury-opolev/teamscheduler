/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Web.Resource;
    using TeamSchedule.Server.Core;
    using TeamSchedule.Server.Core.Storage;
    using TeamSchedule.Shared.Model;

    [Authorize]
    [ApiController]
    [Route("api/v1.0/notifysignin")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class SignInController : ControllerBase
    {
        private readonly ILogger<SignInController> logger;

        private readonly TeamScheduleContext context;

        public SignInController(ILogger<SignInController> logger, TeamScheduleContext teamScheduleContext)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.context = teamScheduleContext ?? throw new ArgumentNullException(nameof(teamScheduleContext));
        }

        [HttpGet]
        public bool NotifySignIn()
        {
            this.logger.LogInformation($"NotifySignIn - user '{User.Identity.Name}'");

            this.CheckCreateUser();
            return true;
        }

        private void CheckCreateUser()
        {
            if (this.context.Users.Any(user => user.Email.Equals(ClaimsPrincipalHelper.GetEmail(User))))
            {
                return;
            }

            this.logger.LogInformation($"User '{User.Identity.Name}' is not listed yet, creating...");
            this.context.Users.Add(new TeamUser()
            {
                Id = Guid.NewGuid(),
                Name = User.Identity.Name,
                Email = ClaimsPrincipalHelper.GetEmail(User)
            });

            this.context.SaveChanges();
        }
    }
}
