using System;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using Rush00.Data.Models;

namespace Rush00.App.ViewModels
{
    public class HabitCreateViewModel : ViewModelBase
    {
        private string _title;
        private string _motivation;
        private DateTimeOffset _date;
        private int _days;
        public string Title
        {
            get { return _title; }
            set { this.RaiseAndSetIfChanged(ref _title, value); }
        }

        public string Motivation
        {
            get { return _motivation; }
            set { this.RaiseAndSetIfChanged(ref _motivation, value); }
        }

        public DateTimeOffset Date
        {
            get { return _date; }
            set { this.RaiseAndSetIfChanged(ref _date, value); }
        }

        public int Days
        {
            get { return _days; }
            set { this.RaiseAndSetIfChanged(ref _days, value); }
        }
        public ReactiveCommand<Unit, Habit> StartHabit { get; }
        public HabitCreateViewModel()
        {
            _title = "";
            _motivation = "";
            _date = DateTimeOffset.Now.DateTime;
            _days = 0;

            //Here we listen to property change notifications
            IObservable<bool>? canCreate = this.WhenAnyValue(vm => vm.Title, vm => vm.Motivation,
                    vm => vm.Date, ((s, s1, arg3) => !string.IsNullOrEmpty(_title) && !string.IsNullOrEmpty((_motivation))));
            StartHabit = ReactiveCommand.Create(
                () => new Habit
                {
                    IsFinished = false,
                    Title = Title.Trim(),
                    Motivation = Motivation,
                }, canCreate);
        }

    }
}