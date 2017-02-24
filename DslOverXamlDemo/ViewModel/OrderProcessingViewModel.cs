using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Engine.OrderProcessing;
using DslOverXamlDemo.Engine.Utils;
using DslOverXamlDemo.Model;
using DslOverXamlDemo.Properties;
using DslOverXamlDemo.Samples;

namespace DslOverXamlDemo.ViewModel
{
    public sealed class OrderProcessingViewModel : ChangeableEx
    {
        public OrderProcessingViewModel()
        {
            Disposables.Add(EventAggregator.Instance.GetEventStream<ApplicationEvents.SettingsRefreshed>().Subscribe(x => Order = null));
        }

        private Order m_order;

        public Order Order
        {
            get { return m_order ?? (m_order = SampleDataStore.GetOrCreateSampleData().Order); }
            set
            {
                if (m_order != value)
                {
                    m_order = value;
                    NotifyOfPropertyChange(() => Order);
                }
            }
        }

        private decimal m_total;

        public decimal Total
        {
            get { return m_total; }
            set
            {
                if (m_total != value)
                {
                    m_total = value;
                    NotifyOfPropertyChange(() => Total);
                }
            }
        }

        private List<OrderDiscount> m_discounts;

        public List<OrderDiscount> Discounts
        {
            get { return m_discounts; }
            set
            {
                if (m_discounts != value)
                {
                    m_discounts = value;
                    NotifyOfPropertyChange(() => Discounts);
                }
            }
        }

        private ICommand m_processCommand;

        public ICommand ProcessCommand => m_processCommand ?? (m_processCommand = new RelayCommand(ProcessOrderAsync));

        public async Task ProcessOrderAsync()
        {
            var rule = RuleBuilder.CreateRuleImp(Settings.Default.SampleRuleXaml);
            if (rule == null)
                throw new InvalidOperationException("Rule object is not defined.");
            var context = new OrderDiscountContext(Order);
            await context.ExecuteAsync(rule);
            Discounts = context.GetOrderDiscounts();
            Total = DiscountLogic.GetOrderTotalAmount(Order, Discounts);
        }
    }
}