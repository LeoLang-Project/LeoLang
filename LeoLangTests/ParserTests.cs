using NUnit.Framework;
using LeoLang.Core;
using LeoLang.Core.AST;
using LeoLang.Core.AST.Expressions;
using LeoLang.Core.AST.Statements;

namespace Tests
{
    public class ParserTests
    {
        [Test]
        public void CompilationUnit_Should_Pass()
        {
            var res = p.ParseCompilationUnit("void hello(void) { var x = false; }; void world(void) { var y = true; };");
        }

        [Test]
        public void enum_test()
        {
            var res = p.ParseEnumDefinition("enum hello { red = 0, blue = 1, };");
        }

        [SetUp]
        public void Setup()
        {
            p = new LeoParser();
        }

        private LeoParser p;
    }
}