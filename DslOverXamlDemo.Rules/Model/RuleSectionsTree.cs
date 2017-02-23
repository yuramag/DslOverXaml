using DslOverXamlDemo.Contracts.Lib;

namespace DslOverXamlDemo.Rules.Model
{
    public sealed class RuleSectionsTree : Tree<ModelType>
    {
        public RuleSectionsTree(ModelType data, params object[] items)
            : base(data, items)
        { }

        protected override ITree<ModelType> CloneNode(ITree<ModelType> item)
        {
            return new RuleSectionsTree(item.Data);
        }
    }
}