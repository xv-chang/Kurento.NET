using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;

namespace KMSCreator
{
    public class TypeManager
    {
        public static TypeManager Instance = new TypeManager();
        public static Dictionary<string, string> TypeMappings = new Dictionary<string, string>()
        {
            { "String","string"},
            { "boolean","bool"},
            { "int64","Int64"}
        };
        private ConcurrentDictionary<string, string> types;
        private TypeManager()
        {
            types = new ConcurrentDictionary<string, string>();
        }

        public void Add(string name, string type)
        {
            types.TryAdd(name, type);

        }
        public string GetType(string name)
        {
            if (!types.TryGetValue(name, out string t))
                t = string.Empty;
            return t;
        }
    }
}
