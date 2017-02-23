using System.ComponentModel;
using System.Windows;
using DslOverXamlDemo.ViewModel;

namespace DslOverXamlDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            ((MainWindowViewModel) DataContext).HandleClosing(e);
        }
    }
}
