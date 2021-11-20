/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Model
{
    using System;

    public class TeamDuty
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public Guid CalendarId { get; set; }
        public Calendar Calendar { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime CreatedBy { get; set; }
    }
}
