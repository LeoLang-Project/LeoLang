using System;
using System.Collections.Generic;
using System.Linq;
using LeoLang.CodeAnalysis.Symbols;
using LeoLang.CodeAnalysis.Syntax;
using LeoLang.Core;

namespace LeoLang.CodeAnalysis.Binding
{
    internal sealed class Binder
    {
        private readonly DiagnosticBag _diagnostics = new DiagnosticBag();
        private Dictionary<VariableSymbol, object> _variables;

        public Binder(Dictionary<VariableSymbol, object> variables)
        {
            _variables = variables;
        }

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
                case SyntaxKind.NameExpression:
                    return BindNameExpression((NameExpressionSyntax)syntax);
                case SyntaxKind.AssignmentExpression:
                    return BindAssignmentExpression((AssignmentExpressionSyntax)syntax);
                case SyntaxKind.TypeOfExpression:
                    return BindTypeOfExpression((TypeOfExpressionSyntax)syntax);
                default:
                    throw new Exception($"Unexpected syntax {syntax.Kind}");
            }
        }

        private BoundExpression BindTypeOfExpression(TypeOfExpressionSyntax syntax)
        {
            var typename = syntax.Identifier.Text;
            var boundValue = (typename); //ToDo fix type binding

            if (syntax.Identifier.Kind == SyntaxKind.IdentifierToken && boundValue != null)
            {
                return new BoundTypeOfExpression(new BoundLiteralExpression(boundValue));
            }

            _diagnostics.ReportNotBindable(syntax.TypeToken.Span, BoundNodeKind.TypeOfExpression);
            return new BoundLiteralExpression(Maybe.None<object>());
        }

        private BoundExpression BindAssignmentExpression(AssignmentExpressionSyntax syntax)
        {
            var name = syntax.IdentifierToken.Text;
            var boundExpression = BindExpression(syntax.Expression);

            var existingVariable = _variables.Keys.FirstOrDefault(v => v.Name == name);
            if(existingVariable != null)
            {
                _variables.Remove(existingVariable);
            }

            var variable = new VariableSymbol(name, boundExpression.Type);
            _variables[variable] = null;
            
            return new BoundAssignmentExpression(variable, boundExpression);
        }

        private BoundExpression BindNameExpression(NameExpressionSyntax syntax)
        {
            var name = syntax.IdentifierToken.Text;

            var variable = _variables.Keys.FirstOrDefault(v => v.Name == name);

            if(variable == null)
            {
                Diagnostics.ReportUndefinedName(syntax.IdentifierToken.Span, name);
                return new BoundLiteralExpression(0);
            }

            var type = variable.GetType();
            return new BoundVariableExpression(variable);
        }

        private BoundExpression BindDefaultExpression(DefaultExpressionSyntax syntax)
        {
            var boundValue = DefaultTable.GetValue(syntax.Identifier.Text); //ToDo: to fix error implement identifier in lexer

            if (syntax.DefaultToken.Kind == SyntaxKind.DefaultKeyword && syntax.Identifier.Kind == SyntaxKind.IdentifierToken
                && boundValue != null)
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