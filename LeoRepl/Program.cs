

using LeoLang.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LeoRepl
{
    class Program
    {
        static void Main(string[] args)
        {
            var repl = new LeoRepl();
            repl.Run();
        }
    }
    class TextSpanComparer : IComparer<TextSpan>
    {
        public int Compare([AllowNull] TextSpan x, [AllowNull] TextSpan y)
        {
            int cmp = x.Start - y.Start;
            if (cmp == 0) cmp = x.Length - y.Length;
            return cmp;
        }
    }
}