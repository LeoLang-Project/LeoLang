namespace LeoLang.Core.AST
{
    public class VariableDefinitionNode : SyntaxNode
    {
        public IdentifierNode ID { get; set; }
        public SyntaxNode Value { get; set; }

        public VariableDefinitionNode(IdentifierNode id, SyntaxNode val)
        {
            ID = id;
            Value = val;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}