using Microsoft.EntityFrameworkCore;

namespace Rush00.Data.Models
{
    public class HabitDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitCheck> HabitChecks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=habits.db");
        }
    }
}