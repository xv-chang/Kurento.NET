using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Linq;

namespace KMSCreator
{
    public static class StringExtensions
    {
        public static string RenderData<T>(this string str, T obj)
        {
            var type = typeof(T);
            var props = type.GetProperties();
            foreach (var p in props)
            {
                var name = "${" + p.Name + "}";
                var value = (string)p.GetValue(obj);
                str = str.Replace(name, value);
            }
            return str;
        }
        public static void SaveAsFile(this string str, string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            using (var sw = File.CreateText(path))
            {
                sw.WriteLine(str);
            }
        }
        public static string ToFirstUpper(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1);
        }
        public static string ToCSharpType(this string type)
        {
            var csharpType = string.Empty;
            if (type.IndexOf("<>") > -1)
            {
                var rType = type.Replace("<>", "");
                if (!TypeManager.TypeMappings.TryGetValue(rType, out csharpType))
                    csharpType = rType;
                csharpType = $"Dictionary<string,{csharpType}>";
            }
            else
            {
                if (!TypeManager.TypeMappings.TryGetValue(type, out csharpType))
                    csharpType = type;
            }
            return csharpType;
        }
        public static string ToNoKey(this string name)
        {
            var keys = new string[] { "object", "params" };
            return keys.Contains(name) ? $"@{name}" : name;
        }

    }
}
