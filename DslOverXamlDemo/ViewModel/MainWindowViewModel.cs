using DslOverXamlDemo.Contracts.Lib;

namespace DslOverXamlDemo.ViewModel
{
    public sealed class MainWindowViewModel : ChangeableEx
    {
        private DataStoreViewModel m_dataStore;

        public DataStoreViewModel DataStore
        {
            get { return m_dataStore ?? (m_dataStore = new DataStoreViewModel()); }
            set
            {
                if (m_dataStore != value)
                {
                    m_dataStore = value;
                    NotifyOfPropertyChange(() => DataStore);
                }
            }
        }

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
    }
}