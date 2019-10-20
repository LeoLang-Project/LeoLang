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

        public virtual void Visit(TernaryExpressionNode n)
        {
        }

        public virtual void Visit(DefaultExpressionNode n)
        {
        }

        public virtual void Visit(SyntaxNode n)
        {
        }

        public virtual void Visit(ReturnStatementNode n)
        {
        }

        public virtual void Visit(DecimalLiteralNode n)
        {
        }

        public virtual void Visit(GoToStatementNode n)
        {
        }

        public virtual void Visit(LabelDefinitionNode n)
        {
        }

        public virtual void Visit(BinaryExpressionNode n)
        {
        }

        public virtual void Visit(SizeOfExpressionNode n)
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

        public virtual void Visit(IntegerLiteralNode n)
        {
        }
    }
}