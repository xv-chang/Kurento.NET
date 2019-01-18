using System;
using System.Collections.Generic;
using System.Linq;

namespace KMSCreator
{
    public class ParamInfo
    {
        public string name { get; set; }
        public string doc { get; set; }
        public string type { get; set; }
        public bool optional { get; set; }
        public object defaultValue { get; set; }


        public string GetFormateParam()
        {

            var classType = TypeManager.Instance.GetType(type);
            var defaultStr = string.Empty;
            var typeStr = type.ToCSharpType();
            if (optional)
            {
                if (defaultValue != null)
                {
                    if (classType == "ENUM")
                    {
                        defaultStr = $"={type}.{defaultValue}";
                    }
                    else if (classType == "REGISTER")
                    {
                        defaultStr = $"=null";
                    }
                    else if (type == "String")
                    {
                        defaultStr = $"=\"{defaultValue}\"";
                    }
                    else
                    {
                        if (defaultValue.GetType() == typeof(bool))
                        {

                            defaultStr = $"={defaultValue.ToString().ToLower()}";
                        }
                        else
                        {
                            defaultStr = $"={defaultValue}";
                        }
                    }
                }
                else
                {
                    if (classType == "ENUM")
                    {
                        typeStr = $"{type}?";
                        defaultStr = $"=null";
                    }
                    else if (classType == "REGISTER")
                    {
                        typeStr = $"{type}?";
                        defaultStr = $"=null";
                    }
                    else if (type == "String")
                    {
                        defaultStr = $"=\"\"";
                    }

                }
            }
            return $"{typeStr} {name}{defaultStr}";
        }

    }



}
