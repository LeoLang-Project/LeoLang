using System;

namespace LLC.CodeAnalysis.Binding
{
    internal sealed class BoundUnaryExpression : BoundExpression
    {
        public BoundUnaryExpression(BoundExpression operand, BoundNodeKind operatorKind)
        {
            Operand = operand;
            OperatorKind = operatorKind;
        }

        public BoundExpression Operand { get; }
        public BoundNodeKind OperatorKind { get; }

        public override Type Type => Operand.Type;

        public override BoundNodeKind Kind => BoundNodeKind.UnaryExpression;
    }
}