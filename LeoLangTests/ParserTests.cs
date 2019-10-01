using NUnit.Framework;
using LeoLang.Core;
using LeoLang.Core.AST;

namespace Tests
{
    public class ParserTests
    {
        [Test]
        public void IdentiferParsse_Should_Match()
        {
            var result = p.Parse("_abc123");

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
            var result = p.Parse("let abc = true");
            Assert.Pass();
        }

        private LeoParser p;
    }
}