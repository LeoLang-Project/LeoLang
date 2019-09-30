namespace LeoLang.Core
{
    public abstract class SyntaxNode
    {
        public abstract void Accept(Visitor visitor);
    }
}