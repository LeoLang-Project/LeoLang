using LeoLang.Core.AST;
using LeoLang.Core.AST.Expressions;
using LeoLang.Core.AST.Literals;
using LeoLang.Core.AST.Statements;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LeoLang.Core
{
    [Flags]
    public enum SymbolPrefix { None, Increment, Decrement, Negate, Deref, Address }

    [Flags]
    public enum SymbolSuffix
    {
        None = 0,
        Array = 2,
        Nullable = 4,
        Increment = 8,
        Decrement = 16,
        PointerDecl = 32,
    }

    public abstract class SyntaxNode
    {
        public static Visitor Visitor;

        public static SyntaxNode CreateBinary(SyntaxNode l, BinaryOperator op, SyntaxNode r)
        {
            return new BinaryExpressionNode(l, op, r);
        }

        public static SyntaxNode CreateBinInteger(string value)
        {
            return new IntegerLiteralNode(Convert.ToInt32(value.Replace("_", ""), 2));
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

        public static SyntaxNode CreateEnum(IEnumerable<Symbol> mod, Symbol id, IEnumerable<Symbol> type, IEnumerable<SyntaxNode> body)
        {
            return new EnumDefinitionNode(type.Any() ? type.First() : (Symbol)"byte", mod.Any() ? mod.First() : (Symbol)"private", id, body);
        }

        public static SyntaxNode CreateField(IList<Symbol> mod, Symbol type, Symbol name, SyntaxNode value)
        {
            return new FieldDefinitionNode(mod.Any() ? mod.First() : (Symbol)"private", type, name, value);
        }

        public static SyntaxNode CreateGoTo(Symbol id)
        {
            return new GoToStatementNode(id);
        }

        public static SyntaxNode CreateHexInteger(string value)
        {
            return new IntegerLiteralNode(int.Parse(value, NumberStyles.HexNumber));
        }

        public static SyntaxNode CreateInteger(string value)
        {
            return new IntegerLiteralNode(int.Parse(value));
        }

        public static SyntaxNode CreateLabel(Symbol id)
        {
            return new LabelDefinitionNode(id);
        }

        public static SyntaxNode CreateMethod(IList<Symbol> mod, Symbol name, Symbol retType, SyntaxNode param, SyntaxNode body)
        {
            return new MethodDefinitionNode(mod.Any() ? mod.First() : (Symbol)"private", name, retType, param, body);
        }

        public static Symbol CreateModifier(string mod)
        {
            return mod;
        }

        public static PairSyntaxNode CreatePair(SyntaxNode key, SyntaxNode value)
        {
            return new PairSyntaxNode(key, value);
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

        public static SyntaxNode CreateSymbolLiteral(Symbol id)
        {
            return new SymbolLiteralNode(id);
        }

        public static SyntaxNode CreateTernary(SyntaxNode cond, SyntaxNode tp, SyntaxNode fp)
        {
            return new TernaryExpressionNode(cond, tp, fp);
        }

        public static SyntaxNode CreateUnparsedBlockExpression(Symbol id, string body)
        {
            return new UnparsedBlockExpression(id, body.Trim());
        }

        public static SyntaxNode CreateVarDef(Symbol type, Symbol id, SyntaxNode val)
        {
            return new VariableDefinitionNode(type, id, val);
        }

        public static SymbolPrefix GetSymbolPrefix(string op)
        {
            switch (op)
            {
                case "--": return SymbolPrefix.Decrement;
                case "-": return SymbolPrefix.Negate;
                case "++": return SymbolPrefix.Increment;
                case "&": return SymbolPrefix.Address;
            }

            return SymbolPrefix.None;
        }

        public static SymbolSuffix GetSymbolSuffix(string op)
        {
            switch (op)
            {
                case "--": return SymbolSuffix.Decrement;
                case "++": return SymbolSuffix.Increment;
                case "?": return SymbolSuffix.Nullable;
                case "[]": return SymbolSuffix.Array;
            }

            return SymbolSuffix.None;
        }

        public abstract void Accept(Visitor visitor);

        public void ApplyVisitor(Visitor visitor)
        {
            Visitor = visitor;
            Visitor.Visit(this);
        }
    }
}