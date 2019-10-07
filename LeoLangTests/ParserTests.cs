using NUnit.Framework;
using LeoLang.Core;
using LeoLang.Core.AST;

namespace Tests
{
    public class ParserTests
    {
        [Test]
        public void BinaryExpressionParse_Should_Match()
        {
            var result = p.ParseBinaryExpression("65 == 65");

            Assert.IsTrue(((CharLiteralNode)result).Value == 'c');
        }

        [Test]
        public void BooleanParse_Should_Match()
        {
            var result = p.ParseBooleanLiteral("true");

            Assert.IsTrue(((BooleanLiteralNode)result).Value == true);
        }

        [Test]
        public void CharacterParse_Should_Match()
        {
            var result = p.ParseCharacterLiteral("'c'");

            Assert.IsTrue(((CharLiteralNode)result).Value == 'c');
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
            var result = p.ParseMethodDefinition("void main(void) {};");

            Assert.IsTrue(((MethodDefinitionNode)result).Name == "main");
        }

        [Test]
        public void NumberParse_Should_Match()
        {
            var result = p.ParseNumberLiteral("65");

            Assert.IsTrue(((NumberLiteralNode)result).Value == 65);
        }

        [SetUp]
        public void Setup()
        {
            p = new LeoParser();
        }

        [Test]
        public void Test1()
        {
            var result = p.Parse("void main(int count) {let x = true;};");
            Assert.Pass();
        }

        private LeoParser p;
    }
}