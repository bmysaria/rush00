using ReactiveUI;
using Rush00.Data.Models;

namespace Rush00.App.ViewModels
{
    public class HabitCheckViewModel : ViewModelBase
    {
        private bool _isChecked;

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            private set { this.RaiseAndSetIfChanged(ref _isChecked, value); }
        }
        public HabitCheck Model { get; private set; }

        public HabitCheckViewModel(HabitCheck habitCheck)
        {
            IsChecked = habitCheck.IsChecked;
            Model = habitCheck;
        }
    }
}