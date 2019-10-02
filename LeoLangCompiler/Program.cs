using CommandLine;
using LeoLangCompiler.Middlewares;
using PipelineNet.MiddlewareResolver;
using PipelineNet.Pipelines;

namespace LeoLangCompiler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(runParsed);
        }

        private static void runParsed(Options opts)
        {
            var pipeline = new Pipeline<CompilerPipelineContext>(new ActivatorMiddlewareResolver());
            var context = new CompilerPipelineContext();
            context.CmdArgs = opts;

            pipeline.Add<ConfigureMiddleware>();
            pipeline.Add<ParsingMiddleware>();
            pipeline.Add<EmitMiddleware>();

            pipeline.Execute(context);
        }
    }
}