using System;
using Leo.CodeAnalysis.Syntax;

namespace LLC.CodeAnalysis.Binding
{
    internal enum BoundNodeKind
    {
        UnaryExpression,
        LiteralExpression
    }
    internal abstract class BoundNode
    {
        public abstract  BoundNodeKind Kind { get; }
    }
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
    internal enum BoundBinaryOperatorKind
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }
    internal sealed class Binder
    {
        public BoundExpression Bind(ExpressionSyntax syntax)
        {
            switch (syntax.Kind)
            {
                case SyntaxKind.UnaryExpression:
                    return BindUnaryExpression((UnaryExpressionSyntax)syntax);
                case SyntaxKind.BinaryExpression:
                    return BindBinaryExpression((BinaryExpressionSyntax)syntax);
                case SyntaxKind.LiteralExpression:
                    return BindLiteralExpression((LiteralExpressionSyntax)syntax);
            }
        }
    }
    internal sealed class BoundBinaryExpression : BoundExpression
    {
        public BoundBinaryExpression(BoundExpression left, BoundBinaryOperatorKind operatorKind, BoundExpression right)
        {
            Left = left;
            OperatorKind = operatorKind;
            Right = right;
        }

        public BoundExpression Left { get; }
        public BoundBinaryOperatorKind OperatorKind { get; }
        public BoundExpression Right { get; }

        public override Type Type => Left.Type;

        public override BoundNodeKind Kind => BoundNodeKind.UnaryExpression;
    }
    internal sealed class BoundLiteralExpression : BoundExpression
    {
        public BoundLiteralExpression(object value)
        {
            Value = value;
        }

        public object Value { get; }

        public override Type Type => Value.GetType();

        public override BoundNodeKind Kind => BoundNodeKind.LiteralExpression;
    }
    internal enum BoundUnaryOperatorKind
    {
        Identity,
        Negation,
    }
    internal abstract class BoundExpression : BoundNode
    {
        public abstract Type Type { get; }
    }
}