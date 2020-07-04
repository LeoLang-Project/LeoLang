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

        private void Report(TextSpan span, string message)
        {
            var diagnostic = new Diagnostic(span, message);
            _diagnostics.Add(diagnostic);
        }

        public void ReportUndefinedName(TextSpan span, string name)
        {
            var message = $"Variable '{name}' doesn't exist.";
            Report(span, message);
        }

        public void ReportVariableAlreadyDeclared(TextSpan span, string name)
        {
            var message = $"Variable '{name}' is already declared.";
            Report(span, message);
        }

        public void ReportCannotAssign(TextSpan span, string name)
        {
            var message = $"Variable '{name}' is read-only and cannot be assigned to.";
            Report(span, message);
        }

        public void ReportInvalidNumber(TextSpan span, string text, TypeSymbol TypeSymbol)
        {
            var message = $"The number {text} isn't valid {TypeSymbol}.";
            Report(span, message);
        }

        public void ReportUnterminatedString(TextSpan span)
        {
            var message = "Unterminated string literal.";
            Report(span, message);
        }

        public void ReportBadCharacter(int position, char character)
        {
            var span = new TextSpan(position, 1);
            var message = $"Bad character input: '{character}'.";
            Report(span, message);
        }

        public void ReportUnexpectedToken(TextSpan span, SyntaxKind actualKind, SyntaxKind expectedKind)
        {
            var message = $"Unexpected token <{actualKind}>, expected <{expectedKind}>.";
            Report(span, message);
        }

        public void ReportUndefinedUnaryOperator(TextSpan span, string operatorText, TypeSymbol operandTypeSymbol)
        {
            var message = $"Unary operator '{operatorText}' is not defined for TypeSymbol '{operandTypeSymbol}'.";
            Report(span, message);
        }

        public void ReportUndefinedBinaryOperator(TextSpan span, string operatorText, TypeSymbol leftTypeSymbol, TypeSymbol rightTypeSymbol)
        {
            var message = $"Binary operator '{operatorText}' is not defined for TypeSymbols '{leftTypeSymbol}' and '{rightTypeSymbol}'.";
            Report(span, message);
        }

        internal void ReportNoDefault(TextSpan span, string value)
        {
            var message = $"No Default Value found for TypeSymbol '{value}'.";
            Report(span, message);
        }

        public void ReportNotBindable(TextSpan span, BoundNodeKind kind)
        {
            var message = $"Unable to bind {kind}";
            Report(span, message);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _diagnostics.GetEnumerator();
        }

        public void ReportCannotConvert(TextSpan span, TypeSymbol fromTypeSymbol, TypeSymbol toTypeSymbol)
        {
            var message = $"Cannot convert TypeSymbol '{fromTypeSymbol}' to '{toTypeSymbol}'.";
            Report(span, message);
        }
    }
}