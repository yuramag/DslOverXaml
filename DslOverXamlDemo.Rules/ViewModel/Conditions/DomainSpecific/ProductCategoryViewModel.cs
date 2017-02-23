using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ProductCategory), "Product Category")]
    public sealed class ProductCategoryViewModel : ConditionBaseViewModel<ProductCategory>
    {
        public ProductCategoryViewModel(ProductCategory model) : base(model)
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