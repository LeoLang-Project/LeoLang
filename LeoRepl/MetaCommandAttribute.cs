using System;
using System.Reflection;

namespace LeoRepl
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class MetaCommandAttribute : Attribute
    {
        public MetaCommandAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }
    public sealed class MetaCommand
    {
        public MetaCommand(string name, string description, MethodInfo method)
        {
            Name = name;
            Description = description;
            Method = method;
        }

        public string Name { get; }
        public string Description { get; }
        public MethodInfo Method { get; }
    }
}