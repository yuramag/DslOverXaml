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
            SaveCommand = new RelayCommand(() => Save(), () => IsModified);
            LoadDefaultCommand = new RelayCommand(() => LoadDefault());
            ProcessCommand = new RelayCommand(ProcessOrderAsync);
        }

        private OrderViewModel m_order;

        public OrderViewModel Order
        {
            get
            {
                if (m_order == null)
                {
                    m_order = new OrderViewModel(SampleDataStore.GetOrCreateOrder());
                    m_order.OnModified += (sender, args) => Changed();
                }
                return m_order;
            }
            set
            {
                if (m_order != value)
                {
                    m_order = value;
                    NotifyOfPropertyChange(() => Order);
                    Changed();
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

        public ICommand SaveCommand { get; }
        public ICommand LoadDefaultCommand { get; }
        public ICommand ProcessCommand { get; }

        public void Save()
        {
            Settings.Default.OrderData = Order.Model;
            Settings.Default.Save();
            IsModified = false;
            LogInfo("Data model has been saved successfully.");
            EventAggregator.Instance.Publish(new ApplicationEvents.SettingsRefreshed());
        }

        public void LoadDefault()
        {
            Settings.Default.OrderData = null;
            Order = null;
            LogInfo("Loaded default sample order.");
        }

        public async Task ProcessOrderAsync()
        {
            var rule = RuleBuilder.CreateRuleImp(SampleRules.GetOrCreateSampleRule());
            if (rule == null)
                throw new InvalidOperationException("Rule object is not defined.");
            var context = new OrderDiscountContext(Order.Model);
            await context.ExecuteAsync(rule);
            Discounts = context.GetOrderDiscounts();
            Total = DiscountLogic.GetOrderTotalAmount(Order.Model, Discounts);
            LogInfo("Order has been processed successfully.");
        }
    }
}