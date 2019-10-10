using System;
using LeoLang.Core;
using PipelineNet.Middleware;

namespace LeoLangCompiler.Middlewares
{
    public class LoweringMiddleware : IMiddleware<CompilerPipelineContext>
    {
        public void Run(CompilerPipelineContext parameter, Action<CompilerPipelineContext> next)
        {
            var runner = new StrategyRunner<SyntaxNode>();
            //ToDo: add lowering strategies

            next(parameter);
        }
    }
}