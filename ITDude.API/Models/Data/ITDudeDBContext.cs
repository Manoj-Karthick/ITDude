using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ITDude.API.Models.Data
{
    public class ITDudeDBContext : DbContext
    {
        public ITDudeDBContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitTracker> HabitTrackers { get; set; }
        public DbSet<Repeat> Repeats { get; set; }
    }
}
