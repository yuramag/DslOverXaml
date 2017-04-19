using System;
using System.Collections.ObjectModel;
using System.Linq;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.ViewModel
{
    public sealed class OrderViewModel : ChangeableEx
    {
        public OrderViewModel(Order model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public Order Model { get; }

        public int Id => Model.Id;

        public string Name
        {
            get { return Model.Name; }
            set
            {
                if (Model.Name != value)
                {
                    Model.Name = value;
                    NotifyOfPropertyChange(() => Name);
                    Changed();
                }
            }
        }

        public DateTime Date
        {
            get { return Model.Date; }
            set
            {
                if (Model.Date != value)
                {
                    Model.Date = value;
                    NotifyOfPropertyChange(() => Date);
                    Changed();
                }
            }
        }

        public int CustomerId => Model.Customer.Id;

        public string CustomerName
        {
            get { return Model.Customer.Name; }
            set
            {
                if (Model.Customer.Name != value)
                {
                    Model.Customer.Name = value;
                    NotifyOfPropertyChange(() => CustomerName);
                    Changed();
                }
            }
        }

        public int CustomerAge
        {
            get { return Model.Customer.Age; }
            set
            {
                if (Model.Customer.Age != value)
                {
                    Model.Customer.Age = value;
                    NotifyOfPropertyChange(() => CustomerAge);
                    Changed();
                }
            }
        }

        public string CustomerEmail
        {
            get { return Model.Customer.Email; }
            set
            {
                if (Model.Customer.Email != value)
                {
                    Model.Customer.Email = value;
                    NotifyOfPropertyChange(() => CustomerEmail);
                    Changed();
                }
            }
        }

        private ObservableCollection<OrderItemViewModel> m_items;

        public ObservableCollection<OrderItemViewModel> Items
        {
            get
            {
                if (m_items == null)
                {
                    m_items = new ObservableCollection<OrderItemViewModel>(Model.Items.Select(x =>
                    {
                        var item = new OrderItemViewModel(x);
                        item.OnModified += (sender, args) => Changed();
                        return item;
                    }));
                }
                return m_items;
            }
        }
    }
}