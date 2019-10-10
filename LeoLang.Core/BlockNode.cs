using System;
using System.Collections.Generic;

namespace LeoLang.Core
{
    public class BlockNode : SyntaxNode
    {
        public IEnumerable<SyntaxNode> Body { get; set; }

        public BlockNode(IEnumerable<SyntaxNode> body)
        {
            Body = body;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Body);
        }
    }
}