/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Model
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<TeamUser> Users { get; set; }
    }
}
