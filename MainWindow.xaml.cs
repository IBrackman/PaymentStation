using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UCBaseLayer.UCCashPayment.Visibility = Visibility.Collapsed;
            //UserControlMPVC.Visibility = Visibility.Collapsed;

            UCBaseLayer.BackButtonClick += UCBaseLayer_BackButtonClick;
            UCBaseLayer.HelpButtonClick += UCBaseLayer_HelpButtonClick;
            UCBaseLayer.MakePaymentButtonClick += UCBaseLayer_MakePaymentButtonClick;
            UCBaseLayer.ProfileSettingsButtonClick += UCBaseLayer_ProfileSettingsButtonClick;
            UCBaseLayer.SettingsButtonClick += UCBaseLayer_SettingsButtonClick;
            UCBaseLayer.InfoButtonClick += UCBaseLayer_InfoButtonClick;
            

            UCBaseLayer.ButtonResize += ButtonResize;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1:
                    UCBaseLayer.UCCashPayment.Visibility = Visibility.Visible;
                    //UserControlMPVC.Visibility = Visibility.Collapsed;
                    break;
                case Key.D2:
                    UCBaseLayer.UCCashPayment.Visibility = Visibility.Collapsed;
                    //UserControlMPVC.Visibility = Visibility.Visible;
                    break;
                case Key.Escape:
                    Application.Current.Shutdown();
                    break;
            }
        }

        private void UCBaseLayer_BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
        }

        private void UCBaseLayer_HelpButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
        }

        private void UCBaseLayer_MakePaymentButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
        }

        private void UCBaseLayer_ProfileSettingsButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
        }

        private void UCBaseLayer_SettingsButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
        }

        private void UCBaseLayer_InfoButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
        }

        private void ButtonResize(object sender, RoutedEventArgs e)
        {
            while (sender.GetType() != typeof(Viewbox))
            {
                var parent = ((FrameworkElement)sender).Parent;
                if (parent == null) return;
                sender = parent;
            }

            var elem = (Viewbox)sender;

            var sign = -1;

            if (e.RoutedEvent.Name == "PreviewMouseUp") sign = 1;

            var dw = 4.0 * sign;
            var dh = 4.0 * sign;

            if (elem.ActualWidth < elem.ActualHeight)
                dw *= Math.Sqrt(elem.ActualWidth / elem.ActualHeight);
            else if (elem.ActualWidth > elem.ActualHeight)
                dh *= Math.Sqrt(elem.ActualHeight / elem.ActualWidth);

            elem.Width += dw;
            elem.Height += dh;

            var margin = elem.Margin;

            elem.Margin = new Thickness(
                margin.Left - (dw / 2),
                margin.Top - (dh / 2),
                margin.Right - (dw / 2),
                margin.Bottom - (dh / 2));
        }
    }
}
