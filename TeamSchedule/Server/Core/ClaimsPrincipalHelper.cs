using System.Security.Claims;

namespace TeamSchedule.Server.Core
{
    public static class ClaimsPrincipalHelper
    {
        public static string GetName(ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst("name")?.Value ?? string.Empty;
        }

        public static string GetEmail(ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst("preferred_username")?.Value ?? string.Empty;
        }
    }
}
