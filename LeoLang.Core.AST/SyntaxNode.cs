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

        public static IEnumerable<LNode> Combine(LNode f, LNode s)
        {
            return new LNode[] { f, s };
        }

        public static IEnumerable<LNode> Combine(LNode f, IEnumerable<LNode> s)
        {
            var r = new List<LNode>();
            r.Add(f);
            r.AddRange(s);

            return r;
        }

        public static IEnumerable<LNode> Combine(LNode v)
        {
            return new LNode[] { v };
        }

        public static LNode CreateBinary(LNode l, BinaryOperator op, LNode r)
        {
            return F.Call(LNode.Id(op.ToString()), LNode.List(l, r)).SetStyle(NodeStyle.Operator);
        }

        public static LNode CreateBinInteger(string value)
        {
            var val = Convert.ToInt32(value.Replace("_", ""), 2);

            return F.Literal(val).WithStyle(NodeStyle.BinaryLiteral);
        }

        public static LNode CreateBlock(IEnumerable<LNode> body)
        {
            return F.Braces(F.List(body)).SetStyle(NodeStyle.Statement);
        }

        public static LNode CreateBlock(LNode body)
        {
            return F.Braces(F.List(body)).SetStyle(NodeStyle.Statement);
        }

        public static LNode CreateBool(string value)
        {
            return F.Literal(bool.Parse(value));
        }

        public static LNode CreateCall(LNode name, IEnumerable<LNode> args)
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

        public static LNode CreateDefault(LNode id)
        {
            return F.Call(CodeSymbols.Default, LNode.List(id));
        }

        public static LNode CreateEnum(LNode mod, LNode id, IList<LNode> type, IEnumerable<LNode> body)
        {
            return LNode.Call(LNode.List(mod), CodeSymbols.Enum,
                    LNode.List(id, LNode.Call(CodeSymbols.AltList,
                    LNode.List(type)), LNode.Call(CodeSymbols.Braces, LNode.List(body))));
        }

        public static LNode CreateField(LNode mod, LNode type, LNode name, LNode value)
        {
            return LNode.Call(LNode.List(mod), CodeSymbols.Var, LNode.List(type, LNode.Call(CodeSymbols.Assign, LNode.List(name, value))));
        }

        public static LNode CreateGoTo(LNode id)
        {
            return LNode.Call(CodeSymbols.Goto, LNode.List(id));
        }

        public static LNode CreateHexInteger(string value)
        {
            var val = int.Parse(value, NumberStyles.HexNumber);

            return F.Literal(val).WithStyle(NodeStyle.HexLiteral);
        }

        public static LNode CreateID(string src)
        {
            return F.Id(src);
        }

        public static LNode CreateInteger(string value)
        {
            return F.Literal(int.Parse(value));
        }

        public static LNode CreateMethod(LNode mod, LNode name, LNode retType, LNode param, LNode body)
        {
            return F.Fn(retType, name, param, body);
        }

        public static LNode CreateModifier(IList<string> mod)
        {
            return mod.Any() ? F.Literal(mod) : F.Literal(CodeSymbols.Private);
        }

        public static LNode CreatePair(LNode key, LNode value)
        {
            return F.Tuple(key, value);
        }

        public static LNode CreateParameter(LNode type, LNode name, IList<string> isarray)
        {
            var pDef = F.Var(type, name);
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

        public static LNode CreateSizeOf(LNode id)
        {
            return F.Call(CodeSymbols.Sizeof, F.List(id));
        }

        public static LNode CreateStatement(LNode name, LNode expr, LNode body)
        {
            return F.Call(name, F.List(expr, body));
        }

        public static LNode CreateString(string value)
        {
            return F.Literal(value);
        }

        public static LNode CreateStruct(LNode mod, LNode name, LNode body)
        {
            return LNode.Call(LNode.List(mod), CodeSymbols.Struct, LNode.List(name, LNode.Call(CodeSymbols.AltList), body));
        }

        public static LNode CreateSymbolLiteral(LNode id)
        {
            return id;
        }

        public static LNode CreateTernary(LNode cond, LNode tp, LNode fp)
        {
            return LNode.Call(CodeSymbols.Result, LNode.List(LNode.Call(CodeSymbols.QuestionMark, LNode.List(cond, tp, fp)).SetStyle(NodeStyle.Operator)));
        }

        public static LNode CreateUnparsedBlockExpression(LNode id, string body)
        {
            return LNode.Call(id, LNode.List(F.Literal(body)));
        }

        public static LNode CreateUsing(LNode ns)
        {
            return LNode.Call(CodeSymbols.Import, LNode.List(ns));
        }

        public static LNode CreateVarDef(LNode type, LNode id, LNode val)
        {
            return LNode.Call(CodeSymbols.Var, LNode.List(type, LNode.Call(CodeSymbols.Assign, LNode.List(id, val))));
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

        public static LNode JoinNodes(LNode f, LNode s, char seperator)
        {
            var first = (IdNode)f;
            var second = (IdNode)s;

            return F.Id(first.Name.Name + seperator + second.Name.Name);
        }

        public static LNode SetInfix(LNode id, IList<SymbolPrefix> pre, IList<SymbolSuffix> suf)
        {
            return id.WithAttrs(F.Literal(pre), F.Literal(suf));
        }
    }
}