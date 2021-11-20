

namespace TeamSchedule.Shared.Model.Permissions
{
    using System;

    public class PermissionGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<PermissionSet> PermissionSets { get; set; }

    }
}
