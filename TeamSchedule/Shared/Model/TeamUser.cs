/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Model
{
    using System;

    public class TeamUser
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Calendar> Calendars { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
