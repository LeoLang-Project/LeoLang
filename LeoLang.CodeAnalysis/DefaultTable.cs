using LeoLang.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LeoLang.CodeAnalysis
{
    internal static class DefaultTable
    {

        public static object GetValueOf(Type t)
        {
            var props = t.GetProperties();
            foreach (var p in props)
            {
                var attr = p.GetCustomAttribute<DefaultAttribute>(true);
                if(attr != null)
                {
                    return p.GetValue(null);
                }
            }

            return Maybe.None<object>();
        }

        static DefaultTable()
        {
            AddValue("byte", 0);
            AddValue("int", 0);
            AddValue("decimal", 0.0);
            AddValue("date", DateTime.MinValue);
            AddValue("guid", Guid.Empty);
            AddValue("bool", false);
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

        private static readonly Dictionary<string, object> _values = new Dictionary<string, object>();
    }
}