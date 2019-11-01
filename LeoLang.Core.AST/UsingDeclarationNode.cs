namespace LeoLang.Core.AST
{
    public class UsingDeclarationNode : SyntaxNode
    {
        public Symbol Ns { get; set; }

        public UsingDeclarationNode(Symbol ns)
        {
            Ns = ns;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}