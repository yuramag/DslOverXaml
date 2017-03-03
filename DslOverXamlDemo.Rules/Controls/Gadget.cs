using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DslOverXamlDemo.Rules.Controls
{
    public class Gadget : ContentControl
    {
        static Gadget()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Gadget), new FrameworkPropertyMetadata(typeof(Gadget)));
        }

        #region Command Property

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(Gadget),
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
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(Gadget),
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

        #region GadgetType Porperty

        public static readonly DependencyProperty GadgetTypeProperty =
            DependencyProperty.RegisterAttached("GadgetType", typeof(GadgetType), typeof(Gadget),
                new FrameworkPropertyMetadata(default(GadgetType)));

        public static GadgetType GetGadgetType(DependencyObject obj)
        {
            return (GadgetType) obj.GetValue(GadgetTypeProperty);
        }

        public static void SetGadgetType(DependencyObject obj, GadgetType value)
        {
            obj.SetValue(GadgetTypeProperty, value);
        }

        #endregion
    }
}
