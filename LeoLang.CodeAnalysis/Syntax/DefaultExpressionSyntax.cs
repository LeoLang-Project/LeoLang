using System.Collections.Generic;

namespace LeoLang.CodeAnalysis.Syntax
{
    public sealed class DefaultExpressionSyntax : ExpressionSyntax
    {
        public DefaultExpressionSyntax(SyntaxTree syntaxTree, SyntaxToken defaultToken, SyntaxToken open, SyntaxToken identifier, SyntaxToken close)
            : base(syntaxTree)
        {
            DefaultToken = defaultToken;
            Open = open;
            Identifier = identifier;
            Close = close;
        }

        public override SyntaxKind Kind => SyntaxKind.DefaultExpression;

        public SyntaxToken DefaultToken { get; }
        public SyntaxToken Open { get; }
        public SyntaxToken Identifier { get; }
        public SyntaxToken Close { get; }
    }
}