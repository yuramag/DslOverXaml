using System.Windows;
using System.Windows.Controls;

namespace DslOverXamlDemo.Rules.Controls
{
    public class Gadget : ContentControl
    {
        static Gadget()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Gadget), new FrameworkPropertyMetadata(typeof(Gadget)));
        }
    }
}
