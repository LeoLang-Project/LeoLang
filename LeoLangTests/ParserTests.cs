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

        private LeoParser p;
    }
}