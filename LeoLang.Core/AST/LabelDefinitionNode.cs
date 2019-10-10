using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLang.Core.AST
{
    public class LabelDefinitionNode : SyntaxNode
    {
        public string Name { get; set; }

        public LabelDefinitionNode(IdentifierNode id)
        {
            Name = id.Name;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}