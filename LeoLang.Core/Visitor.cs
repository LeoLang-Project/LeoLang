using System;
using LeoLang.Core.AST;
using LeoLang.Core.AST.Expressions;
using LeoLang.Core.AST.Statements;

namespace LeoLang.Core
{
    public class Visitor
    {
        public virtual void Visit(IdentifierNode rootNode)
        {
        }

        public virtual void Visit(BinaryExpressionNode rootNode)
        {
        }

        public virtual void Visit(IfStatementNode rootNode)
        {
        }

        public virtual void Visit(BooleanLiteralNode rootNode)
        {
        }

        public virtual void Visit(CharLiteralNode rootNode)
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