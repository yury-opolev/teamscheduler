/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Model
{
    using System;

    public class CalendarItem
    {
        public Guid Id { get; set; }

        public Guid CalendarId {  get; set; }
        public Calendar Calendar { get; set; }

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public TimeSpan Duration { get; set; }

        public string Tags { get; set; }
    }
}
