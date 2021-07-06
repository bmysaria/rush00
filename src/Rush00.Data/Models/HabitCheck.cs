using System;
using System.ComponentModel.DataAnnotations;

namespace Rush00.Data.Models
{
    public class HabitCheck
    {
        [Key, Required]
        public int Id { get; set; }
        public int HabitId { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        [Required]
        public bool IsChecked { get; set; }
        [Required]
        public Habit Habit { get; set; }
    }
}