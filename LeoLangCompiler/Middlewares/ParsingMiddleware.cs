using System;
using System.IO;
using LeoLang.Core;
using PipelineNet.Middleware;

namespace LeoLangCompiler.Middlewares
{
    public class ParsingMiddleware : IMiddleware<CompilerPipelineContext>
    {
        public void Run(CompilerPipelineContext arg, Action<CompilerPipelineContext> next)
        {
            var content = File.ReadAllText(arg.CmdArgs.Input);
            var parser = new LeoParser();

            arg.AST = parser.Parse(content, arg.CmdArgs.Input);

            var dumper = new DumpVisitor();
            dumper.Visit(arg.AST);

            next(arg);
        }
    }
}