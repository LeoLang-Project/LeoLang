using LeoLang.CodeAnalysis.Symbols;
using LeoLang.Core;
using System;

namespace LeoLang.CodeAnalysis.Binding
{
    internal sealed class BoundLiteralExpression : BoundExpression
    {
        public BoundLiteralExpression(object value)
        {
            Value = value;

            if (value is bool)
                Type = TypeSymbol.Bool;
            else if (value is int)
                Type = TypeSymbol.Int;
            else if (value is string)
                Type = TypeSymbol.String;
            else if (value is Core.Symbol)
                Type = TypeSymbol.Symbol;
            else
                throw new Exception($"Unexpected literal '{value}' of type {value.GetType()}");
        }

        public object Value { get; }

        public override TypeSymbol Type { get; }

        public override BoundNodeKind Kind => BoundNodeKind.LiteralExpression;
    }
}