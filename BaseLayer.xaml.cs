using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for BaseLayer.xaml
    /// </summary>
    public partial class BaseLayer : UserControl
    {
        public BaseLayer()
        {
            InitializeComponent();

            UCBackButton.ButtonResize += ButtonResizeInvoker;
            UCHelpButton.ButtonResize += ButtonResizeInvoker;
            UCCashPayment.ButtonResize += ButtonResizeInvoker;
            UCMenu.ButtonResize += ButtonResizeInvoker;
            UCServicePaymentByPhoneNumber.ButtonResize += ButtonResizeInvoker;

            UCBackButton.ButtonClick += ButtonClickInvoker;
            UCHelpButton.ButtonClick += ButtonClickInvoker;
            UCCashPayment.MakePaymentButtonClick += ButtonClickInvoker;
            UCMenu.ProfileSettingsButtonClick += ButtonClickInvoker;
            UCMenu.SettingsButtonClick += ButtonClickInvoker;
            UCMenu.InfoButtonClick += ButtonClickInvoker;
            UCServicePaymentByPhoneNumber.KeyboardButtonClick += ButtonClickInvoker;
            UCServicePaymentByPhoneNumber.ContinueButtonClick += ButtonClickInvoker;
            UCServicePaymentByPhoneNumber.SendCodeButtonClick += ButtonClickInvoker;

        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler BackButtonClick;

        public event RoutedEventHandler HelpButtonClick;

        public event RoutedEventHandler MakePaymentButtonClick;

        public event RoutedEventHandler ProfileSettingsButtonClick;

        public event RoutedEventHandler SettingsButtonClick;

        public event RoutedEventHandler InfoButtonClick;

        public event RoutedEventHandler KeyboardButtonClick;

        public event RoutedEventHandler ContinueButtonClick;

        public event RoutedEventHandler SendCodeButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e)
        {
            var buttonClickHandlerDict = new Dictionary<string, RoutedEventHandler>
            {
                { nameof(BackButtonClick), BackButtonClick },
                { nameof(HelpButtonClick), HelpButtonClick },
                { nameof(MakePaymentButtonClick), MakePaymentButtonClick },
                { nameof(ProfileSettingsButtonClick), ProfileSettingsButtonClick },
                { nameof(SettingsButtonClick), SettingsButtonClick },
                { nameof(InfoButtonClick), InfoButtonClick },
                { nameof(KeyboardButtonClick), KeyboardButtonClick },
                { nameof(ContinueButtonClick), ContinueButtonClick },
                { nameof(SendCodeButtonClick), SendCodeButtonClick }
            };

            buttonClickHandlerDict[$"{((Button)sender).Tag}Click"]?.Invoke(sender, e);
        }

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);

        public string GetVerificationCode() => UCServicePaymentByPhoneNumber.GetVerificationCode();

        public void ChangeVerificationCode(ref string arg) => UCServicePaymentByPhoneNumber.ChangeVerificationCode(ref arg);

        public void CodeCorrectness(bool correctness) => UCServicePaymentByPhoneNumber.CodeCorrectness(correctness);
    }
}
