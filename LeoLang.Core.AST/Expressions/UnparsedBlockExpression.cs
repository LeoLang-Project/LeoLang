using System;

namespace LeoLang.Core.AST.Expressions
{
    public class UnparsedBlockExpression : SyntaxNode
    {
        public string Body { get; set; }

        public Symbol Name { get; set; }

        public UnparsedBlockExpression(Symbol name, string body)
        {
            Name = name;
            Body = body;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}