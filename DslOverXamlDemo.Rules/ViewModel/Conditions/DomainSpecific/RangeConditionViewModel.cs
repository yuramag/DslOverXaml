using System.Collections.Generic;
using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Rules.ViewModel
{
    public abstract class RangeConditionViewModel<T, TRange> : ConditionBaseViewModel<T> where TRange : struct where T : RangeCondition<TRange>
    {
        public RangeConditionViewModel(T model) : base(model)
        {
        }

        public TRange? From
        {
            get { return Model.From; }
            set
            {
                if (!EqualityComparer<TRange?>.Default.Equals(Model.From, value))
                {
                    Model.From = value;
                    NotifyOfPropertyChange(() => From);
                    Changed();
                }
            }
        }

        public TRange? To
        {
            get { return Model.To; }
            set
            {
                if (!EqualityComparer<TRange?>.Default.Equals(Model.To, value))
                {
                    Model.To = value;
                    NotifyOfPropertyChange(() => To);
                    Changed();
                }
            }
        }
    }
}