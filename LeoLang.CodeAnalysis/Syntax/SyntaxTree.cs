using System;
using System.Collections.Generic;
using System.Linq;

namespace Leo.CodeAnalysis.Syntax
{
    public class SyntaxTree
    {
        public SyntaxTree(IEnumerable<string> diagnostics, ExpressionSyntax root, SyntaxToken endoffileToken)
        {
            Diagnostics = diagnostics.ToArray();
            Root = root;
            EndoffileToken = endoffileToken;
        }

        public IReadOnlyList<string> Diagnostics { get; }
        public ExpressionSyntax Root { get; }
        public SyntaxToken EndoffileToken { get; }

        public static SyntaxTree Parse(string line)
        {
            var parser = new Parser(line);
            return parser.Parse();
        }
    }
}