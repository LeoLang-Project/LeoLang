using System;

namespace LeoLang.Core.AST.Statements
{
    public class IfStatementNode : SyntaxNode
    {
        public BlockNode Body { get; set; }

        public SyntaxNode Condition { get; set; }

        public IfStatementNode(SyntaxNode condition, BlockNode body)
        {
            Condition = condition;
            Body = body;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}