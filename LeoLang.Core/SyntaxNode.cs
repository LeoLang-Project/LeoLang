﻿using LeoLang.Core.AST;

namespace LeoLang.Core
{
    public abstract class SyntaxNode
    {
        public static SyntaxNode CreateBool(bool value)
        {
            return new BooleanLiteralNode(value);
        }

        public static SyntaxNode CreateID(string value)
        {
            return new IdentifierNode(value);
        }

        public static SyntaxNode CreateMethod(SyntaxNode name, SyntaxNode retType, SyntaxNode body)
        {
            return new MethodDefinitionNode { Name = ((IdentifierNode)name).Name, ReturnType = ((IdentifierNode)retType).Name, Body = body };
        }

        public static SyntaxNode CreateNumber(int value)
        {
            return new NumberLiteralNode(value);
        }

        public static SyntaxNode CreateVarDef(SyntaxNode id, SyntaxNode val)
        {
            return new VariableDefinitionNode((IdentifierNode)id, val);
        }

        public abstract void Accept(Visitor visitor);
    }
}