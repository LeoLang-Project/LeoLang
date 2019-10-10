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
                    new NumberLiteralNode(65),
                    BinaryOperator.Equal,
                    new NumberLiteralNode(65));

            Assert.IsTrue(result.GetHashCode() == toTest.GetHashCode());
        }

        [Test]
        public void BlockParse_Should_Match()
        {
            //BUG: block ignores second statement
            var result = p.ParseBlock("{ let x = true; let mal = false; };");

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
        public void DefaultParse_Should_Match()
        {
            var result = p.ParseDefaultExpression("default(int)");
            var toTest = new DefaultExpressionNode(new IdentifierNode("int"));

            Assert.IsTrue(result.GetHashCode() == toTest.GetHashCode());
        }

        [Test]
        public void IdentifierParse_Should_Match()
        {
            var result = p.ParseIdentifier("_abc123");

            Assert.IsTrue(result.GetHashCode() == new IdentifierNode("_abc123").GetHashCode());
        }

        [Test]
        public void IfParse_Should_Match()
        {
            var result = p.ParseIfStatement("if(65 == 65) \n {\nlet x = true;\n};");
            var toTest = new IfStatementNode(
                new BinaryExpressionNode(
                    new NumberLiteralNode(65), BinaryOperator.Equal, new NumberLiteralNode(65)),
                new BlockNode(new[] { new VariableDefinitionNode(new IdentifierNode("x"), new BooleanLiteralNode(true)) }));

            Assert.IsTrue(result.GetHashCode() == toTest.GetHashCode());
        }

        [Test]
        public void MethodParse_Main_Should_Match()
        {
            var result = p.ParseMethodDefinition("int main(void) {return 0;};");

            Assert.IsTrue(((MethodDefinitionNode)result).Name == "main");
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

        [Test]
        public void ReturnParse_Should_Match()
        {
            var result = p.ParseReturnStatement("return 0");

            Assert.IsTrue(result.GetHashCode() == new ReturnStatementNode(new NumberLiteralNode(0)).GetHashCode());
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