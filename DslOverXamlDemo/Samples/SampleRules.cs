using System;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Model;
using DslOverXamlDemo.Properties;

namespace DslOverXamlDemo.Samples
{
    public static class SampleRules
    {
        public static Rule GetOrCreateSampleRule()
        {
            return Settings.Default.SampleRule ?? CreateSampleRule();
        }

        public static Rule CreateSampleRule()
        {
            return new RuleSet
            {
                Rules =
                {
                    new ConditionRule
                    {
                        Condition = new ProductCategory
                        {
                            Value = ProductType.Electronics.ToString()
                        },
                        Rule = new ApplyAdditiveDiscount
                        {
                            Value = new Constant
                            {
                                Value = "50"
                            }
                        }
                    },
                    new ConditionRule
                    {
                        Condition = new AllMatch
                        {
                            Conditions =
                            {
                                new CustomerAge
                                {
                                    From = 12,
                                    To = 18
                                },
                                new ProductQuantity
                                {
                                    From = 3
                                }
                            }
                        },
                        Rule = new ApplyPercentDiscount
                        {
                            Value = new ProductClearancePercent
                            {
                                DefaultValue = new Constant
                                {
                                    Value = "50"
                                }
                            }
                        }
                    },
                    new ConditionRule
                    {
                        Condition = new AnyMatch
                        {
                            Conditions =
                            {
                                new OrderItemsCount
                                {
                                    From = 10,
                                    To = 50
                                },
                                new AllMatch
                                {
                                    Conditions =
                                    {
                                        new OrderDate
                                        {
                                            From = new DateTime(2017, 1, 1),
                                            To = new DateTime(2017, 6, 30)
                                        },
                                        new ProductCategory
                                        {
                                            Value = ProductType.Clothing.ToString()
                                        }
                                    }
                                }
                            }
                        },
                        Rule = new ApplyMultiplicativeDiscount
                        {
                            Value = new Constant
                            {
                                Value = "0.75"
                            }
                        }
                    }
                }
            };
        }
    }
}