using LeoLang.Core;
using PipelineNet.Middleware;
using System;

namespace LeoLangCompiler.Middlewares
{
    public class OptimizeAstMiddleware : IMiddleware<CompilerPipelineContext>
    {
        public void Run(CompilerPipelineContext parameter, Action<CompilerPipelineContext> next)
        {
            var runner = new StrategyRunner<SyntaxNode>();
            //ToDo: add optimizing strategies

            next(parameter);
        }
    }
}