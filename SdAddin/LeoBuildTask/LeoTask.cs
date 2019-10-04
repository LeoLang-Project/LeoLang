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
        public ITaskItem OutputAssembly
        {
            get
            {
                return outputAssembly;
            }
            set
            {
                outputAssembly = value;
            }
        }

        public ITaskItem[] Sources
        {
            get
            {
                return sources;
            }
            set
            {
                sources = value;
            }
        }

        public string TargetType
        {
            get
            {
                return targetType;
            }
            set
            {
                targetType = value;
            }
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

            opt.Output = outputAssembly.ItemSpec;
            opt.Input = sources.First().ItemSpec;

            var cmdline = Parser.Default.FormatCommandLine<Options>(opt);
            File.WriteAllText(@"C:\Users\filmee24\Documents\cmd.txt", cmdline);
            return cmdline;
        }

        protected override string GenerateFullPathToTool()
        {
            return this.GetWorkingDirectory();
            string path = ToolLocationHelper.GetPathToDotNetFrameworkFile(ToolName, TargetDotNetFrameworkVersion.VersionLatest);
            if (path == null)
            {
                base.Log.LogErrorWithCodeFromResources("General.FrameworksFileNotFound", ToolName, ToolLocationHelper.GetDotNetFrameworkVersionFolderPrefix(TargetDotNetFrameworkVersion.VersionLatest));
            }
            return path;
        }

        private string debugType;
        private string emitDebugInformation;
        private int fileAlignment;
        private string keyContainer, keyFile;
        private bool optimize;
        private ITaskItem outputAssembly;
        private ITaskItem[] resources;
        private ITaskItem[] sources;
        private string targetType;

        private void AppendIntegerSwitch(CommandLineBuilder commandLine, string @switch, int value)
        {
            commandLine.AppendSwitchUnquotedIfNotNull(@switch, value.ToString(NumberFormatInfo.InvariantInfo));
        }
    }
}