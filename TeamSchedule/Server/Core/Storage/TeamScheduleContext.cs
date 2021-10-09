/// <summary>
/// ...
/// </summary>

namespace TeamSchedule.Server.Core.Storage
{
    using Microsoft.EntityFrameworkCore;
    using TeamSchedule.Shared.Model;

    public class TeamScheduleContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamUser> Users { get; set; }

        public DbSet<TeamUserCalendar> UserCalendar { get; set; }

        public TeamScheduleContext(DbContextOptions<TeamScheduleContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<TeamUser>().ToTable("Users");
            modelBuilder.Entity<TeamUserCalendar>(eb => { eb.HasNoKey(); });
        }
    }
}
