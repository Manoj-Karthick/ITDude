namespace ITDude.API.Models
{
    public class Habit
    {
        public Guid Id { get; set; }
        public string HabitName { get; set; }
        public string? HabitGoal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int RepeatId { get; set; }
        public Repeat Repeat { get; set; }
    }
}
