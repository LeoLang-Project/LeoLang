using System;

namespace LeoLang.Core.AST.Expressions
{
    public class DefaultExpressionNode : SyntaxNode
    {
        public Symbol Type { get; set; }

        public DefaultExpressionNode(Symbol type)
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