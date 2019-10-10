using System;

namespace LeoLang.Core.AST
{
    public class IdentifierNode : SyntaxNode
    {
        public string Name { get; set; }

        public IdentifierNode(string name)
        {
            Name = name;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}