using System;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.ViewModel
{
    public sealed class OrderItemViewModel : ChangeableEx
    {
        public OrderItemViewModel(OrderItem model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public OrderItem Model { get; }

        public int Id => Model.Id;

        public int Quantity
        {
            get { return Model.Quantity; }
            set
            {
                if (Model.Quantity != value)
                {
                    Model.Quantity = value;
                    NotifyOfPropertyChange(() => Quantity);
                    NotifyOfPropertyChange(() => Total);
                    Changed();
                }
            }
        }

        public decimal Total => Model.Total;

        public int ProductId => Model.Product.Id;

        public string ProductName
        {
            get { return Model.Product.Name; }
            set
            {
                if (Model.Product.Name != value)
                {
                    Model.Product.Name = value;
                    NotifyOfPropertyChange(() => ProductName);
                    Changed();
                }
            }
        }

        public string ProductDescription
        {
            get { return Model.Product.Description; }
            set
            {
                if (Model.Product.Description != value)
                {
                    Model.Product.Description = value;
                    NotifyOfPropertyChange(() => ProductDescription);
                    Changed();
                }
            }
        }

        public ProductType ProductCategory
        {
            get { return Model.Product.Category; }
            set
            {
                if (Model.Product.Category != value)
                {
                    Model.Product.Category = value;
                    NotifyOfPropertyChange(() => ProductCategory);
                    Changed();
                }
            }
        }

        public decimal ProductPrice
        {
            get { return Model.Product.Price; }
            set
            {
                if (Model.Product.Price != value)
                {
                    Model.Product.Price = value;
                    NotifyOfPropertyChange(() => ProductPrice);
                    NotifyOfPropertyChange(() => Total);
                    Changed();
                }
            }
        }
    }
}