using LeoLang.CodeAnalysis.Symbols;
using System;

namespace LeoLang.CodeAnalysis.Binding
{
    public abstract class BoundExpression : BoundNode
    {
        public abstract TypeSymbol Type { get; }
    }
}