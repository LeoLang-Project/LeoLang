namespace LeoLang.Core.AST
{
    public class DecimalLiteralNode : LiteralNode<double>
    {
        public DecimalLiteralNode(double value) : base(value)
        {
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}