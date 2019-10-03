using System;
using System.Globalization;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ICSharpCode.Build.Tasks
{
    public sealed class Leo : ToolTask
    {
        public string DebugType
        {
            get
            {
                return debugType;
            }
            set
            {
                debugType = value;
            }
        }

        public string EmitDebugInformation
        {
            get
            {
                return emitDebugInformation;
            }
            set
            {
                emitDebugInformation = value;
            }
        }

        public int FileAlignment
        {
            get
            {
                return fileAlignment;
            }
            set
            {
                fileAlignment = value;
            }
        }

        public string KeyContainer
        {
            get
            {
                return keyContainer;
            }
            set
            {
                keyContainer = value;
            }
        }

        public string KeyFile
        {
            get
            {
                return keyFile;
            }
            set
            {
                keyFile = value;
            }
        }

        public bool Optimize
        {
            get
            {
                return optimize;
            }
            set
            {
                optimize = value;
            }
        }

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

        public ITaskItem[] Resources
        {
            get
            {
                return resources;
            }
            set
            {
                resources = value;
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
            CommandLineBuilder commandLine = new CommandLineBuilder();
            if (((OutputAssembly == null) && (Sources != null)) && ((Sources.Length > 0)))
            {
                OutputAssembly = new TaskItem(Path.GetFileNameWithoutExtension(this.Sources[0].ItemSpec));
                if (string.Equals(this.TargetType, "library", StringComparison.OrdinalIgnoreCase))
                {
                    OutputAssembly.ItemSpec += ".dll";
                }
                else if (string.Equals(this.TargetType, "module", StringComparison.OrdinalIgnoreCase))
                {
                    OutputAssembly.ItemSpec += ".netmodule";
                }
                else
                {
                    OutputAssembly.ItemSpec += ".exe";
                }
            }
            commandLine.AppendSwitch("/NOLOGO");

            // TODO: EmitDebugInformation / DebugType
            commandLine.AppendSwitch("/DEBUG");

            if (optimize)
            {
                commandLine.AppendSwitch("/OPTIMIZE");
            }

            commandLine.AppendSwitchIfNotNull("/KEY=@", this.KeyContainer);
            commandLine.AppendSwitchIfNotNull("/KEY=", this.KeyFile);

            if (Resources != null)
            {
                foreach (ITaskItem item in Resources)
                {
                    commandLine.AppendSwitchIfNotNull("/RESOURCE=", item);
                }
            }

            if (FileAlignment > 0)
            {
                AppendIntegerSwitch(commandLine, "/ALIGNMENT=", FileAlignment);
            }

            commandLine.AppendSwitchIfNotNull("/OUTPUT=", this.OutputAssembly);

            if (string.Equals(this.TargetType, "library", StringComparison.OrdinalIgnoreCase))
            {
                commandLine.AppendSwitch("/DLL");
            }
            else if (string.Equals(this.TargetType, "module", StringComparison.OrdinalIgnoreCase))
            {
                commandLine.AppendSwitch("/DLL");
            }

            commandLine.AppendFileNamesIfNotNull(this.Sources, " ");
            return commandLine.ToString();
        }

        protected override string GenerateFullPathToTool()
        {
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