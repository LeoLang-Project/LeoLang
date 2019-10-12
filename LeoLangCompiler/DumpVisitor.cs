using LeoLang.Core;

namespace LeoLangCompiler
{
    public class DumpVisitor : Visitor
    {
        public override void Visit(SyntaxNode n)
        {
            System.Console.WriteLine(ObjectDumper.Dump(n));
        }
    }
}