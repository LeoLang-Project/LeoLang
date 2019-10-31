namespace LeoLang.Core.AST
{
    public class FieldDefinitionNode : SyntaxNode
    {
        public Symbol Modifier { get; set; }

        public Symbol Name { get; set; }

        public Symbol Type { get; set; }

        public SyntaxNode Value { get; set; }

        public FieldDefinitionNode(Symbol modifier, Symbol type, Symbol name, SyntaxNode value)
        {
            Modifier = modifier;
            Type = type;
            Name = name;
            Value = value;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}