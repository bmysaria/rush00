using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rush00.Data.Models
{
    public class Habit
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Motivation { get; set; }
        public List<HabitCheck> HabitChecks { get; } = new List<HabitCheck>();
        [Required]
        public bool IsFinished { get; set; }
    }
}