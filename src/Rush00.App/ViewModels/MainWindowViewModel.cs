using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using ReactiveUI;
using Rush00.App.ViewModels;

namespace Rush00.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title;
        private ViewModelBase? _content;

        public string Title
        {
            get { return _title; }
            private set { this.RaiseAndSetIfChanged(ref _title, value); }
        }

        public ViewModelBase? Content
        {
            get { return _content; }
            set { this.RaiseAndSetIfChanged(ref _content, value); }
        }

        public MainWindowViewModel()
        {
            CreateHabit();
        }
        public void CreateHabit()
        {
            var vm = new HabitCreateViewModel();
            Content = vm;
        }
    }
}
