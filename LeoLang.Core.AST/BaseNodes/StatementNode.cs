using LeoLang.Core.AST;

namespace LeoLang.Core
{
    public class StatementNode : SyntaxNode
    {
        public BlockNode Body { get; set; }
        public SyntaxNode Expression { get; set; }
        public IdentifierNode Name { get; set; }

        public StatementNode(SyntaxNode name, SyntaxNode expression, BlockNode body)
        {
            Name = (IdentifierNode)name;
            Body = body;
            Expression = expression;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}