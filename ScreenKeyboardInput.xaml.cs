using System.Windows;
using System.Windows.Controls;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for ScreenKeyboardInput.xaml
    /// </summary>
    public partial class ScreenKeyboardInput : UserControl
    {
        public ScreenKeyboardInput()
        {
            InitializeComponent();

            UCContinueButton.ButtonResize += ButtonResizeInvoker;
            UCContinueButton.ButtonClick += ButtonClickInvoker;
        }

        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler ContinueButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e) => ContinueButtonClick?.Invoke(sender, e);

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);

        public string GetVerificationCode() => textBox.Text;
        
        public void ChangeVerificationCode(ref string arg)
        {
            if (arg == "🞩")
            {
                if (textBox.Text.Length > 0) textBox.Text = textBox.Text[..^1];
            }
            else
                if (textBox.Text.Length < VerificationCodeMaxLength) textBox.Text += arg;
        }

        #region Properties

        public int VerificationCodeMaxLength
        {
            get => (int)GetValue(VerificationCodeMaxLengthProperty);
            set => SetValue(VerificationCodeMaxLengthProperty, value);
        }

        public static readonly DependencyProperty VerificationCodeMaxLengthProperty = DependencyProperty.Register("VerificationCodeMaxLength", typeof(int), typeof(ScreenKeyboardInput), new PropertyMetadata(PropertyChanged));

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            typeof(ScreenKeyboardInput).GetProperty(e.Property.Name)?.SetValue((ScreenKeyboardInput)d, e.NewValue);
        }

        #endregion
    }
}
