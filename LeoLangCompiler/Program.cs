using CommandLine;
using LeoLangCompiler.Middlewares;
using PipelineNet.MiddlewareResolver;
using PipelineNet.Pipelines;
using System;

namespace LeoLangCompiler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(runParsed);

            Console.ReadLine();
        }

        private static void runParsed(Options opts)
        {
            var pipeline = new Pipeline<CompilerPipelineContext>(new ActivatorMiddlewareResolver());
            var context = new CompilerPipelineContext();
            context.CmdArgs = opts;

            pipeline.Add<ConfigureMiddleware>();
            pipeline.Add<ParsingMiddleware>();
            pipeline.Add<LoweringMiddleware>();
            pipeline.Add<OptimizeAstMiddleware>();
            pipeline.Add<EmitMiddleware>();

            pipeline.Execute(context);
        }
    }
}