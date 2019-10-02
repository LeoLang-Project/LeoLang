using CommandLine;
using dnlib.DotNet;

namespace LeoLangCompiler
{
    public class Options
    {
        [Option('i', "input", HelpText = "Input file to compile", Required = true)]
        public string Input { get; set; }

        public ModuleKind Kind { get; set; }

        [Option("console", HelpText = "Create a console application")]
        public bool MakeConsole
        {
            get { return Kind == ModuleKind.Console; }
            set { Kind = value ? ModuleKind.Console : ModuleKind.Dll; }
        }

        [Option("dll", HelpText = "Create a dll")]
        public bool MakeDll
        {
            get { return Kind == ModuleKind.Dll; }
            set { Kind = value ? ModuleKind.Dll : ModuleKind.Dll; }
        }

        [Option('o', "output", HelpText = "Output file to compile", Required = true)]
        public string Output { get; set; }

        [Option('v', "verbose", HelpText = "Enables full logging", Required = true)]
        public bool Verbose { get; set; }
    }
}