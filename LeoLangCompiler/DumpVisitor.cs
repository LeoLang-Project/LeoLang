using LeoLang.Core;
using System.Text;

namespace LeoLangCompiler
{
    public class DumpVisitor : Visitor
    {
        public override void Visit(SyntaxNode n)
        {
            System.Console.WriteLine(ObjectDumper.Dump(n));
        }

        private StringBuilder _builder = new StringBuilder();

        private int Indent = 0;

        private string getIndent() => new string(' ', Indent);
    }
}