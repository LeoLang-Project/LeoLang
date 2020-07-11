namespace LeoLang.CodeAnalysis.Syntax
{
    public class ParenthesizedExpressionSyntax : ExpressionSyntax
    {
        public ParenthesizedExpressionSyntax(SyntaxTree syntaxTree, SyntaxToken openParenthesizeToken, ExpressionSyntax expression, SyntaxToken closeParenthesizeToken)
            : base(syntaxTree)
        {
            OpenParenthesizeToken = openParenthesizeToken;
            Expression = expression;
            CloseParenthesizeToken = closeParenthesizeToken;
        }

        public override SyntaxKind Kind => SyntaxKind.ParenthesizedExpression;

        public SyntaxToken OpenParenthesizeToken { get; }
        public ExpressionSyntax Expression { get; }
        public SyntaxToken CloseParenthesizeToken { get; }

    }
}