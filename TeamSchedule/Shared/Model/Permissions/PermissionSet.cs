/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Model.Permissions
{
    using System;
    using System.Collections.Generic;

    public class PermissionSet
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
