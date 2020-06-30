using System.Collections.Generic;

namespace LeoLang.CodeAnalysis.Syntax
{
    public sealed class SomeExpressionSyntax : ExpressionSyntax
    {
        public SomeExpressionSyntax(SyntaxToken someToken, ExpressionSyntax value)
        {
            SomeToken = someToken;
            Value = value;
        }

        public override SyntaxKind Kind => SyntaxKind.SomeExpression;

        public SyntaxToken SomeToken { get; }
        public ExpressionSyntax Value { get; }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return SomeToken;
            yield return Value;
        }
    }
}