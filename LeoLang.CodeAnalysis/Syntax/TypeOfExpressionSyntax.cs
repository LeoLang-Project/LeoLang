using System.Collections.Generic;

namespace LeoLang.CodeAnalysis.Syntax
{
    internal class TypeOfExpressionSyntax : ExpressionSyntax
    {
        public TypeOfExpressionSyntax(SyntaxToken typeToken, SyntaxToken expressionSyntax)
        {
            TypeToken = typeToken;
            Identifier = expressionSyntax;
        }

        public SyntaxToken TypeToken { get; }
        public SyntaxToken Identifier { get; }

        public override SyntaxKind Kind =>  SyntaxKind.TypeOfExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return TypeToken;
            yield return Identifier;
        }
    }
}