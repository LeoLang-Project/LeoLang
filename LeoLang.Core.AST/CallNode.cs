using System.Collections.Generic;

namespace LeoLang.Core.AST
{
    public class CallNode : SyntaxNode
    {
        public IEnumerable<SyntaxNode> Args { get; set; }

        public Symbol Name { get; set; }

        public CallNode(Symbol name, IEnumerable<SyntaxNode> args)
        {
            Name = name;
            Args = args;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}