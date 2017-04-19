using System.ComponentModel;
using System.Windows;
using DslOverXamlDemo.Contracts.Lib;

namespace DslOverXamlDemo.ViewModel
{
    public sealed class MainWindowViewModel : ChangeableEx
    {
        private LoggingViewModel m_logging;

        public LoggingViewModel Logging
        {
            get { return m_logging ?? (m_logging = new LoggingViewModel()); }
            set
            {
                if (m_logging != value)
                {
                    m_logging = value;
                    NotifyOfPropertyChange(() => Logging);
                }
            }
        }

        private SampleRuleViewModel m_sampleRule;

        public SampleRuleViewModel SampleRule
        {
            get { return m_sampleRule ?? (m_sampleRule = new SampleRuleViewModel()); }
            set
            {
                if (m_sampleRule != value)
                {
                    m_sampleRule = value;
                    NotifyOfPropertyChange(() => SampleRule);
                }
            }
        }

        private OrderProcessingViewModel m_orderProcessing;

        public OrderProcessingViewModel OrderProcessing
        {
            get { return m_orderProcessing ?? (m_orderProcessing = new OrderProcessingViewModel()); }
            set
            {
                if (m_orderProcessing != value)
                {
                    m_orderProcessing = value;
                    NotifyOfPropertyChange(() => OrderProcessing);
                }
            }
        }

        public void HandleClosing(CancelEventArgs args)
        {
            if (OrderProcessing.IsModified)
            {
                switch (MessageBox.Show("Save changes to the Sample Data?", "Saving changes", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                {
                    case MessageBoxResult.Cancel:
                        args.Cancel = true;
                        return;
                    case MessageBoxResult.Yes:
                        OrderProcessing.Save();
                        break;
                }
            }

            if (SampleRule.IsModified)
            {
                switch (MessageBox.Show("Save changes to the Sample Rule?", "Saving changes", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                {
                    case MessageBoxResult.Cancel:
                        args.Cancel = true;
                        return;
                    case MessageBoxResult.Yes:
                        SampleRule.Save();
                        break;
                }
            }
        }
    }
}