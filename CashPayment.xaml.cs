using System.Windows;
using System.Windows.Controls;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for CashPayment.xaml
    /// </summary>
    public partial class CashPayment : UserControl
    {
        public CashPayment()
        {
            InitializeComponent();

            UCMakePaymentButton.ButtonResize += ButtonResizeInvoker;

            UCMakePaymentButton.ButtonClick += ButtonClickInvoker;
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler MakePaymentButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e) => MakePaymentButtonClick?.Invoke(sender, e);

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);
    }
}
