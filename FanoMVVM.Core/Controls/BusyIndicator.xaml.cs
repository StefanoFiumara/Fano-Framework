using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace FanoMvvm.Controls
{
    [ContentProperty(nameof(BusyIndicator.Children))]
    public partial class BusyIndicator : UserControl
    {
        public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
            nameof(BusyIndicator.Children),  
            typeof(UIElementCollection),
            typeof(BusyIndicator),
            new PropertyMetadata());

        public UIElementCollection Children
        {
            get => (UIElementCollection)GetValue(BusyIndicator.ChildrenProperty.DependencyProperty);
            private set => SetValue(BusyIndicator.ChildrenProperty, value);
        }

        public BusyIndicator()
        {
            InitializeComponent();
            Children = this.ChildrenContainer.Children;
        }

        #region IsBusy Dependency Property

        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.RegisterAttached("IsBusy", typeof(bool), typeof(BusyIndicator));

        public bool IsBusy
        {
            get => (bool)GetValue(BusyIndicator.IsBusyProperty);
            set => SetValue(BusyIndicator.IsBusyProperty, value);
        }

        #endregion

        #region BusyText Dependency Property

        public static readonly DependencyProperty BusyTextProperty =
            DependencyProperty.RegisterAttached("BusyText", typeof(string), typeof(BusyIndicator), 
                new PropertyMetadata("Loading..."));

        public string BusyText
        {
            get => (string) GetValue(BusyIndicator.BusyTextProperty);
            set => SetValue(BusyIndicator.BusyTextProperty, value);
        }
        #endregion

        #region WheelColor Dependency Property

        public static readonly DependencyProperty WheelColorProperty =
            DependencyProperty.RegisterAttached("WheelColor", typeof(Color), typeof(BusyIndicator), new PropertyMetadata(Colors.Gold, BusyIndicator.OnWheelColorPropertyChanged));

        public Color WheelColor
        {
            get => (Color)GetValue(BusyIndicator.WheelColorProperty);
            set => SetValue(BusyIndicator.WheelColorProperty, value);
        }
        
        private static void OnWheelColorPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var owner = (BusyIndicator)dependencyObject;

            owner.SpinningWheel.CircleColor = (Color)e.NewValue;
        }

        #endregion
    }
}
