using System;

namespace LeoLang.Core.AST
{
    public class GoToStatementNode : SyntaxNode
    {
        public Symbol LabelName { get; set; }

        public GoToStatementNode(Symbol id)
        {
            LabelName = id;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}