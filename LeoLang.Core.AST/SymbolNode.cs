using System;
using System.Collections.Generic;
using System.Linq;

namespace LeoLang.Core.AST
{
    public class SymbolNode : SyntaxNode
    {
        public SymbolPrefix Prefix { get; set; }
        public SymbolSuffix Suffix { get; set; }
        public Symbol Symbol { get; set; }

        public SymbolNode(Symbol symbol)
        {
            Symbol = symbol;
        }

        public static implicit operator Symbol(SymbolNode n)
        {
            return n.Symbol;
        }

        public static SymbolNode Join(SymbolNode first, SymbolNode second, char seperator)
        {
            return new SymbolNode(first.Symbol.Name + seperator + second.Symbol.Name);
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(Symbol);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }

        public SymbolNode SetInfix(IList<SymbolPrefix> pre, IList<SymbolSuffix> suf)
        {
            Prefix = pre.Any() ? pre.First() : SymbolPrefix.None;
            Suffix = suf.Any() ? CombineSuffix(suf) : SymbolSuffix.None;

            return this;
        }

        private SymbolSuffix CombineSuffix(IList<SymbolSuffix> suf)
        {
            SymbolSuffix result = SymbolSuffix.None;

            foreach (var s in suf)
            {
                result |= s;
            }

            return result;
        }
    }
}