using System;
using System.Collections.Generic;
using System.Linq;

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

        public BlockNode Concat(SyntaxNode tail)
        {
            var tmp = new List<SyntaxNode>(Body);
            tmp.Add(((BlockNode)tail).Body.First());

            Body = tmp;

            return this;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Body);
        }
    }
}