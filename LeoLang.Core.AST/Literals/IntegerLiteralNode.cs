namespace LeoLang.Core.AST
{
    public class IntegerLiteralNode : LiteralNode<int>
    {
        public IntegerLiteralNode(int value) : base(value)
        {
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}