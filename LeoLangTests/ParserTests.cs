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

        [SetUp]
        public void Setup()
        {
            p = new LeoParser();
        }

        [Test]
        public void unparsed_test()
        {
            var res = p.ParseUnparsedBlock("dom { <xml><child /></xml> }");
        }

        private LeoParser p;
    }
}