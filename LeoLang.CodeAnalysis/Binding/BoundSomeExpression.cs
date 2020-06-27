using System;

namespace LLC.CodeAnalysis.Binding
{
    internal sealed class BoundSomeExpression : BoundExpression
    {
        public BoundSomeExpression(BoundExpression value)
        {
            Value = value;
        }

        public BoundExpression Value { get; }

        public override Type Type => Value.GetType();

        public override BoundNodeKind Kind => BoundNodeKind.SomeExpression;
    }
}