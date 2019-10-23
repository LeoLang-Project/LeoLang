using LeoLang.Core.AST;

namespace LeoLang.Core
{
    public class StatementNode : SyntaxNode
    {
        public BlockNode Body { get; set; }
        public SyntaxNode Expression { get; set; }
        public Symbol Name { get; set; }

        public StatementNode(Symbol name, SyntaxNode expression, BlockNode body)
        {
            Name = name;
            Body = body;
            Expression = expression;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}