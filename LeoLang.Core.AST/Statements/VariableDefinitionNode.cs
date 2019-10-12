using System;

namespace LeoLang.Core.AST
{
    public class VariableDefinitionNode : SyntaxNode
    {
        public string ID { get; set; }
        public SyntaxNode Value { get; set; }

        public VariableDefinitionNode(IdentifierNode id, SyntaxNode val)
        {
            ID = id.Name;
            Value = val;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Value);
        }
    }
}