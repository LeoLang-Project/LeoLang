using System;

namespace LeoLang.Core.AST
{
    public class GoToExpressionNode : SyntaxNode
    {
        public string LabelName { get; set; }

        public GoToExpressionNode(IdentifierNode id)
        {
            LabelName = id.Name;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LabelName);
        }
    }
}