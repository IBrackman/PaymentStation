using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();

            foreach (var child in ((StackPanel)Content).Children)
                if (child.GetType() == typeof(ComplexButton))
                {
                    ((ComplexButton)child).ButtonResize += ButtonResizeInvoker;
                    ((ComplexButton)child).ButtonClick += ButtonClickInvoker;
                }
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler ProfileSettingsButtonClick;

        public event RoutedEventHandler SettingsButtonClick;

        public event RoutedEventHandler InfoButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e)
        {
            var buttonClickHandlerDict = new Dictionary<string, RoutedEventHandler>
            {
                { nameof(ProfileSettingsButtonClick), ProfileSettingsButtonClick },
                { nameof(SettingsButtonClick), SettingsButtonClick },
                { nameof(InfoButtonClick), InfoButtonClick }
            };

            buttonClickHandlerDict[$"{((Button)sender).Tag}Click"]?.Invoke(sender, e);
        }

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);
    }
}
