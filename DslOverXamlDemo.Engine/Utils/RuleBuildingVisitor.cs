using System.Linq;
using DslOverXamlDemo.Engine.Parts;
using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Engine.Utils
{
    public sealed class RuleBuildingVisitor : RuleVisitor<RuleImp, ConditionImp, ValueImp>
    {
        #region Visit Rule

        protected override RuleImp VisitRuleElement(EmptyRule info)
        {
            return new EmptyRuleImp
            {
                Name = info.Name
            };
        }

        protected override RuleImp VisitRuleElement(ConditionRule info)
        {
            return new ConditionRuleImp
            {
                Name = info.Name,
                Condition = Visit(info.Condition),
                Rule = Visit(info.Rule)
            };
        }

        protected override RuleImp VisitRuleElement(RuleSet info)
        {
            return new RuleSetImp
            {
                Name = info.Name,
                Rules = info.Rules.Select(Visit).ToList()
            };
        }

        protected override RuleImp VisitRuleElement(ApplyAbsoluteDiscount info)
        {
            return new ApplyAbsoluteDiscountImp
            {
                Name = info.Name,
                Value = Visit(info.Value)
            };
        }

        protected override RuleImp VisitRuleElement(ApplyAdditiveDiscount info)
        {
            return new ApplyAdditiveDiscountImp
            {
                Name = info.Name,
                Value = Visit(info.Value)
            };
        }

        protected override RuleImp VisitRuleElement(ApplyMultiplicativeDiscount info)
        {
            return new ApplyMultiplicativeDiscountImp
            {
                Name = info.Name,
                Value = Visit(info.Value)
            };
        }

        protected override RuleImp VisitRuleElement(ApplyPercentDiscount info)
        {
            return new ApplyPercentDiscountImp
            {
                Name = info.Name,
                Value = Visit(info.Value)
            };
        }

        #endregion

        #region Visit Conditions

        protected override ConditionImp VisitConditionElement(AllMatch info)
        {
            return new AllMatchImp
            {
                Conditions = info.Conditions.Select(Visit).ToList()
            };
        }

        protected override ConditionImp VisitConditionElement(AnyMatch info)
        {
            return new AnyMatchImp
            {
                Conditions = info.Conditions.Select(Visit).ToList()
            };
        }

        protected override ConditionImp VisitConditionElement(True info)
        {
            return new TrueImp();
        }

        protected override ConditionImp VisitConditionElement(False info)
        {
            return new FalseImp();
        }

        protected override ConditionImp VisitConditionElement(Not info)
        {
            return new NotImp
            {
                Condition = Visit(info.Condition)
            };
        }

        protected override ConditionImp VisitConditionElement(CustomerAge info)
        {
            return new CustomerAgeImp
            {
                From = info.From,
                To = info.To
            };
        }

        protected override ConditionImp VisitConditionElement(OrderDate info)
        {
            return new OrderDateImp
            {
                From = info.From,
                To = info.To
            };
        }

        protected override ConditionImp VisitConditionElement(OrderItemsCount info)
        {
            return new OrderItemsCountImp
            {
                From = info.From,
                To = info.To
            };
        }

        protected override ConditionImp VisitConditionElement(ProductPrice info)
        {
            return new ProductPriceImp
            {
                From = info.From,
                To = info.To
            };
        }

        protected override ConditionImp VisitConditionElement(ProductQuantity info)
        {
            return new ProductQuantityImp
            {
                From = info.From,
                To = info.To
            };
        }

        protected override ConditionImp VisitConditionElement(ProductCategory info)
        {
            return new ProductCategoryImp
            {
                Value = info.Value
            };
        }

        #endregion

        #region Visit Value

        protected override ValueImp VisitValueElement(Constant info)
        {
            return new ConstantImp
            {
                Value = info.Value
            };
        }

        protected override ValueImp VisitValueElement(ProductClearancePercent info)
        {
            return new ProductClearancePercentImp
            {
                DefaultValue = Visit(info.DefaultValue)
            };
        }

        protected override ValueImp VisitValueElement(ProductTodaysPrice info)
        {
            return new ProductTodaysPriceImp
            {
                DefaultValue = Visit(info.DefaultValue)
            };
        }

        #endregion
    }
}