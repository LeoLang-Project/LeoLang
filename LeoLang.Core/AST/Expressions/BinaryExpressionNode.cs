using System;

namespace LeoLang.Core.AST.Expressions
{
    public class BinaryExpressionNode : SyntaxNode
    {
        public SyntaxNode Left { get; set; }

        public BinaryOperator Op { get; set; }

        public SyntaxNode Right { get; set; }

        public BinaryExpressionNode(SyntaxNode left, BinaryOperator op, SyntaxNode right)
        {
            Left = left;
            Op = op;
            Right = right;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Left, Op, Right);
        }
    }
}