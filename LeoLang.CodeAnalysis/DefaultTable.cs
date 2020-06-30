using LeoLang.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLang.CodeAnalysis
{
    internal static class DefaultTable
    {
        static DefaultTable()
        {
            AddValue("i32", 0);
            AddValue("empty", Maybe.None<object>());
            AddValue("date", DateTime.MinValue);
        }

        public static void AddValue(string type, object value)
        {
            _values.Add(type, value);
        }

        public static object GetValue(string type)
        {
            return _values[type];
        }

        private static Dictionary<string, object> _values = new Dictionary<string, object>();
    }
}