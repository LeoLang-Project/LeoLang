using System;

namespace LeoLang.CodeAnalysis.Binding
{
    internal sealed class BoundTypeOfExpression : BoundExpression
    {
        public BoundTypeOfExpression(BoundExpression value)
        {
            Value = value;
        }

        public BoundExpression Value { get; }

        public override Type Type => Value.Type;

        public override BoundNodeKind Kind => BoundNodeKind.TypeOfExpression;
    }
}