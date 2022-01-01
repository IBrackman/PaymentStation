using System.Windows;
using System.Windows.Controls;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for Back.xaml
    /// </summary>
    public partial class Back : UserControl
    {
        public Back()
        {
            InitializeComponent();

            BackButton.PreviewMouseDown += ButtonResizeInvoker;
            BackButton.PreviewMouseUp += ButtonResizeInvoker;

            BackButton.Click += BackButtonClickInvoker;
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler BackButtonClick;

        private void BackButtonClickInvoker(object sender, RoutedEventArgs e) => BackButtonClick?.Invoke(sender, e);

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);
    }
}
