using LeoLang.Core.AST;
using LeoLang.Core.AST.Expressions;
using LeoLang.Core.AST.Statements;
using System.Collections.Generic;
using System.Linq;

namespace LeoLang.Core
{
    public abstract class SyntaxNode
    {
        public static SyntaxNode CreateBinary(SyntaxNode l, BinaryOperator op, SyntaxNode r)
        {
            return new BinaryExpressionNode(l, op, r);
        }

        public static SyntaxNode CreateBlock(IEnumerable<SyntaxNode> body)
        {
            return new BlockNode(body);
        }

        public static SyntaxNode CreateBool(bool value)
        {
            return new BooleanLiteralNode(value);
        }

        public static SyntaxNode CreateChar(string value)
        {
            return new CharLiteralNode(value.First());
        }

        public static SyntaxNode CreateDefault(SyntaxNode id)
        {
            return new DefaultExpressionNode((IdentifierNode)id);
        }

        public static SyntaxNode CreateGoTo(SyntaxNode id)
        {
            return new GoToExpressionNode((IdentifierNode)id);
        }

        public static IdentifierNode CreateID(string value)
        {
            return new IdentifierNode(value);
        }

        public static SyntaxNode CreateIf(SyntaxNode cond, SyntaxNode body)
        {
            return new IfStatementNode((BinaryExpressionNode)cond, (BlockNode)body);
        }

        public static SyntaxNode CreateLabel(SyntaxNode id)
        {
            return new LabelDefinitionNode((IdentifierNode)id);
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

        public static SyntaxNode CreateWhile(SyntaxNode cond, SyntaxNode body)
        {
            return new WhileStatementNode((BinaryExpressionNode)cond, (BlockNode)body);
        }

        public abstract void Accept(Visitor visitor);
    }
}