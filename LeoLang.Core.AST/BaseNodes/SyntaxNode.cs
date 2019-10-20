﻿using LeoLang.Core.AST;
using LeoLang.Core.AST.Expressions;
using LeoLang.Core.AST.Literals;
using LeoLang.Core.AST.Statements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace LeoLang.Core
{
    public abstract class SyntaxNode
    {
        public static Visitor Visitor;

        public static SyntaxNode CreateBinary(SyntaxNode l, BinaryOperator op, SyntaxNode r)
        {
            return new BinaryExpressionNode(l, op, r);
        }

        public static SyntaxNode CreateBlock(IEnumerable<SyntaxNode> body)
        {
            return new BlockNode(body);
        }

        public static BlockNode CreateBlock(SyntaxNode body)
        {
            return new BlockNode(new[] { body });
        }

        public static SyntaxNode CreateBool(string value)
        {
            return new BooleanLiteralNode(bool.Parse(value));
        }

        public static SyntaxNode CreateChar(string value)
        {
            return new CharLiteralNode(value.First());
        }

        public static SyntaxNode CreateDecimal(string value)
        {
            return new DecimalLiteralNode(double.Parse(value, CultureInfo.InvariantCulture));
        }

        public static SyntaxNode CreateDefault(SyntaxNode id)
        {
            return new DefaultExpressionNode((IdentifierNode)id);
        }

        public static SyntaxNode CreateGoTo(SyntaxNode id)
        {
            return new GoToStatementNode((IdentifierNode)id);
        }

        public static IdentifierNode CreateID(string value)
        {
            return new IdentifierNode(value);
        }

        public static SyntaxNode CreateInteger(string value)
        {
            return new IntegerLiteralNode(int.Parse(value));
        }

        public static SyntaxNode CreateLabel(SyntaxNode id)
        {
            return new LabelDefinitionNode((IdentifierNode)id);
        }

        public static SyntaxNode CreateMethod(SyntaxNode name, SyntaxNode retType, SyntaxNode param, SyntaxNode body)
        {
            return new MethodDefinitionNode(((IdentifierNode)name).Name, ((IdentifierNode)retType).Name, param, body);
        }

        public static SyntaxNode CreateParameter(SyntaxNode type, SyntaxNode name, IList<string> isarray)
        {
            return new ParameterDefinitionNode(((IdentifierNode)type).Name, ((IdentifierNode)name).Name, isarray.Any());
        }

        public static ParameterListDefinitionNode CreateParameter(SyntaxNode parameter)
        {
            return new ParameterListDefinitionNode(parameter);
        }

        public static SyntaxNode CreateReturn(SyntaxNode expr)
        {
            return new ReturnStatementNode(expr);
        }

        public static SyntaxNode CreateSizeOf(SyntaxNode id)
        {
            return new SizeOfExpressionNode((IdentifierNode)id);
        }

        public static SyntaxNode CreateStatement(SyntaxNode name, SyntaxNode expr, SyntaxNode body)
        {
            return new StatementNode(name, expr, (BlockNode)body);
        }

        public static SyntaxNode CreateString(string value)
        {
            return new StringLiteralNode(value);
        }

        public static SyntaxNode CreateTernary(SyntaxNode cond, SyntaxNode tp, SyntaxNode fp)
        {
            return new TernaryExpressionNode(cond, tp, fp);
        }

        public static SyntaxNode CreateVarDef(SyntaxNode id, SyntaxNode val)
        {
            return new VariableDefinitionNode((IdentifierNode)id, val);
        }

        public abstract void Accept(Visitor visitor);

        public void ApplyVisitor(Visitor visitor)
        {
            Visitor = visitor;
            Visitor.Visit(this);
        }

        public override abstract int GetHashCode();
    }
}