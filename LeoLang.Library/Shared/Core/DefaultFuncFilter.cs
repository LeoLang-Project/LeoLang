using System.Reflection;
using Furesoft.Signals.Attributes;

namespace LeoLang.Library.Shared.Core
{
    internal class DefaultFuncFilter : IFuncFilter
    {
        public object AfterCall(MethodInfo mi, int id, object returnValue)
        {
            return returnValue;
        }

        public FuncFilterResult BeforeCall(MethodInfo mi, int id)
        {
            return true;
        }
    }
}