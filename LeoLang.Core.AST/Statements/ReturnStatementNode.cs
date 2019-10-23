using System;

namespace LeoLang.Core.AST.Statements
{
    public class ReturnStatementNode : SyntaxNode
    {
        public SyntaxNode Expression { get; set; }

        public ReturnStatementNode(SyntaxNode expression)
        {
            Expression = expression;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}