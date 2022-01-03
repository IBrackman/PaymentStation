using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for ServicePaymentByPhoneNumber.xaml
    /// </summary>
    public partial class ServicePaymentByPhoneNumber : UserControl
    {
        public ServicePaymentByPhoneNumber()
        {
            InitializeComponent();

            UCIncorrectVerificationCode.Visibility = Visibility.Collapsed;

            UCScreenKeyboard.ButtonResize += ButtonResizeInvoker;
            UCScreenKeyboard.ButtonClick += ButtonClickInvoker;

            UCScreenKeyboardInput.ButtonResize += ButtonResizeInvoker;
            UCScreenKeyboardInput.ContinueButtonClick += ButtonClickInvoker;

            UCIncorrectVerificationCode.ButtonResize += ButtonResizeInvoker;
            UCIncorrectVerificationCode.SendCodeButtonClick += ButtonClickInvoker;
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler KeyboardButtonClick;

        public event RoutedEventHandler ContinueButtonClick;

        public event RoutedEventHandler SendCodeButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e)
        {
            var buttonClickHandlerDict = new Dictionary<string, RoutedEventHandler>
            {
                { nameof(KeyboardButtonClick), KeyboardButtonClick },
                { nameof(ContinueButtonClick), ContinueButtonClick },
                { nameof(SendCodeButtonClick), SendCodeButtonClick }
            };

            buttonClickHandlerDict[$"{((Button)sender).Tag}Click"]?.Invoke(sender, e);
        }

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);

        public string GetVerificationCode() => UCScreenKeyboardInput.GetVerificationCode();

        public void ChangeVerificationCode(ref string arg) => UCScreenKeyboardInput.ChangeVerificationCode(ref arg);

        public void CodeCorrectness(bool correctness) => UCIncorrectVerificationCode.Visibility = correctness ? Visibility.Collapsed : Visibility.Visible;
    }
}
