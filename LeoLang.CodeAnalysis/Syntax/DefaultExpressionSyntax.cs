using System.Collections.Generic;

namespace LeoLang.CodeAnalysis.Syntax
{
    public sealed class DefaultExpressionSyntax : ExpressionSyntax
    {
        public DefaultExpressionSyntax(SyntaxToken defaultToken, SyntaxToken identifier)
        {
            DefaultToken = defaultToken;
            Identifier = identifier;
        }

        public override SyntaxKind Kind => SyntaxKind.DefaultExpression;

        public SyntaxToken DefaultToken { get; }
        public SyntaxToken Identifier { get; }
    }
}