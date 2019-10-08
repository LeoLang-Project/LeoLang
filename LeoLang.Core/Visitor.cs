using System;
using LeoLang.Core.AST;
using LeoLang.Core.AST.Expressions;
using LeoLang.Core.AST.Statements;

namespace LeoLang.Core
{
    public class Visitor
    {
        public virtual void Visit(IdentifierNode n)
        {
        }

        public virtual void Visit(BinaryExpressionNode n)
        {
        }

        public virtual void Visit(IfStatementNode n)
        {
        }

        public virtual void Visit(WhileStatementNode n)
        {
        }

        public virtual void Visit(BooleanLiteralNode n)
        {
        }

        public virtual void Visit(CharLiteralNode n)
        {
        }

        public virtual void Visit(ParameterDefinitionNode n)
        {
        }

        public virtual void Visit(BlockNode n)
        {
        }

        public virtual void Visit(MethodDefinitionNode n)
        {
        }

        public virtual void Visit(VariableDefinitionNode n)
        {
        }

        public virtual void Visit(NumberLiteralNode n)
        {
        }
    }
}