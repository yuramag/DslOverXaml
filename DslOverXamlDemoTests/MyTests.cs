using System;
using System.Diagnostics;
using System.Xml.Linq;
using DslOverXamlDemo.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DslOverXamlDemoTests
{
    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void Test1()
        {
            var rule = new ConditionRule
            {
                Condition = new AllMatch
                {
                    Conditions = 
                    {
                        new CustomerAge {From = 10},
                        new False(),
                        new ProductQuantity {To = 50},
                        new OrderDate {From = DateTime.Today}
                    }
                }
            };

            var xaml = SimpleXamlSerializer.ToXaml(rule);
            Debug.Print(XElement.Parse(xaml).ToString());
        }
    }
}