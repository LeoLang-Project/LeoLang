using System;
using System.Collections.Generic;

namespace Leo.CodeAnalysis
{
    class ParenthesizedExpressionSyntax : ExpressionSyntax
    {
        public ParenthesizedExpressionSyntax(SyntaxToken openParenthesizeToken, ExpressionSyntax expression, SyntaxToken closeParenthesizeToken)
        {
            OpenParenthesizeToken = openParenthesizeToken;
            Expression = expression;
            CloseParenthesizeToken = closeParenthesizeToken;
        }

        public override SyntaxKind Kind => SyntaxKind.ParenthesizedExpression;

        public SyntaxToken OpenParenthesizeToken { get; }
        public ExpressionSyntax Expression { get; }
        public SyntaxToken CloseParenthesizeToken { get; }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return OpenParenthesizeToken;
            yield return Expression;
            yield return CloseParenthesizeToken;
        }
    }
}