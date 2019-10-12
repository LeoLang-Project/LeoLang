using System;
using System.IO;
using LeoLang.Core;
using LeoLang.Core.AST;
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

            arg.AST.ApplyVisitor(dumper);

            if (arg.CmdArgs.AstFilename != null)
            {
                File.WriteAllText(arg.CmdArgs.AstFilename, ObjectDumper.Dump(arg.AST));
            }

            next(arg);
        }
    }
}