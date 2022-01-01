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

            ProfileSettingsButton.PreviewMouseDown += ButtonResizeInvoker;
            SettingsButton.PreviewMouseDown += ButtonResizeInvoker;
            InfoButton.PreviewMouseDown += ButtonResizeInvoker;

            ProfileSettingsButton.PreviewMouseUp += ButtonResizeInvoker;
            SettingsButton.PreviewMouseUp += ButtonResizeInvoker;
            InfoButton.PreviewMouseUp += ButtonResizeInvoker;

            ProfileSettingsButton.Click += ButtonClickInvoker;
            SettingsButton.Click += ButtonClickInvoker;
            InfoButton.Click += ButtonClickInvoker;
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler ProfileSettingsButtonClick;

        public event RoutedEventHandler SettingsButtonClick;

        public event RoutedEventHandler InfoButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "ProfileSettingsButton":
                    ProfileSettingsButtonClick?.Invoke(sender, e);
                    break;

                case "SettingsButton":
                    SettingsButtonClick?.Invoke(sender, e);
                    break;

                case "InfoButton":
                    InfoButtonClick?.Invoke(sender, e);
                    break;
            }
        }

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);
    }
}
