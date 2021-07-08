using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Rush00.App.ViewModels;
using Rush00.Data.Models;

namespace Rush00.App.Views
{
    public partial class HabitTrackerView : UserControl
    {
        public HabitTrackerView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}