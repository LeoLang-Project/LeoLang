using System;
using System.Globalization;
using System.IO;
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
            CommandLineBuilder commandLine = new CommandLineBuilder();
            if (((OutputAssembly == null) && (Sources != null)) && ((Sources.Length > 0)))
            {
                OutputAssembly = new TaskItem(Path.GetFileNameWithoutExtension(this.Sources[0].ItemSpec));

                if (string.Equals(this.TargetType, "library", StringComparison.OrdinalIgnoreCase))
                {
                    OutputAssembly.ItemSpec += ".dll";
                }
                else
                {
                    OutputAssembly.ItemSpec += ".exe";
                }
            }

            commandLine.AppendSwitchIfNotNull("-o", this.OutputAssembly);

            if (string.Equals(this.TargetType, "library", StringComparison.OrdinalIgnoreCase))
            {
                commandLine.AppendSwitch("-library");
            }
            else if (string.Equals(this.TargetType, "application", StringComparison.OrdinalIgnoreCase))
            {
                commandLine.AppendSwitch("-console");
            }

            commandLine.AppendFileNamesIfNotNull(this.Sources, " -i ");

            File.WriteAllText(@"C:\Users\filmee24\Documents\cmd.txt", commandLine.ToString());
            return commandLine.ToString();
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