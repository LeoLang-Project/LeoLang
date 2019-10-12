using System;

namespace LeoLang.Core.AST
{
    public class VariableDeclarationNode : SyntaxNode
    {
        public string ID { get; set; }

        public bool IsNulllable { get; set; }

        public VariableDeclarationNode(IdentifierNode iD, bool isNulllable)
        {
            ID = iD.Name;
            IsNulllable = isNulllable;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, IsNulllable);
        }
    }
}