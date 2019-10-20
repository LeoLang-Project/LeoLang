using LeoLang.Core;
using LeoLang.Core.AST;
using LeoLang.Core.AST.Statements;
using System;

namespace LeoLangCompiler.Strategies.Optimizing
{
    public class WhileOptimizer : IStrategy<SyntaxNode>
    {
        public SyntaxNode Do(SyntaxNode arg)
        {
            if (arg is StatementNode node && node.Name == "while")
            {
                if (node.Expression is BooleanLiteralNode cond)
                {
                    if (!cond.Value)
                    {
                        return null;
                    }
                }
            }

            return arg;
        }
    }
}