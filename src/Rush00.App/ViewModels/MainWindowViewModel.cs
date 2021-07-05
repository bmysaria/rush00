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
                using (var dbCtx = new HabitDbContext())
                {
                    dbCtx.Habits.Add(model);
                    dbCtx.HabitChecks.AddRange(
                        Enumerable.Range(0, vm.Days)
                            .Select(offset => new HabitCheck
                            {
                                Date = vm.Date.AddDays(offset),
                                Habit = model,
                                IsChecked = false
                            })
                            .ToList());
                    dbCtx.SaveChanges();
                }
                TrackHabit();
            });
            Content = vm;
        }

        public void TrackHabit()
        {
            using (var context = new HabitDbContext())
            {
                var myHabit = context.Habits
                    .Include(x => x.HabitChecks)
                    .FirstOrDefault();

                if (myHabit == null)
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
