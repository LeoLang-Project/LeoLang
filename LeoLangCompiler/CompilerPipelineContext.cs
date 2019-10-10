using dnlib.DotNet;
using LeoLang.Core;
using ILogger = Serilog.ILogger;

namespace LeoLangCompiler
{
    public class CompilerPipelineContext
    {
        public SyntaxNode AST { get; set; }
        public Options CmdArgs { get; set; }

        public ILogger Logger { get; set; }

        public ModuleDefUser Module { get; set; }
    }
}