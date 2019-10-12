namespace LeoLang.Core.AST
{
    public class NumberLiteralNode : LiteralNode<int>
    {
        public NumberLiteralNode(int value) : base(value)
        {
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}