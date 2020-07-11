using System.Collections.Generic;

namespace LeoLang.CodeAnalysis.Syntax
{
    public sealed class LiteralExpressionSyntax : ExpressionSyntax
    {
        public LiteralExpressionSyntax(SyntaxTree syntaxTree, SyntaxToken literalToken, object value)
            : base(syntaxTree)
        {
            LiteralToken = literalToken;
            Value = value;
        }

        public LiteralExpressionSyntax(SyntaxTree syntaxTree, SyntaxToken literalToken)
            : this(syntaxTree, literalToken, literalToken.Value)
        {
           
        }

        public override SyntaxKind Kind => SyntaxKind.LiteralExpression;

        public SyntaxToken LiteralToken { get; }
        public object Value { get; }

    }
}