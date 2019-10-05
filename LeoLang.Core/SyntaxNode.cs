﻿using LeoLang.Core.AST;
using System.Collections.Generic;

namespace LeoLang.Core
{
    public abstract class SyntaxNode
    {
        public static SyntaxNode CreateBlock(IEnumerable<SyntaxNode> body)
        {
            return new BlockNode(body);
        }

        public static SyntaxNode CreateBool(bool value)
        {
            return new BooleanLiteralNode(value);
        }

        public static SyntaxNode CreateID(string value)
        {
            return new IdentifierNode(value);
        }

        public static SyntaxNode CreateMethod(SyntaxNode name, SyntaxNode retType, SyntaxNode param, SyntaxNode body)
        {
            return new MethodDefinitionNode(((IdentifierNode)name).Name, ((IdentifierNode)retType).Name, param, body);
        }

        public static SyntaxNode CreateNumber(int value)
        {
            return new NumberLiteralNode(value);
        }

        public static SyntaxNode CreateParameter(SyntaxNode type, SyntaxNode name)
        {
            return new ParameterDefinitionNode(((IdentifierNode)type).Name, ((IdentifierNode)name).Name);
        }

        public static SyntaxNode CreateVarDef(SyntaxNode id, SyntaxNode val)
        {
            return new VariableDefinitionNode((IdentifierNode)id, val);
        }

        public abstract void Accept(Visitor visitor);
    }
}