using System;

namespace LeoLang.Core.AST
{
    public class VariableDefinitionNode : SyntaxNode
    {
        public Symbol Name { get; set; }
        public SyntaxNode Value { get; set; }

        public VariableDefinitionNode(Symbol id, SyntaxNode val)
        {
            Name = id;
            Value = val;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}