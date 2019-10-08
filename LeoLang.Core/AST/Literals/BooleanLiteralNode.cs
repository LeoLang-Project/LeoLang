namespace LeoLang.Core.AST
{
    public class BooleanLiteralNode : LiteralNode<bool>
    {
        public BooleanLiteralNode(bool value) : base(value)
        {
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}