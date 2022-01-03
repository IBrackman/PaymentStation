using System.Windows;
using System.Windows.Controls;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for ScreenKeyboard.xaml
    /// </summary>
    public partial class ScreenKeyboard : UserControl
    {
        public ScreenKeyboard()
        {
            InitializeComponent();

            foreach (var child in ((Grid)Content).Children)
                if (child.GetType() == typeof(ComplexButton))
                {
                    ((ComplexButton)child).ButtonResize += ButtonResizeInvoker;
                    ((ComplexButton)child).ButtonClick += ButtonClickInvoker;
                }
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler ButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e) => ButtonClick?.Invoke(sender, e);

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);
    }
}
