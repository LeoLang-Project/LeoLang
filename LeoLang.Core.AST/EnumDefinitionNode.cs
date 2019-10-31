using System.Collections.Generic;

namespace LeoLang.Core.AST
{
    public class EnumDefinitionNode : SyntaxNode
    {
        public IEnumerable<PairSyntaxNode> Body { get; set; }
        public Symbol ID { get; set; }
        public Symbol Modifier { get; set; }

        public EnumDefinitionNode(Symbol mod, Symbol iD, IEnumerable<PairSyntaxNode> body)
        {
            Modifier = mod;
            ID = iD;
            Body = body;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}