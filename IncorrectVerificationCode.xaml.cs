using System.Windows;
using System.Windows.Controls;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for IncorrectVerificationCode.xaml
    /// </summary>
    public partial class IncorrectVerificationCode : UserControl
    {
        public IncorrectVerificationCode()
        {
            InitializeComponent();

            UCSendCodeButton.ButtonResize += ButtonResizeInvoker;
            UCSendCodeButton.ButtonClick += ButtonClickInvoker;
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler SendCodeButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e) => SendCodeButtonClick?.Invoke(sender, e);

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);
    }
}
