using System;
using System.Collections.Generic;
using DslOverXamlDemo.Engine.Utils;
using DslOverXamlDemo.Model;
using DslOverXamlDemo.Properties;

namespace DslOverXamlDemo.Samples
{
    public static class SampleDataStore
    {
        public static Order GetOrCreateOrder()
        {
            return Settings.Default.OrderData ?? CreateSampleOrder();
        }

        public static Order CreateSampleOrder()
        {
            return new Order
            {
                Id = IdGenerator.AutoInc(),
                Date = DateTime.Today,
                Name = "Demo Order",
                Customer = new Customer
                {
                    Id = IdGenerator.AutoInc(),
                    Name = "John Brown",
                    Age = 16,
                    Email = "john.brown@gmail.com"
                },
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = IdGenerator.AutoInc(),
                        Product = new Product
                        {
                            Id = IdGenerator.AutoInc(),
                            Category = ProductType.Electronics,
                            Name = "Cell Phone",
                            Description = "Smartphone",
                            Price = 150M
                        },
                        Quantity = 1
                    },
                    new OrderItem
                    {
                        Id = IdGenerator.AutoInc(),
                        Product = new Product
                        {
                            Id = IdGenerator.AutoInc(),
                            Category = ProductType.Clothing,
                            Name = "Shirt",
                            Description = "Men's Shirt",
                            Price = 25M
                        },
                        Quantity = 3
                    },
                    new OrderItem
                    {
                        Id = IdGenerator.AutoInc(),
                        Product = new Product
                        {
                            Id = IdGenerator.AutoInc(),
                            Category = ProductType.Clothing,
                            Name = "Socks",
                            Description = "Black Socks",
                            Price = 15M
                        },
                        Quantity = 2
                    }
                }
            };
        }
    }
}