using System;

namespace LeoLang.Core.AST
{
    public class ParameterDefinitionNode : SyntaxNode
    {
        public bool IsArray { get; set; }
        public string Name { get; set; }

        public string ReturnType { get; set; }

        public ParameterDefinitionNode(string returnType, string name, bool isarray)
        {
            ReturnType = returnType;
            Name = name;
            IsArray = isarray;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ReturnType);
        }
    }
}