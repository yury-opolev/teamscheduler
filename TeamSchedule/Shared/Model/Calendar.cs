/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Model
{
    using System;
    using System.Collections.Generic;

    public class Calendar
    {
        public Guid Id { get; set; }

        public ICollection<CalendarItem> Items { get; set; }

        public string Tags { get; set; }
    }
}
