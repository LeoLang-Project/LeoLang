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
    }
}