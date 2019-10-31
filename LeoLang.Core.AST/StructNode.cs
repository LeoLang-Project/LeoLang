namespace LeoLang.Core.AST
{
    public class StructNode : SyntaxNode
    {
        public BlockNode Body { get; set; }

        public Symbol Modifier { get; set; }

        public Symbol Name { get; set; }

        public StructNode(Symbol modifier, Symbol name, BlockNode body)
        {
            Modifier = modifier;
            Name = name;
            Body = body;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}