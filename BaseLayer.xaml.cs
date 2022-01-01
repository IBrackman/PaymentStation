using System;
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

            UCMenu.ButtonResize += ButtonResizeInvoker;
            UCBack.ButtonResize += ButtonResizeInvoker;
            UCHelp.ButtonResize += ButtonResizeInvoker;
            UCCashPayment.ButtonResize += ButtonResizeInvoker;

            UCBack.BackButtonClick += ButtonClickInvoker;
            UCHelp.HelpButtonClick += ButtonClickInvoker;
            UCCashPayment.MakePaymentButtonClick += ButtonClickInvoker;
            UCMenu.ProfileSettingsButtonClick += ButtonClickInvoker;
            UCMenu.SettingsButtonClick += ButtonClickInvoker;
            UCMenu.InfoButtonClick += ButtonClickInvoker;
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler BackButtonClick;

        public event RoutedEventHandler HelpButtonClick;

        public event RoutedEventHandler MakePaymentButtonClick;

        public event RoutedEventHandler ProfileSettingsButtonClick;

        public event RoutedEventHandler SettingsButtonClick;

        public event RoutedEventHandler InfoButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "BackButton":
                    BackButtonClick?.Invoke(sender, e);
                    break;

                case "HelpButton":
                    HelpButtonClick?.Invoke(sender, e);
                    break;

                case "MakePaymentButton":
                    MakePaymentButtonClick?.Invoke(sender, e);
                    break;

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
