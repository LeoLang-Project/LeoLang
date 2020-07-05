using LeoLang.CodeAnalysis.Symbols;
using System;

namespace LeoLang.CodeAnalysis.Binding
{
    internal sealed class BoundDefaultExpression : BoundExpression
    {
        public BoundDefaultExpression(BoundExpression value)
        {
            Value = value;
        }

        public BoundExpression Value { get; }

        public override TypeSymbol Type => TypeSymbol.Any;

        public override BoundNodeKind Kind => BoundNodeKind.DefaultExpression;
    }
}