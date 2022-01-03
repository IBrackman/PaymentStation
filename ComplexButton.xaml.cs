using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaymentStation
{
    /// <summary>
    /// Interaction logic for KeyboardButton.xaml
    /// </summary>
    public partial class ComplexButton : UserControl
    {
        public ComplexButton()
        {
            InitializeComponent();

            button.PreviewMouseDown += ButtonResizeInvoker;
            button.PreviewMouseUp += ButtonResizeInvoker;

            button.Click += ButtonClickInvoker;
        }
        
        public event RoutedEventHandler ButtonResize;

        public event RoutedEventHandler ButtonClick;

        private void ButtonClickInvoker(object sender, RoutedEventArgs e) => ButtonClick?.Invoke(sender, e);

        private void ButtonResizeInvoker(object sender, RoutedEventArgs e) => ButtonResize?.Invoke(sender, e);

        #region Properties
        public string ButtonText
        {
            get => (string)GetValue(ButtonTextProperty);
            set
            {
                SetValue(ButtonTextProperty, value);
                textBlock.Text = value;
            }
        }

        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public double ButtonFontSize
        {
            get => (double)GetValue(ButtonFontSizeProperty);
            set
            {
                SetValue(ButtonFontSizeProperty, value);
                textBlock.FontSize = value;
            }
        }

        public static readonly DependencyProperty ButtonFontSizeProperty =
            DependencyProperty.Register("ButtonFontSize", typeof(double), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public FontWeight ButtonFontWeight
        {
            get => (FontWeight)GetValue(ButtonFontWeightProperty);
            set
            {
                SetValue(ButtonFontWeightProperty, value);
                textBlock.FontWeight = value;
            }
        }

        public static readonly DependencyProperty ButtonFontWeightProperty =
            DependencyProperty.Register("ButtonFontWeight", typeof(FontWeight), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public string ButtonSize
        {
            get => (string)GetValue(ButtonSizeProperty);
            set
            {
                SetValue(ButtonSizeProperty, value);

                var val = value.Split(", ");

                var width = Convert.ToDouble(val[0]);
                var height = Convert.ToDouble(val[1]);

                if (ButtonText != null && ButtonImageSource != null)
                {
                    if (ButtonOrietation == "Horizontal")
                    {
                        label.Height = height;
                        image.Height = height;
                    }
                    else
                    {
                        label.Width = width;
                        image.Width = width;
                    }
                }
                else if (ButtonText != null)
                {
                    label.Width = width;
                    label.Height = height;
                    image.Visibility = Visibility.Collapsed;
                }
                else if (ButtonImageSource != null)
                {
                    image.Width = width;
                    image.Height = height;
                    label.Visibility = Visibility.Collapsed;
                }

                viewbox.Width = width;
                viewbox.Height = height;
            }
        }

        public static readonly DependencyProperty ButtonSizeProperty =
            DependencyProperty.Register("ButtonSize", typeof(string), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));


        public Brush ButtonBackground
        {
            get => (Brush)GetValue(ButtonBackgroundProperty);
            set
            {
                SetValue(ButtonBackgroundProperty, value);
                border.Background = value;
            }
        }

        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public Brush ButtonForeground
        {
            get => (Brush)GetValue(ButtonForegroundProperty);
            set
            {
                SetValue(ButtonForegroundProperty, value);
                textBlock.Foreground = value;
            }
        }

        public static readonly DependencyProperty ButtonForegroundProperty =
            DependencyProperty.Register("ButtonForeground", typeof(Brush), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public Brush ButtonBorderBrush
        {
            get => (Brush)GetValue(ButtonBorderBrushProperty);
            set
            {
                SetValue(ButtonBorderBrushProperty, value);
                border.BorderBrush = value;
            }
        }

        public static readonly DependencyProperty ButtonBorderBrushProperty =
            DependencyProperty.Register("ButtonBorderBrush", typeof(Brush), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public CornerRadius ButtonCornerRadius
        {
            get => (CornerRadius)GetValue(ButtonCornerRadiusProperty);
            set
            {
                SetValue(ButtonCornerRadiusProperty, value);
                border.CornerRadius = value;
            }
        }

        public static readonly DependencyProperty ButtonCornerRadiusProperty =
            DependencyProperty.Register("ButtonCornerRadius", typeof(CornerRadius), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public Thickness ButtonBorderThickness
        {
            get => (Thickness)GetValue(ButtonBorderThicknessProperty);
            set
            {
                SetValue(ButtonBorderThicknessProperty, value);
                border.BorderThickness = value;
            }
        }

        public static readonly DependencyProperty ButtonBorderThicknessProperty =
            DependencyProperty.Register("ButtonBorderThickness", typeof(Thickness), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public string ButtonOrietation
        {
            get => (string)GetValue(ButtonOrietationProperty);
            set
            {
                SetValue(ButtonOrietationProperty, value);
                stackPanel.Orientation = value == "Horizontal" ? Orientation.Horizontal: Orientation.Vertical;
            }
        }

        public static readonly DependencyProperty ButtonOrietationProperty =
            DependencyProperty.Register("ButtonOrietation", typeof(string), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public ImageSource ButtonImageSource
        {
            get => (ImageSource)GetValue(ButtonImageSourceProperty);
            set
            {
                SetValue(ButtonImageSourceProperty, value);
                image.Source = value;
            }
        }

        public static readonly DependencyProperty ButtonImageSourceProperty =
            DependencyProperty.Register("ButtonImageSource", typeof(ImageSource), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public object ButtonTag
        {
            get => GetValue(ButtonTagProperty);
            set
            {
                SetValue(ButtonTagProperty, value);
                button.Tag = value;
            }
        }

        public static readonly DependencyProperty ButtonTagProperty =
            DependencyProperty.Register("ButtonTag", typeof(object), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));

        public TextWrapping ButtonTextWrapping
        {
            get => (TextWrapping)GetValue(ButtonTextWrappingProperty);
            set
            {
                SetValue(ButtonTextWrappingProperty, value);
                textBlock.TextWrapping = value;
            }
        }

        public static readonly DependencyProperty ButtonTextWrappingProperty =
            DependencyProperty.Register("ButtonTextWrapping", typeof(TextWrapping), typeof(ComplexButton), new PropertyMetadata(PropertyChanged));


        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            typeof(ComplexButton).GetProperty(e.Property.Name)?.SetValue((ComplexButton)d, e.NewValue);
        }

        #endregion
    }
}
