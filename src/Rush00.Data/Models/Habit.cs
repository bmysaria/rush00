using System.Collections.Generic;

namespace Rush00.Data.Models
{
    public class Habit
    {
        public string Title { get; set; }
        public string Motivation { get; set; }
        public List<HabitCheck> HabitChecks { get; } = new List<HabitCheck>();
        public bool IsFinished;
    }
}