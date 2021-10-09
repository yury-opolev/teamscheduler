/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Model
{
    using System;

    public class TeamUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
