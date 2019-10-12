using System;

namespace LeoLang.Core.AST.Expressions
{
    public class SizeOfExpressionNode : SyntaxNode
    {
        public IdentifierNode Type { get; set; }

        public SizeOfExpressionNode(IdentifierNode type)
        {
            Type = type;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type);
        }
    }
}