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
            }
        }
        // когда в HabitTrackerViewModel мы получим событие изменения IsChecked от HabitCheckViewModel, то
        // там провернем все это сохранение в бд,
        // и заодно проверим, не последняя ли эта модель дала событие IsChecked. И, если да, то поставим у HabitTrackerViewModel IsFinished в true.
        private void HandleHabitCheckChanged(PropertyValue<HabitCheckViewModel, bool> obj)
        {
           // this.HabitChecksCollectionChanged();
            Debug.WriteLine(obj);
        }

        private void HabitChecksCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<HabitCheckViewModel> HabitChecks { get; set; }
    }
}