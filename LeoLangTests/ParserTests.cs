using NUnit.Framework;
using LeoLang.Core.AST;

namespace Tests
{
    public class ParserTests
    {
        [Test]
        public void call_test()
        {
            var res = p.ParseCallExpression("print(12, 5, 4)");
        }

        [SetUp]
        public void Setup()
        {
            p = new LeoParser();
        }

        [Test]
        public void struct_test()
        {
            var res = p.ParseStructDeklaration("struct hello { field int mynum = 5; };");
        }

        private LeoParser p;
    }
}