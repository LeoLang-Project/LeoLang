using System;

namespace LeoLang.Library.Shared
{
    internal class RecieveRequest
    {
        public Action<object> Callback { get; internal set; }
        public bool IsEndless { get; internal set; }
        public string Name { get; internal set; }
        public Type Type { get; internal set; }
    }
}