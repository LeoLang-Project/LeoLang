namespace LeoLang.Core
{
    public abstract class LiteralNode<T> : SyntaxNode
    {
        public T Value { get; set; }

        public abstract override void Accept(Visitor visitor);

        protected LiteralNode(T value)
        {
            Value = value;
        }
    }
}