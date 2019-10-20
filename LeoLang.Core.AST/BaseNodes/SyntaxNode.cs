using LeoLang.Core.AST;
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

        public static SyntaxNode CreateDefault(Symbol id)
        {
            return new DefaultExpressionNode(id);
        }

        public static SyntaxNode CreateGoTo(Symbol id)
        {
            return new GoToStatementNode(id);
        }

        public static SyntaxNode CreateInteger(string value)
        {
            return new IntegerLiteralNode(int.Parse(value));
        }

        public static SyntaxNode CreateLabel(Symbol id)
        {
            return new LabelDefinitionNode(id);
        }

        public static SyntaxNode CreateMethod(Symbol name, Symbol retType, SyntaxNode param, SyntaxNode body)
        {
            return new MethodDefinitionNode(name, retType, param, body);
        }

        public static SyntaxNode CreateParameter(Symbol type, Symbol name, IList<string> isarray)
        {
            return new ParameterDefinitionNode(type, name, isarray.Any());
        }

        public static ParameterListDefinitionNode CreateParameter(SyntaxNode parameter)
        {
            return new ParameterListDefinitionNode(parameter);
        }

        public static SyntaxNode CreateReturn(SyntaxNode expr)
        {
            return new ReturnStatementNode(expr);
        }

        public static SyntaxNode CreateSizeOf(Symbol id)
        {
            return new SizeOfExpressionNode(id);
        }

        public static SyntaxNode CreateStatement(Symbol name, SyntaxNode expr, SyntaxNode body)
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

        public static SyntaxNode CreateVarDef(Symbol id, SyntaxNode val)
        {
            return new VariableDefinitionNode(id, val);
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