using dnlib.DotNet;
using LeoLang.Core;
using Loyc.Syntax;
using System.Collections.Generic;
using ILogger = Serilog.ILogger;

namespace LeoLangCompiler
{
    public class CompilerPipelineContext
    {
        public List<CompilerInformation> InformationPool = new List<CompilerInformation>();
        public LNode AST { get; set; }
        public Options CmdArgs { get; set; }

        public ILogger Logger { get; set; }

        public ModuleDefUser Module { get; set; }
    }
}