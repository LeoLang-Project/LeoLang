namespace LeoLang.Core.AST
{
    public class CharLiteralNode : LiteralNode
    {
        public char Value { get; set; }

        public CharLiteralNode(char value)
        {
            Value = value;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}