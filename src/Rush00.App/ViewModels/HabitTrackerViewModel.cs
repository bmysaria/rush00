using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using DynamicData.Binding;
using ReactiveUI;
using Rush00.Data.Models;

namespace Rush00.App.ViewModels
{
    public class HabitTrackerViewModel : ViewModelBase
    {
        private bool _isFinished;
        public bool IsFinished
        {
            get
            {
                return _isFinished;
            }
            private set { this.RaiseAndSetIfChanged(ref _isFinished, value); }
        }
        public HabitTrackerViewModel(IEnumerable<HabitCheck> habitChecks)
        {
            HabitChecks =
                new ObservableCollectionExtended<HabitCheckViewModel>(habitChecks
                    .Select(x => new HabitCheckViewModel(x)).ToList());
            foreach (var habitCheck in HabitChecks)
            {
                habitCheck.WhenPropertyChanged(x => x.IsChecked, false).Subscribe(HandleHabitCheckChanged);
            } //подписались на все модельки
        }
        private void HandleHabitCheckChanged(PropertyValue<HabitCheckViewModel, bool> obj)
        {
            using var context = new HabitDbContext();
            var targetModel = obj.Sender.Model;
            targetModel.IsChecked = obj.Value;
            context.HabitChecks.Update(targetModel);
            context.SaveChanges();

            if (this.HabitChecks.Last() == obj.Sender)
                this.IsFinished = true;
        }

        public ObservableCollection<HabitCheckViewModel> HabitChecks { get; set; }
    }
}