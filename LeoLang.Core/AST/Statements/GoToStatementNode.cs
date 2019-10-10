using System;

namespace LeoLang.Core.AST
{
    public class GoToStatementNode : SyntaxNode
    {
        public string LabelName { get; set; }

        public GoToStatementNode(IdentifierNode id)
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