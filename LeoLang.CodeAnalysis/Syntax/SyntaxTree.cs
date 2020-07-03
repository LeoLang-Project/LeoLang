using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeoLang.CodeAnalysis.Syntax
{
    public class SyntaxTree
    {
        public SyntaxTree(DiagnosticBag diagnostics, ExpressionSyntax root, SyntaxToken endoffileToken)
        {
            Diagnostics = diagnostics;
            Root = root;
            EndoffileToken = endoffileToken;
        }

        public DiagnosticBag Diagnostics { get; }
        public ExpressionSyntax Root { get; }
        public SyntaxToken EndoffileToken { get; }

        public static SyntaxTree Parse(string line)
        {
            var parser = new Parser(line);
            return parser.Parse();
        }

        public static IEnumerable<SyntaxToken> ParseTokens(string line)
        {
            var lexer = new Lexer(line);
            while(true)
            {
                var token = lexer.Lex();
                if (token.Kind == SyntaxKind.EndOfFileToken) break;
                yield return token;
            }
        }
    }
}