using NUnit.Framework;
using LeoLang.Core;
using LeoLang.Core.AST;

namespace Tests
{
    public class ParserTests
    {
        [Test]
        public void BooleanParse_Should_Match()
        {
            var result = p.ParseBoolean("true");

            Assert.IsTrue(((BooleanLiteralNode)result).Value == true);
        }

        [Test]
        public void IdentifierParse_Should_Match()
        {
            var result = p.ParseIdentifier("_abc123");

            Assert.IsTrue(((IdentifierNode)result).Name == "_abc123");
        }

        [Test]
        public void MethodParse_Should_Match()
        {
            var result = p.ParseMethodDefinition("meth main endmeth");

            Assert.IsTrue(((IdentifierNode)result).Name == "_abc123");
        }

        [SetUp]
        public void Setup()
        {
            p = new LeoParser();
        }

        [Test]
        public void Test1()
        {
            var result = p.Parse("meth hello as Int32\nlet x = true;\nend meth");
            Assert.Pass();
        }

        private LeoParser p;
    }
}