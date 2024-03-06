using System.ComponentModel.DataAnnotations.Schema;

namespace ITDude.API.Models
{
    public class HabitTracker
    {
        [Column(Order = 1)]
        public Guid Id { get; set; }
        [Column(Order = 2)]
        public string? Notes { get; set; }

        [Column(Order =4)]
        public DateTime TrackedDate { get; set; }

        [Column(Order = 3)]
        public Guid HabitId { get; set; }

        public Habit Habit { get; set; }
    }
}
