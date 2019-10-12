namespace LeoLang.Core.AST
{
    public class CharLiteralNode : LiteralNode<char>
    {
        public CharLiteralNode(char value) : base(value)
        {
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}