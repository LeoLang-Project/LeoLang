using System.Collections.Generic;

namespace LeoLang.Core.AST
{
    public class EnumDefinitionNode : SyntaxNode
    {
        public IEnumerable<SyntaxNode> Body { get; set; }
        public Symbol ID { get; set; }
        public Symbol Modifier { get; set; }
        public Symbol Type { get; set; }

        public EnumDefinitionNode(Symbol type, Symbol mod, Symbol iD, IEnumerable<SyntaxNode> body)
        {
            Type = type;
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