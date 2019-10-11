using LeoLang.Core;
using YamlDotNet.Serialization;

namespace LeoLangCompiler
{
    public class DumpVisitor : Visitor
    {
        public override void Visit(SyntaxNode n)
        {
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(n);
            System.Console.WriteLine(yaml);
        }
    }
}