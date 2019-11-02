using System;
using LeoLang.Core;
using LeoLangCompiler.Strategies.Lowering;
using PipelineNet.Middleware;

namespace LeoLangCompiler.Middlewares
{
    public class LoweringMiddleware : IMiddleware<CompilerPipelineContext>
    {
        public void Run(CompilerPipelineContext parameter, Action<CompilerPipelineContext> next)
        {
            var runner = new StrategyRunner<SyntaxNode>();
            //ToDo: add lowering strategies

            runner.Add(new WhileLoweringStrategy());

            var loop = ((BlockNode)parameter.AST).FindChildrenOfType<StatementNode>();
            var result = runner.Run(parameter.AST);

            next(parameter);
        }
    }
}