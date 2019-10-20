namespace LeoLang.Core.AST
{
    public class SymbolNode : SyntaxNode
    {
        public Symbol Symbol { get; set; }

        public SymbolNode(Symbol symbol)
        {
            Symbol = symbol;
        }

        public static implicit operator Symbol(SymbolNode n)
        {
            return n.Symbol;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(Symbol);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }
    }
}