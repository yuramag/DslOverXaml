using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DslOverXamlDemo.Rules.View
{
    public static class SuperProperties
    {
        #region Command Property

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(SuperProperties),
                new FrameworkPropertyMetadata(default(ICommand), FrameworkPropertyMetadataOptions.Inherits));

        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand) obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        #endregion

        #region CommandParameter Property

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(SuperProperties),
                new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.Inherits));

        public static object GetCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        #endregion

        #region BorderBrush Porperty

        public static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.RegisterAttached("BorderBrush", typeof(Brush), typeof(SuperProperties),
                new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.Inherits));

        public static object GetBorderBrush(DependencyObject obj)
        {
            return obj.GetValue(BorderBrushProperty);
        }

        public static void SetBorderBrush(DependencyObject obj, object value)
        {
            obj.SetValue(BorderBrushProperty, value);
        }

        #endregion

        #region TitleBrush Porperty

        public static readonly DependencyProperty TitleBrushProperty =
            DependencyProperty.RegisterAttached("TitleBrush", typeof(Brush), typeof(SuperProperties),
                new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.Inherits));

        public static object GetTitleBrush(DependencyObject obj)
        {
            return obj.GetValue(TitleBrushProperty);
        }

        public static void SetTitleBrush(DependencyObject obj, object value)
        {
            obj.SetValue(TitleBrushProperty, value);
        }

        #endregion
    }
}