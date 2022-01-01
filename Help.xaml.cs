using System.Windows;
using System.Windows.Controls;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : UserControl
    {
        public Help()
        {
            InitializeComponent();

            HelpButton.PreviewMouseDown += ButtonResizeInvoker;
            HelpButton.PreviewMouseUp += ButtonResizeInvoker;

            HelpButton.Click += HelpButtonClickInvoker;
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler HelpButtonClick;

        private void HelpButtonClickInvoker(object sender, RoutedEventArgs e) => HelpButtonClick?.Invoke(sender, e);

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);
    }
}
