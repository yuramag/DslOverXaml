using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Markup;

namespace DslOverXamlDemo.Interface
{
    #region Rule

    public abstract class Rule
    {
        [DefaultValue(default(string))]
        public string Name { get; set; }
    }

    public sealed class EmptyRule : Rule
    {
    }

    [ContentProperty("Rule")]
    [DefaultProperty("Rule")]
    public sealed class ConditionRule : Rule
    {
        [DefaultValue(default(Condition))]
        public Condition Condition { get; set; }

        [DefaultValue(default(Rule))]
        public Rule Rule { get; set; }
    }

    [ContentProperty("Rules")]
    [DefaultProperty("Rules")]
    public sealed class RuleSet : Rule
    {
        public RuleSet() : this(null)
        {
        }

        public RuleSet(IList<Rule> rules)
        {
            Rules = rules ?? new List<Rule>();
        }

        [DefaultValue(default(IList<Rule>))]
        public IList<Rule> Rules { get; private set; }
    }

    [ContentProperty("Value")]
    [DefaultProperty("Value")]
    public abstract class ValueBasedRule : Rule
    {
        [DefaultValue(default(Value))]
        public Value Value { get; set; }
    }

    public sealed class ApplyAbsoluteDiscount : ValueBasedRule
    {
    }

    public sealed class ApplyAdditiveDiscount : ValueBasedRule
    {
    }

    public sealed class ApplyMultiplicativeDiscount : ValueBasedRule
    {
    }

    public sealed class ApplyPercentDiscount : ValueBasedRule
    {
    }

    #endregion

    #region Conditions

    public abstract class Condition
    {
    }

    [ContentProperty("Conditions")]
    [DefaultProperty("Conditions")]
    public abstract class ConditionSet : Condition
    {
        public ConditionSet() : this(null)
        {
        }

        public ConditionSet(IList<Condition> conditions)
        {
            Conditions = conditions ?? new List<Condition>();
        }

        [DefaultValue(default(IList<Condition>))]
        public IList<Condition> Conditions { get; private set; }
    }

    public sealed class AllMatch : ConditionSet
    {
    }

    public sealed class AnyMatch : ConditionSet
    {
    }

    public sealed class True : Condition
    {
    }

    public sealed class False : Condition
    {
    }

    [ContentProperty("Condition")]
    [DefaultProperty("Condition")]
    public sealed class Not : Condition
    {
        [DefaultValue(default(Condition))]
        public Condition Condition { get; set; }
    }

    public abstract class RangeCondition<T> : Condition where T : struct
    {
        [DefaultValue(null)]
        public T? From { get; set; }

        [DefaultValue(null)]
        public T? To { get; set; }
    }

    public sealed class CustomerAge : RangeCondition<int>
    {
    }

    public sealed class OrderDate : RangeCondition<DateTime>
    {
    }

    public sealed class OrderItemsCount : RangeCondition<int>
    {
    }

    public sealed class ProductPrice : RangeCondition<decimal>
    {
    }

    public sealed class ProductQuantity : RangeCondition<int>
    {
    }

    public sealed class ProductCategory : Condition
    {
        [DefaultValue(default(string))]
        public string Value { get; set; }
    }

    #endregion

    #region Values

    public abstract class Value
    {
    }

    public sealed class Constant : Value
    {
        public string Value { get; set; }
    }

    [ContentProperty("DefaultValue")]
    [DefaultProperty("DefaultValue")]
    public sealed class ProductClearancePercent : Value
    {
        [DefaultValue(default(Value))]
        public Value DefaultValue { get; set; }
    }

    [ContentProperty("DefaultValue")]
    [DefaultProperty("DefaultValue")]
    public sealed class ProductTodaysPrice : Value
    {
        [DefaultValue(default(Value))]
        public Value DefaultValue { get; set; }
    }

    #endregion
}