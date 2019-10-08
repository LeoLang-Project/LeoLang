using PipelineNet.Middleware;
using System;

namespace LeoLangCompiler.Middlewares
{
    public class OptimizeAstMiddleware : IMiddleware<CompilerPipelineContext>
    {
        public void Run(CompilerPipelineContext parameter, Action<CompilerPipelineContext> next)
        {
            throw new NotImplementedException();
        }
    }
}