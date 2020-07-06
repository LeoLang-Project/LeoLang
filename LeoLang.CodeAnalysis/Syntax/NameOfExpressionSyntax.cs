using LeoLang.CodeAnalysis.Syntax;

namespace LeoLang.CodeAnalysis
{
    public class NameOfExpressionSyntax : ExpressionSyntax
    {
        public NameOfExpressionSyntax(SyntaxToken nameOfToken, SyntaxToken openParan, SyntaxToken identifier, SyntaxToken closeParan)
        {
            NameOfToken = nameOfToken;
            OpenParan = openParan;
            Identifier = identifier;
            CloseParan = closeParan;
        }

        public SyntaxToken NameOfToken { get; }
        public SyntaxToken OpenParan { get; }
        public SyntaxToken Identifier { get; }
        public SyntaxToken CloseParan { get; }

        public override SyntaxKind Kind => SyntaxKind.NameOfExpression;
    }
}