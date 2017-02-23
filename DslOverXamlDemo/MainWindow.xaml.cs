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
    }
}
