using NUnit.Framework;
using LeoLang.Core;
using LeoLang.Core.AST;
using LeoLang.Core.AST.Expressions;
using LeoLang.Core.AST.Statements;

namespace Tests
{
    public class ParserTests
    {
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

        [Test]
        public void using_test()
        {
            var res = p.ParseUsingDeclaration("using System.Runtime.Compilerservice;");
        }

        private LeoParser p;
    }
}