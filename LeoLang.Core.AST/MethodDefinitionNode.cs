﻿using System;

namespace LeoLang.Core.AST
{
    public class MethodDefinitionNode : SyntaxNode
    {
        public SyntaxNode Body { get; set; }

        public string Name { get; set; }

        public SyntaxNode Parameter { get; set; }
        public string ReturnType { get; set; }

        public MethodDefinitionNode(string name, string returnType, SyntaxNode param, SyntaxNode body)
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ReturnType, Parameter, Body);
        }
    }
}