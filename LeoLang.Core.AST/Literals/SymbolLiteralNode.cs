namespace LeoLang.Core.AST.Literals
{
    public class SymbolLiteralNode : LiteralNode<Symbol>
    {
        public SymbolLiteralNode(Symbol value) : base(value)
        {
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}