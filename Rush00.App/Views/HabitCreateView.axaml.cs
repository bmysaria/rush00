using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;


namespace Rush00.App.Views
{
    public class HabitCreateView : UserControl
    {
        public HabitCreateView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}