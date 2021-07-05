using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using DynamicData.Binding;
using Rush00.Data.Models;

namespace Rush00.App.ViewModels
{
    public class HabitTrackerViewModel : ViewModelBase
    {
        public HabitTrackerViewModel(IEnumerable<HabitCheck> habitChecks)
        {
            HabitChecks = new ObservableCollectionExtended<HabitCheck>(habitChecks);
            HabitChecks.CollectionChanged += HabitChecksCollectionChanged;
        }

        private void HabitChecksCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<HabitCheck> HabitChecks { get; set; }
    }
}