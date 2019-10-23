using LeoLang.Core;
using System;
using System.IO;

namespace LeoLangCompiler
{
    public class DumpVisitor : Visitor
    {
        public override void Visit(SyntaxNode n)
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\editor.txt", ObjectDumper.Dump(n));
        }
    }
}