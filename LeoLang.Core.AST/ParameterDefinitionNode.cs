using System;

namespace LeoLang.Core.AST
{
    public class ParameterDefinitionNode : SyntaxNode
    {
        public bool IsArray { get; set; }
        public Symbol Name { get; set; }

        public Symbol ReturnType { get; set; }

        public ParameterDefinitionNode(Symbol returnType, Symbol name, bool isarray)
        {
            ReturnType = returnType;
            Name = name;
            IsArray = isarray;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}