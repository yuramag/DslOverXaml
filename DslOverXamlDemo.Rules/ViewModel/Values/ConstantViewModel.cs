using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(Constant), "Constant")]
    public sealed class ConstantViewModel : ValueBaseViewModel<Constant>
    {
        public ConstantViewModel(Constant model) : base(model)
        {
        }

        public string Value
        {
            get { return Model.Value; }
            set
            {
                if (Model.Value != value)
                {
                    Model.Value = value;
                    NotifyOfPropertyChange(() => Value);
                    Changed();
                }
            }
        }
    }
}