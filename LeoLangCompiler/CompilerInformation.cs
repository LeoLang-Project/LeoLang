using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLangCompiler
{
    public enum InformationKind { Error, Warning }

    public class CompilerInformation
    {
        public int Column { get; set; }
        public InformationKind Kind { get; set; }
        public int Line { get; set; }
        public string Message { get; set; }
    }
}