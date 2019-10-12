using System;

namespace LeoLang.Core.AST.Statements
{
    public class WhileStatementNode : StatementNode
    {
        public SyntaxNode Condition { get; set; }

        public WhileStatementNode(SyntaxNode condition, BlockNode body)
           : base(body)
        {
            Condition = condition;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Condition, Body);
        }
    }
}