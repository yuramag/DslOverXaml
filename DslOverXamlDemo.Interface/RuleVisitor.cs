using System;

namespace DslOverXamlDemo.Interface
{
    public abstract class RuleVisitor<TR, TC, TV> :
        IVisitor<Rule, TR>,
        IVisitor<Condition, TC>,
        IVisitor<Value, TV>
    {
        #region Dynamic Visitors

        public TR Visit(Rule info)
        {
            return info == null ? default(TR) : VisitRuleElement((dynamic) info);
        }

        public TC Visit(Condition info)
        {
            return info == null ? default(TC) : VisitConditionElement((dynamic) info);
        }

        public TV Visit(Value info)
        {
            return info == null ? default(TV) : VisitValueElement((dynamic) info);
        }

        #endregion

        #region Rule Visitors

        protected virtual TR VisitRuleElement(EmptyRule info)
        {
            throw new NotSupportedException();
        }

        protected virtual TR VisitRuleElement(ConditionRule info)
        {
            throw new NotSupportedException();
        }

        protected virtual TR VisitRuleElement(RuleSet info)
        {
            throw new NotSupportedException();
        }

        protected virtual TR VisitRuleElement(ApplyAbsoluteDiscount info)
        {
            throw new NotSupportedException();
        }

        protected virtual TR VisitRuleElement(ApplyAdditiveDiscount info)
        {
            throw new NotSupportedException();
        }

        protected virtual TR VisitRuleElement(ApplyMultiplicativeDiscount info)
        {
            throw new NotSupportedException();
        }

        protected virtual TR VisitRuleElement(ApplyPercentDiscount info)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Condition Visitors

        protected virtual TC VisitConditionElement(AllMatch info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(AnyMatch info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(True info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(False info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(Not info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(CustomerAge info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(OrderDate info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(OrderItemsCount info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(ProductPrice info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(ProductQuantity info)
        {
            throw new NotSupportedException();
        }

        protected virtual TC VisitConditionElement(ProductCategory info)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Value Visitors

        protected virtual TV VisitValueElement(Constant info)
        {
            throw new NotSupportedException();
        }

        protected virtual TV VisitValueElement(ProductClearancePercent info)
        {
            throw new NotSupportedException();
        }

        protected virtual TV VisitValueElement(ProductTodaysPrice info)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}