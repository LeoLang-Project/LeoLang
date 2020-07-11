using System;
using System.Collections;
using System.Collections.Generic;
using LeoLang.CodeAnalysis.Binding;
using LeoLang.CodeAnalysis.Symbols;
using LeoLang.CodeAnalysis.Syntax;
using LeoLang.CodeAnalysis.Text;

namespace LeoLang.CodeAnalysis.Diagnostics
{
    public sealed class DiagnosticBag : IEnumerable<Diagnostic>
    {
        private readonly List<Diagnostic> _diagnostics = new List<Diagnostic>();

        public IEnumerator<Diagnostic> GetEnumerator() => _diagnostics.GetEnumerator();

        public void AddRange(DiagnosticBag diagnostics)
        {
            _diagnostics.AddRange(diagnostics._diagnostics);
        }

        private void Report(TextLocation span, string message)
        {
            var diagnostic = new Diagnostic(span, message);
            _diagnostics.Add(diagnostic);
        }

        public void ReportUndefinedName(TextLocation span, string name)
        {
            var message = $"Variable '{name}' doesn't exist.";
            Report(span, message);
        }

        public void ReportVariableAlreadyDeclared(TextLocation span, string name)
        {
            var message = $"Variable '{name}' is already declared.";
            Report(span, message);
        }

        public void ReportInvalidBreakOrContinue(TextLocation span, string text)
        {
            var message = $"The keyword '{text}' can only be used inside of loops.";
            Report(span, message);
        }


        public void ReportCannotAssign(TextLocation span, string name)
        {
            var message = $"Variable '{name}' is read-only and cannot be assigned to.";
            Report(span, message);
        }

        public void ReportInvalidNumber(TextLocation span, string text, TypeSymbol TypeSymbol)
        {
            var message = $"The number {text} isn't valid {TypeSymbol}.";
            Report(span, message);
        }

        public void ReportUnterminatedString(TextLocation span)
        {
            var message = "Unterminated string literal.";
            Report(span, message);
        }

        public void ReportUndefinedFunction(TextLocation span, string name)
        {
            var message = $"Function '{name}' doesn't exist.";
            Report(span, message);
        }

        public void ReportInvalidExpressionStatement(TextLocation location)
        {
            var message = $"Only assignment and call expressions can be used as a statement.";
            Report(location, message);
        }

        public void ReportWrongArgumentCount(TextLocation span, string name, int expectedCount, int actualCount)
        {
            var message = $"Function '{name}' requires {expectedCount} arguments but was given {actualCount}.";
            Report(span, message);
        }

        public void ReportWrongArgumentType(TextLocation span, string name, TypeSymbol expectedType, TypeSymbol actualType)
        {
            var message = $"Parameter '{name}' requires a value of type '{expectedType}' but was given a value of type '{actualType}'.";
            Report(span, message);
        }

        public void ReportExpressionMustHaveValue(TextLocation span)
        {
            var message = "Expression must have a value.";
            Report(span, message);
        }

        public void ReportBadCharacter(TextLocation location, char character)
        {
            var message = $"Bad character input: '{character}'.";
            Report(location, message);
        }

        public void ReportUnexpectedToken(TextLocation span, SyntaxKind actualKind, SyntaxKind expectedKind)
        {
            var message = $"Unexpected token <{actualKind}>, expected <{expectedKind}>.";
            Report(span, message);
        }

        public void ReportAllPathsMustReturn(TextLocation span)
        {
            var message = "Not all code paths return a value.";
            Report(span, message);
        }

        public void ReportUndefinedUnaryOperator(TextLocation span, string operatorText, TypeSymbol operandTypeSymbol)
        {
            var message = $"Unary operator '{operatorText}' is not defined for TypeSymbol '{operandTypeSymbol}'.";
            Report(span, message);
        }

        public void ReportUndefinedBinaryOperator(TextLocation span, string operatorText, TypeSymbol leftTypeSymbol, TypeSymbol rightTypeSymbol)
        {
            var message = $"Binary operator '{operatorText}' is not defined for TypeSymbols '{leftTypeSymbol}' and '{rightTypeSymbol}'.";
            Report(span, message);
        }

        internal void ReportNoDefault(TextLocation span, string value)
        {
            var message = $"No Default Value found for TypeSymbol '{value}'.";
            Report(span, message);
        }

        public void ReportNotBindable(TextLocation span, BoundNodeKind kind)
        {
            var message = $"Unable to bind {kind}";
            Report(span, message);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _diagnostics.GetEnumerator();
        }

        public void ReportCannotConvert(TextLocation span, TypeSymbol fromTypeSymbol, TypeSymbol toTypeSymbol)
        {
            var message = $"Cannot convert TypeSymbol '{fromTypeSymbol}' to '{toTypeSymbol}'.";
            Report(span, message);
        }

        public void ReportSymbolAlreadyDeclared(TextLocation span, string name)
        {
            var message = $"'{name}' is already declared.";
            Report(span, message);
        }

        public void ReportUndefinedType(TextLocation span, string name)
        {
            var message = $"Type '{name}' doesn't exist.";
            Report(span, message);
        }

        public void ReportCannotConvertImplicitly(TextLocation span, TypeSymbol fromType, TypeSymbol toType)
        {
            var message = $"Cannot convert type '{fromType}' to '{toType}'. An explicit conversion exists (are you missing a cast?)";
            Report(span, message);
        }

        public void ReportParameterAlreadyDeclared(TextLocation span, string parameterName)
        {
            var message = $"A parameter with the name '{parameterName}' already exists.";
            Report(span, message);
        }

        public void ReportInvalidReturn(TextLocation span)
        {
            var message = "The 'return' keyword can only be used inside of functions.";
            Report(span, message);
        }

        public void ReportInvalidReturnExpression(TextLocation span, string functionName)
        {
            var message = $"Since the function '{functionName}' does not return a value the 'return' keyword cannot be followed by an expression.";
            Report(span, message);
        }

        public void ReportMissingReturnExpression(TextLocation span, TypeSymbol returnType)
        {
            var message = $"An expression of type '{returnType}' expected.";
            Report(span, message);
        }

    }
}