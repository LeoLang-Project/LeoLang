using LeoLang.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLang.CodeAnalysis
{
    internal static class DefaultTable
    {
        //ToDo: add method to get default value from .net type

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
            if (_values.ContainsKey(type))
            {
                return _values[type];
            }

            return null;
        }

        private static Dictionary<string, object> _values = new Dictionary<string, object>();
    }
}