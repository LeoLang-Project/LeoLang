namespace LeoLang.Core.AST
{
    public class BooleanLiteralNode : LiteralNode
    {
        public bool Value { get; set; }

        public BooleanLiteralNode(bool value)
        {
            Value = value;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}