using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLang.CodeAnalysis.Syntax
{
    public sealed class CompilationUnitSyntax : SyntaxNode
    {
        public CompilationUnitSyntax(ExpressionSyntax expression, SyntaxToken endOfFileToken)
        {
            Expression = expression;
            EndOfFileToken = endOfFileToken;
        }

        public override SyntaxKind Kind => SyntaxKind.CompilationUnit;
        public ExpressionSyntax Expression { get; }
        public SyntaxToken EndOfFileToken { get; }
    }
}