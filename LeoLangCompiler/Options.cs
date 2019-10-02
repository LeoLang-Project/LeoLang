using CommandLine;

namespace LeoLangCompiler
{
    public class Options
    {
        [Option('i', "input", HelpText = "Input file to compile", Required = true)]
        public string Input { get; set; }

        [Option('o', "output", HelpText = "Output file to compile", Required = true)]
        public string Output { get; set; }

        [Option('v', "verbose", HelpText = "Enables full logging", Required = true)]
        public bool Verbose { get; set; }
    }
}