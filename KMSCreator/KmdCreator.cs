using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KMSCreator
{
    public class KmdCreator
    {
        private Dictionary<string, string> templates;
        private readonly string kmdFile;
        private readonly string templateDir;
        private readonly string outputDir;
        const string rootObject = "MediaObject";
        public KmdCreator(string kmdFile, string templateDir, string outputDir)
        {
            this.kmdFile = kmdFile;
            this.templateDir = templateDir;
            this.outputDir = outputDir;
            LoadTemplates(templateDir);
        }
        public void Execute()
        {
            var dataJson = File.ReadAllText(kmdFile);
            var kmd = JsonConvert.DeserializeObject<KmdObject>(dataJson);
            if (kmd.complexTypes != null)
                RenderComplexTypes(kmd.complexTypes);
            if (kmd.events != null)
                RenderEventTypes(kmd.events);
            if (kmd.remoteClasses != null)
                RenderRemoteClasses(kmd.remoteClasses);
        }

        private void LoadTemplates(string path)
        {
            templates = new Dictionary<string, string>();
            var fileNames = Directory.GetFiles(path, "*.txt");
            foreach (var fileName in fileNames)
                templates.Add(Path.GetFileNameWithoutExtension(fileName), File.ReadAllText(fileName));
        }
        private void RenderRemoteClasses(Remoteclass[] remoteclasses)
        {
            foreach (var remoteclass in remoteclasses)
            {
                var template = templates["Remoteclass"];
                if (remoteclass.name == rootObject)
                    remoteclass.extends = "KMSObject";
                if (!string.IsNullOrEmpty(remoteclass.extends))
                    remoteclass.extends = $":{remoteclass.extends}";
                string _constructor = string.Empty,
                    _properties = string.Empty,
                    _methods = string.Empty,
                    _events = string.Empty;
                if (remoteclass.constructor != null)
                    _constructor = RenderConstructor(remoteclass.name, remoteclass.constructor);
                if (remoteclass.properties != null)
                    _properties = RenderProperties(remoteclass.properties);
                if (remoteclass.methods != null)
                    _methods = RenderMethods(remoteclass.methods);
                if (remoteclass.events != null)
                    _events = RenderEvents(remoteclass.events);
                template = template.RenderData(new
                {
                    remoteclass.name,
                    remoteclass.extends,
                    _constructor,
                    _properties,
                    _methods,
                    _events
                });
                template.SaveAsFile($"{outputDir}/RemoteClasses/{remoteclass.name}.cs");
            }
        }
        private string RenderConstructor(string name, Constructor constructor)
        {
            var template = templates["Remoteclass_Constructor"];
            var args = string.Join(",", constructor.@params.Select(x => x.GetFormateParam()));
            var argNames = string.Join(",", constructor.@params.Select(x => x.name.ToNoKey()));
            if (string.IsNullOrEmpty(argNames))
            {
                argNames = "null";
            }
            else
            {
                argNames = $"new {{{argNames}}}";
            }
            return template.RenderData(new
            {
                name,
                args,
                argNames
            });
        }
        private string RenderEvents(string[] events)
        {
            var sb = new StringBuilder();
            foreach (var eventName in events)
            {
                var template = templates["Remoteclass_Event"];
                template = template.RenderData(new
                {
                    name = eventName
                });
                sb.AppendLine(template);
            }
            return sb.ToString();
        }
        private string RenderMethods(MethodInfo[] methods)
        {
            var sb = new StringBuilder();
            foreach (var method in methods)
            {
                var templateName = method.@return == null ? "Remoteclass_NoReturnMethod" : "Remoteclass_Method";
                var template = templates[templateName];
                var args = string.Join(",", method.@params.Select(x => x.GetFormateParam()));
                var argNames = string.Join(",", method.@params.Select(x => x.name.ToNoKey()));
                var returnType = "void";
                if (method.@return != null)
                    returnType = method.@return.type.ToCSharpType();
                template = template.RenderData(new
                {
                    returnType,
                    upperName = method.name.ToFirstUpper(),
                    method.name,
                    args,
                    argNames = string.IsNullOrEmpty(argNames) ? "null" : $"new {{{argNames}}}"
                });
                sb.AppendLine(template);
            }
            return sb.ToString();
        }
        private string RenderProperties(PropertyInfo[] properties)
        {
            var sb = new StringBuilder();
            foreach (var p in properties)
            {
                var templateName = p.readOnly ? "Remoteclass_ReadOnlyProperty" : "Remoteclass_Property";
                var template = templates[templateName];

                template = template.RenderData(new
                {
                    type = p.type.ToCSharpType(),
                    upperName = p.name.ToFirstUpper(),
                    name = p.name.ToNoKey(),
                });
                sb.AppendLine(template);
            }
            return sb.ToString();
        }
        private void RenderEventTypes(Event[] events)
        {
            foreach (var e in events)
            {
                var template = templates["Event"];
                var itemTemplate = templates["Event_ITEM"];
                var items = new StringBuilder();
                foreach (var p in e.properties)
                {
                    items.AppendLine(itemTemplate.RenderData(new
                    {
                        type = p.type.ToCSharpType(),
                        name = p.name.ToNoKey()
                    }));
                }
                template = template.RenderData(new
                {
                    e.name,
                    extends = string.IsNullOrEmpty(e.extends) ? "" : $":{e.extends}EventArgs",
                    _items = items.ToString()
                });
                template.SaveAsFile($"{outputDir}/Events/{e.name}EventArgs.cs");
            }
        }

        private void RenderComplexTypes(Complextype[] complexTypes)
        {
            foreach (var c in complexTypes)
            {
                var template = templates[c.typeFormat];
                var itemTemplate = templates[$"{c.typeFormat}_ITEM"];
                var items = new StringBuilder();
                TypeManager.Instance.Add(c.name, c.typeFormat);
                switch (c.typeFormat)
                {
                    case "ENUM":
                        foreach (var item in c.values)
                            items.AppendLine(itemTemplate.RenderData(new
                            {
                                name = item.ToNoKey()
                            }));
                        break;
                    case "REGISTER":
                        foreach (var item in c.properties)
                            items.AppendLine(itemTemplate.RenderData(new
                            {
                                name = item.name.ToNoKey(),
                                type = item.type.ToCSharpType()
                            }));
                        break;
                    default:
                        break;
                }
                template = template.RenderData(new
                {
                    _items = items.ToString(),
                    c.name,
                    extends = string.IsNullOrEmpty(c.extends) ? "" : $":{c.extends}",
                });
                template.SaveAsFile($"{outputDir}/ComplexTypes/{c.name}.cs");
            }
        }
    }
}
