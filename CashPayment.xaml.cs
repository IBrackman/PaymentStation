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

            MakePaymentButton.PreviewMouseDown += ButtonResizeInvoker;
            MakePaymentButton.PreviewMouseUp += ButtonResizeInvoker;

            MakePaymentButton.Click += MakePaymentButtonClickInvoker;
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler MakePaymentButtonClick;

        private void MakePaymentButtonClickInvoker(object sender, RoutedEventArgs e) => MakePaymentButtonClick?.Invoke(sender, e);

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);
    }
}
