using System;
using System.Collections.Generic;
using System.Linq;

namespace LLC.Syntax
{
    class SyntaxTree
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
    }
}