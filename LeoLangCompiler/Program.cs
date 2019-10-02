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

        private static void runParsed(Options obj)
        {
            var pipeline = new Pipeline<CompilerPipelineContext>(new ActivatorMiddlewareResolver());
            var context = new CompilerPipelineContext();

            pipeline.Add<ConfigureMiddleware>();
            pipeline.Add<ParsingMiddleware>();

            pipeline.Execute(context);
        }
    }
}