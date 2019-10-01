namespace LeoLang.Core
{
    public class LiteralNode : SyntaxNode
    {
        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}