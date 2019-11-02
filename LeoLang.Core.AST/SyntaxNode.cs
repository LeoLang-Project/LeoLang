using Loyc;
using Loyc.Syntax;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LeoLang.Core
{
    public enum BinaryOperator
    {
        Less,
        LessEq,
        Equal,
        GreaterEq,
        Greater
    }

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
        public static LNodeFactory F = new LNodeFactory(new EmptySourceFile(FileName));
        public static string FileName = "Foo.cs";

        public static IEnumerable<SyntaxNode> Combine(SyntaxNode f, SyntaxNode s)
        {
            return new SyntaxNode[] { f, s };
        }

        public static IEnumerable<SyntaxNode> Combine(SyntaxNode f, IEnumerable<SyntaxNode> s)
        {
            var r = new List<SyntaxNode>();
            r.Add(f);
            r.AddRange(s);

            return r;
        }

        public static IEnumerable<SyntaxNode> Combine(SyntaxNode v)
        {
            return new SyntaxNode[] { v };
        }

        public static LNode CreateBinary(LNode l, BinaryOperator op, LNode r)
        {
            return F.Call(CodeSymbols.Eq, LNode.List(l, r)).SetStyle(NodeStyle.Operator);
        }

        public static LNode CreateBinInteger(string value)
        {
            var val = Convert.ToInt32(value.Replace("_", ""), 2);

            return F.Literal(val).WithStyle(NodeStyle.BinaryLiteral);
        }

        public static LNode CreateBlock(IEnumerable<LNode> body)
        {
            return F.Call(CodeSymbols.Braces, F.List(body)).SetStyle(NodeStyle.Statement);
        }

        public static LNode CreateBlock(LNode body)
        {
            return F.Call(CodeSymbols.Braces, F.List(body)).SetStyle(NodeStyle.Statement);
        }

        public static LNode CreateBool(string value)
        {
            return F.Literal(bool.Parse(value));
        }

        public static LNode CreateCall(Symbol name, IEnumerable<LNode> args)
        {
            return F.Call(name, args);
        }

        public static LNode CreateChar(string value)
        {
            return F.Literal(value.First());
        }

        public static LNode CreateDecimal(string value)
        {
            return F.Literal(double.Parse(value, CultureInfo.InvariantCulture));
        }

        public static LNode CreateDefault(Symbol id)
        {
            return F.Call(CodeSymbols.Default, LNode.List(LNode.Id(id)));
        }

        public static LNode CreateEnum(Symbol mod, Symbol id, Symbol type, IEnumerable<LNode> body)
        {
            return LNode.Call(LNode.List(LNode.Id(mod)), CodeSymbols.Enum,
                    LNode.List(LNode.Id(id), LNode.Call(CodeSymbols.AltList,
                    LNode.List(LNode.Id(type))), LNode.Call(CodeSymbols.Braces, LNode.List(body))));
        }

        public static LNode CreateField(Symbol mod, Symbol type, Symbol name, LNode value)
        {
            return LNode.Call(LNode.List(LNode.Id(mod)), CodeSymbols.Var, LNode.List(LNode.Id(type), LNode.Call(CodeSymbols.Assign, LNode.List(LNode.Id(name), value))));
        }

        public static LNode CreateGoTo(Symbol id)
        {
            return LNode.Call(CodeSymbols.Goto, LNode.List(LNode.Id(id)));
        }

        public static LNode CreateHexInteger(string value)
        {
            var val = int.Parse(value, NumberStyles.HexNumber);

            return F.Literal(val).WithStyle(NodeStyle.HexLiteral);
        }

        public static LNode CreateInteger(string value)
        {
            return F.Literal(int.Parse(value));
        }

        public static LNode CreateMethod(Symbol mod, Symbol name, Symbol retType, LNode param, LNode body)
        {
            return F.Fn(F.Id(retType), F.Id(name), param, body);
        }

        public static LNode CreateModifier(string mod)
        {
            return F.Literal(mod);
        }

        public static LNode CreatePair(LNode key, LNode value)
        {
            return F.Tuple(key, value);
        }

        public static LNode CreateParameter(Symbol type, Symbol name, IList<string> isarray)
        {
            var pDef = F.Var(F.Id(type), name);
            if (isarray.Any())
            {
                pDef = pDef.WithAttrs(F.Id(CodeSymbols.Array));
            }

            return pDef;
        }

        public static LNode CreateReturn(LNode expr)
        {
            var node = F.Call(CodeSymbols.Return);
            if (expr != null)
            {
                node = node.WithArgs(F.List(expr));
            }

            return node;
        }

        public static LNode CreateSizeOf(Symbol id)
        {
            return F.Call(CodeSymbols.Sizeof, F.List(F.Id(id)));
        }

        public static LNode CreateStatement(Symbol name, LNode expr, LNode body)
        {
            return F.Call(name, F.List(expr, body));
        }

        public static LNode CreateString(string value)
        {
            return F.Literal(value);
        }

        public static LNode CreateStruct(Symbol mod, Symbol name, LNode body)
        {
            return LNode.Call(LNode.List(LNode.Id(mod)), CodeSymbols.Struct, LNode.List(LNode.Id(name), LNode.Call(CodeSymbols.AltList), body));
        }

        public static LNode CreateSymbolLiteral(Symbol id)
        {
            return F.Id(id);
        }

        public static LNode CreateTernary(LNode cond, LNode tp, LNode fp)
        {
            return LNode.Call(CodeSymbols.Result, LNode.List(LNode.Call(CodeSymbols.QuestionMark, LNode.List(cond, tp, fp)).SetStyle(NodeStyle.Operator)));
        }

        public static LNode CreateUnparsedBlockExpression(Symbol id, string body)
        {
            return LNode.Call(id, LNode.List(F.Literal(body)));
        }

        public static LNode CreateUsing(Symbol ns)
        {
            return LNode.Call(CodeSymbols.Import, LNode.List(LNode.Id(ns)));
        }

        public static LNode CreateVarDef(Symbol type, Symbol id, LNode val)
        {
            return LNode.Call(CodeSymbols.Var, LNode.List(LNode.Id(type), LNode.Call(CodeSymbols.Assign, LNode.List(LNode.Id(id), val))));
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
    }
}