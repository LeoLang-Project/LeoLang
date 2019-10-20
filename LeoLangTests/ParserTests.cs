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
        public void BlockParse_Should_Match()
        {
            //BUG: block ignores second statement
            var result = p.ParseBlock("{ let x = true; let mal = false;};");

            Assert.IsTrue(result.GetHashCode() == new BooleanLiteralNode(true).GetHashCode());
        }

        [Test]
        public void DefaultParse_Should_Match()
        {
            var result = p.ParseDefaultExpression("default(int)");
            var toTest = new DefaultExpressionNode("int");

            Assert.IsTrue(result.GetHashCode() == toTest.GetHashCode());
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
        public void Test1()
        {
            var result = p.ParseBinLiteral("0b10101");
            Assert.Pass();
        }

        private LeoParser p;
    }
}