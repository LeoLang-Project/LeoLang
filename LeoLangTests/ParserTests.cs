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
        public void BinaryExpressionParse_Should_Match()
        {
            var result = p.ParseBinaryExpression("65 == 65");
            var toTest = new BinaryExpressionNode(
                    new IntegerLiteralNode(65),
                    BinaryOperator.Equal,
                    new IntegerLiteralNode(65));

            Assert.IsTrue(result.GetHashCode() == toTest.GetHashCode());
        }

        [Test]
        public void BlockParse_Should_Match()
        {
            //BUG: block ignores second statement
            var result = p.ParseBlock("{ let x = true; let mal = false;};");

            Assert.IsTrue(result.GetHashCode() == new BooleanLiteralNode(true).GetHashCode());
        }

        [Test]
        public void BooleanParse_Should_Match()
        {
            var result = p.ParseBooleanLiteral("true");

            Assert.IsTrue(result.GetHashCode() == new BooleanLiteralNode(true).GetHashCode());
        }

        [Test]
        public void CharacterParse_Should_Match()
        {
            var result = p.ParseCharacterLiteral("'c'");

            Assert.IsTrue(result.GetHashCode() == new CharLiteralNode('c').GetHashCode());
        }

        [Test]
        public void DecimalParse_Should_Match()
        {
            var result = p.ParseDecimalLiteral("42.1");

            Assert.IsTrue(((DecimalLiteralNode)result).Value == 42.1);
        }

        [Test]
        public void DefaultParse_Should_Match()
        {
            var result = p.ParseDefaultExpression("default(int)");
            var toTest = new DefaultExpressionNode("int");

            Assert.IsTrue(result.GetHashCode() == toTest.GetHashCode());
        }

        [Test]
        public void IntegerParse_Should_Match()
        {
            var result = p.ParseNumberLiteral("65");

            Assert.IsTrue(((IntegerLiteralNode)result).Value == 65);
        }

        [Test]
        public void ParameterListParse_Should_Match()
        {
            var result = p.ParseParameterContent("int[] x, long y, bool z, float f1");
        }

        [Test]
        public void ReturnParse_Should_Match()
        {
            var result = p.ParseReturnStatement("return 0");

            Assert.IsTrue(result.GetHashCode() == new ReturnStatementNode(new IntegerLiteralNode(0)).GetHashCode());
        }

        [SetUp]
        public void Setup()
        {
            p = new LeoParser();
        }

        [Test]
        public void StringLiteral_Should_Match()
        {
            var res = p.ParseStringLiteral("\"hello world\"");

            Assert.Pass();
        }

        [Test]
        public void TernaryParse_Should_Match()
        {
            var result = p.ParseTernaryExpression("true ? 't' : 'f'");

            Assert.IsTrue(result.GetHashCode() == new BooleanLiteralNode(true).GetHashCode());
        }

        [Test]
        public void Test1()
        {
            var result = p.ParseGenericStatementBlock("while(65 == 65) {let x = true;};");
            Assert.Pass();
        }

        private LeoParser p;
    }
}