using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DslOverXamlDemo.Rules.Controls
{
    public partial class EditableTextBoxControl : UserControl
    {
        public EditableTextBoxControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableTextBoxControl), new UIPropertyMetadata());

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty IsInEditModeProperty =
            DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(EditableTextBoxControl), new UIPropertyMetadata());

        public bool IsInEditMode
        {
            get { return (bool)GetValue(IsInEditModeProperty); }
            set { SetValue(IsInEditModeProperty, value); }
        }

        private void EditElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            var txt = e.Source as TextBox;
            if (txt != null)
            {
                txt.Focus();
                txt.SelectAll();
            }
        }

        private void EditElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Escape)
            {
                IsInEditMode = false;
                e.Handled = true;
            }
        }

        private void EditElement_OnLostFocus(object sender, RoutedEventArgs e)
        {
            IsInEditMode = false;
        }

        private void DisplayElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsInEditMode = true;
        }
    }
}
