/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Shared.Core
{
    using Microsoft.EntityFrameworkCore;
    using TeamSchedule.Shared.Model;
    using TeamSchedule.Shared.Model.Permissions;

    public class TeamScheduleContext : DbContext
    {
        #region Permissions

        public DbSet<PermissionState> PermissionState { get; set; }

        public DbSet<PermissionGroup> PermissionGroups { get; set; }

        public DbSet<PermissionSet> PermissionSets { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        #endregion Permissions

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamUser> Users { get; set; }

        public DbSet<TeamUser> Duties { get; set; }

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<CalendarItem> CalendarItems { get; set; }

        public TeamScheduleContext(DbContextOptions<TeamScheduleContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionState>()
                .HasData(new PermissionState { Id = Guid.NewGuid(), Version = 1 });
        }
    }
}
