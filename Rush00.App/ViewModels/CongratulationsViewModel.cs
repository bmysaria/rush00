using System;
using System.Linq;
using Rush00.Data.Models;

namespace Rush00.App.ViewModels
{
    public class CongratulationsViewModel : ViewModelBase
    {
        private Habit  _habit { set; get; }
        public CongratulationsViewModel(Habit habit)
        {
            this._habit = habit;
        }

        private int _daysChecked => _habit.HabitChecks.Where(x => x.IsChecked).Count();
        private int _daysTotal => _habit.HabitChecks.Count();
        public string Count => $"{_daysChecked}" + "/" + $"{_daysTotal}" + " days is checked.";
        public string Motivation => _habit.Motivation;
    }
}