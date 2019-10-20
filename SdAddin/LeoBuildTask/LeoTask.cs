using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CommandLine;
using LeoLangCompiler;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ICSharpCode.Build.Tasks
{
    public sealed class Leo : ToolTask
    {
        public ITaskItem OutputAssembly { get; set; }

        public ITaskItem[] Sources { get; set; }

        public string TargetType { get; set; }

        public override bool Execute()
        {
            //ToDo: call compiler
            return base.Execute();
        }

        protected override string ToolName
        {
            get
            {
                return "LLC.exe";
            }
        }

        protected override string GenerateCommandLineCommands()
        {
            //ToDo: fix commandline args in leotask
            var opt = new Options();
            if (((OutputAssembly == null) && (Sources != null)) && (Sources.Length > 0))
            {
                OutputAssembly = new TaskItem(Path.GetFileNameWithoutExtension(this.Sources[0].ItemSpec));

                if (string.Equals(this.TargetType, "library", StringComparison.OrdinalIgnoreCase))
                {
                    OutputAssembly.ItemSpec += ".dll";
                    opt.MakeDll = true;
                }
                else
                {
                    OutputAssembly.ItemSpec += ".exe";
                    opt.MakeConsole = true;
                }
            }

            opt.Output = OutputAssembly.ItemSpec;
            opt.Input = Sources.First().ItemSpec;

            var cmdline = Parser.Default.FormatCommandLine<Options>(opt);
            File.WriteAllText(@"C:\Users\filmee24\Documents\cmd.txt", cmdline);
            return cmdline;
        }

        protected override string GenerateFullPathToTool()
        {
            return this.GetWorkingDirectory();
        }
    }
}