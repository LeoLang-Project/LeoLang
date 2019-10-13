using PipelineNet.Middleware;
using System;

namespace LeoLangCompiler.Middlewares
{
    public class SemanticMiddleware : IMiddleware<CompilerPipelineContext>
    {
        public void Run(CompilerPipelineContext parameter, Action<CompilerPipelineContext> next)
        {
            next(parameter);
        }
    }
}