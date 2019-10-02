using LeoLang.Core;
using Serilog;

namespace LeoLangCompiler
{
    public class CompilerPipelineContext
    {
        public SyntaxNode AST { get; set; }
        public Options CmdArgs { get; set; }

        public ILogger Logger { get; set; }
    }
}