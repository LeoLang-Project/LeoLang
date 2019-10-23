using System;

namespace LeoLang.Core.AST
{
    public class MethodDefinitionNode : SyntaxNode
    {
        public SyntaxNode Body { get; set; }

        public Symbol Name { get; set; }

        public SyntaxNode Parameter { get; set; }
        public Symbol ReturnType { get; set; }

        public MethodDefinitionNode(Symbol name, Symbol returnType, SyntaxNode param, SyntaxNode body)
        {
            Name = name;
            ReturnType = returnType;
            Parameter = param;
            Body = body;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}