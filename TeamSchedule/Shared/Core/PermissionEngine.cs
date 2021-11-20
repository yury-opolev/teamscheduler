/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Core
{
    using System;

    public class PermissionEngine
    {
        private TeamScheduleContext context;

        public PermissionEngine(TeamScheduleContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool IsAllowed(string objectId, string action)
        {
            return true;
        }

        public bool IsAllowed(string objectId, string action, string condition)
        {
            return true;
        }
    }
}
