/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Model
{
    using System;

    public class TeamUserCalendar
    {
        public Guid TeamId {  get; set; }
        public Team Team { get; set; }

        public Guid UserId {  get; set; }
        public TeamUser User { get; set; }

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public int TotalHours { get; set; }
        public int UnavailableHours { get; set; }
    }
}
