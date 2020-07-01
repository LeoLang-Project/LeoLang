using System;
using System.Collections.Generic;
using LeoLang.CodeAnalysis.Syntax;
using LeoLang.Core;

namespace LeoLang.CodeAnalysis.Binding
{
    internal sealed class Binder
    {
        private readonly DiagnosticBag _diagnostics = new DiagnosticBag();

        public DiagnosticBag Diagnostics => _diagnostics;

        public BoundExpression BindExpression(ExpressionSyntax syntax)
        {
            switch (syntax.Kind)
            {
                case SyntaxKind.LiteralExpression:
                    return BindLiteralExpression((LiteralExpressionSyntax)syntax);
                case SyntaxKind.UnaryExpression:
                    return BindUnaryExpression((UnaryExpressionSyntax)syntax);
                case SyntaxKind.BinaryExpression:
                    return BindBinaryExpression((BinaryExpressionSyntax)syntax);
                case SyntaxKind.SomeExpression:
                    return BindSomeExpression((SomeExpressionSyntax)syntax);
                case SyntaxKind.DefaultExpression:
                    return BindDefaultExpression((DefaultExpressionSyntax)syntax);
                case SyntaxKind.ParenthesizedExpression:
                    return BindParenthesizedExpression((ParenthesizedExpressionSyntax)syntax);
                default:
                    throw new Exception($"Unexpected syntax {syntax.Kind}");
            }
        }

        private BoundExpression BindDefaultExpression(DefaultExpressionSyntax syntax)
        {
            var boundValue = DefaultTable.GetValue(syntax.Identifier.Text); //ToDo: to fix error implement identifier in lexer

            if (syntax.DefaultToken.Kind == SyntaxKind.DefaultKeyword && syntax.Identifier.Kind == SyntaxKind.IdentifierToken)
            {
                return new BoundDefaultExpression(new BoundLiteralExpression(boundValue));
            }

            _diagnostics.ReportNoDefault(syntax.Identifier.Span, syntax.Identifier.Text);
            return new BoundLiteralExpression(boundValue);
        }

        private BoundExpression BindParenthesizedExpression(ParenthesizedExpressionSyntax syntax)
        {
            return BindExpression(syntax.Expression);
        }

        private BoundExpression BindLiteralExpression(LiteralExpressionSyntax syntax)
        {
            var value = syntax.Value ?? 0;
            return new BoundLiteralExpression(value);
        }

        private BoundExpression BindSomeExpression(SomeExpressionSyntax syntax)
        {
            var boundValue = BindExpression(syntax.Value);

            if(syntax.Value.Kind != SyntaxKind.SomeKeyword || syntax.Value.Kind != SyntaxKind.EmptyKeyword)
            {
                return new BoundSomeExpression(boundValue);
            }

            _diagnostics.ReportNotBindable(syntax.SomeToken.Span, boundValue.Kind);
            return boundValue;
        }

        private BoundExpression BindUnaryExpression(UnaryExpressionSyntax syntax)
        {
            var boundOperand = BindExpression(syntax.Operand);
            var boundOperator = BoundUnaryOperator.Bind(syntax.OperatorToken.Kind, boundOperand.Type);

            if (boundOperator == null)
            {
                _diagnostics.ReportUndefinedUnaryOperator(syntax.OperatorToken.Span, syntax.OperatorToken.Text, boundOperand.Type);
                return boundOperand;
            }

            return new BoundUnaryExpression(boundOperator, boundOperand);
        }

        private BoundExpression BindBinaryExpression(BinaryExpressionSyntax syntax)
        {
            var boundLeft = BindExpression(syntax.Left);
            var boundRight = BindExpression(syntax.Right);
            var boundOperator = BoundBinaryOperator.Bind(syntax.OperatorToken.Kind, boundLeft.Type, boundRight.Type);

            if (boundOperator == null)
            {
                _diagnostics.ReportUndefinedBinaryOperator(syntax.OperatorToken.Span, syntax.OperatorToken.Text, boundLeft.Type, boundRight.Type);
                return boundLeft;
            }

            return new BoundBinaryExpression(boundLeft, boundOperator, boundRight);
        }
    }
}