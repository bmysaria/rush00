using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using Rush00.App.ViewModels;
using Rush00.Data.Models;
using Rush00.Data.Migrations;

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
            TrackHabit();
        }
        public void CreateHabit()
        {
            var vm = new HabitCreateViewModel();

            vm.StartHabit.Take(1).Subscribe(model =>
            {
                using (var context = new HabitDbContext())
                {
                    context.Habits.Add(model);
                    context.HabitChecks.AddRange(
                        Enumerable.Range(0, vm.Days)
                            .Select(offset => new HabitCheck
                            {
                                Date = vm.Date.AddDays(offset),
                                Habit = model,
                                IsChecked = false
                            })
                            .ToList());
                    context.SaveChanges();
                }
                TrackHabit();
            });
            Content = vm;
        }
        // сделать у HabitTrackerViewModel проперти IsFinished, и слушать его изменения в MainWindowViewModel.
        //
        // когда в HabitTrackerViewModel мы получим событие изменения IsChecked от HabitCheckViewModel, то
        // там провернем все это сохранение в бд,
        // и заодно проверим, не последняя ли эта модель дала событие IsChecked. И, если да, то поставим у HabitTrackerViewModel IsFinished в true.
        //
        // когда в MainWindowViewModel мы получим событие изменения IsFinished, то
        // сохраним галочку из финишт в бд, ну и поменяем модель на HabitCreateViewModel
        public void TrackHabit()
        {
            using (var context = new HabitDbContext())
            {
                var myHabit = context.Habits
                    .Include(x => x.HabitChecks)
                    .FirstOrDefault(x => !x.IsFinished);

                if (myHabit == null )
                {
                    CreateHabit();
                    return;
                }
                Title = myHabit.Title;
                Content = new HabitTrackerViewModel(myHabit.HabitChecks.OrderBy(x => x.Date));
            }
        }

    }
}
