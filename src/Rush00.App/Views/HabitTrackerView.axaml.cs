using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

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

        private void ToggleButton_OnUnchecked(object? sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ToggleButton_OnChecked(object? sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}