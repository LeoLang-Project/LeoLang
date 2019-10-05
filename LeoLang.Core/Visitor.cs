using System;
using LeoLang.Core.AST;

namespace LeoLang.Core
{
    public class Visitor
    {
        public virtual void Visit(IdentifierNode rootNode)
        {
        }

        public virtual void Visit(BooleanLiteralNode rootNode)
        {
        }

        public virtual void Visit(ParameterDefinitionNode rootNode)
        {
        }

        public virtual void Visit(BlockNode rootNode)
        {
        }

        public virtual void Visit(LiteralNode rootNode)
        {
        }

        public virtual void Visit(MethodDefinitionNode rootNode)
        {
        }

        public virtual void Visit(VariableDefinitionNode rootNode)
        {
        }

        public virtual void Visit(NumberLiteralNode rootNode)
        {
        }
    }
}