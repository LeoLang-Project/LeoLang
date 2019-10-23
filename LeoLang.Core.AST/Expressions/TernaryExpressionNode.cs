using System;

namespace LeoLang.Core.AST.Expressions
{
    public class TernaryExpressionNode : SyntaxNode
    {
        public SyntaxNode Condition { get; set; }

        public SyntaxNode FalsePart { get; set; }

        public SyntaxNode TruePart { get; set; }

        public TernaryExpressionNode(SyntaxNode condition, SyntaxNode truePart, SyntaxNode falsePart)
        {
            Condition = condition;
            TruePart = truePart;
            FalsePart = falsePart;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}