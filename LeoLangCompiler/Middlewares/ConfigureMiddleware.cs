using PipelineNet.Middleware;
using Serilog;
using System;

namespace LeoLangCompiler.Middlewares
{
    public class ConfigureMiddleware : IMiddleware<CompilerPipelineContext>
    {
        public void Run(CompilerPipelineContext arg, Action<CompilerPipelineContext> next)
        {
            var log = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

            arg.Logger = log;

            next(arg);
        }
    }
}