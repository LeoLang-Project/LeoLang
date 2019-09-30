using CommandLine;
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
            var pipeline = new Pipeline<Options>(new ActivatorMiddlewareResolver());

            pipeline.Execute(obj);
        }
    }
}