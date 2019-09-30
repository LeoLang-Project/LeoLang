using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using CommandLine.Text;
using LeoLang.Core;

namespace LeoLangCompiler
{
    public class Options
    {
        public SyntaxNode AST { get; set; }

        [Option("input", HelpText = "Input file to compile", Required = true)]
        public string Input { get; set; }

        [Option("output", HelpText = "Output file to compile", Required = true)]
        public string Output { get; set; }

        [Option("verbose", HelpText = "Enables full logging", Required = true)]
        public bool Verbose { get; set; }
    }
}