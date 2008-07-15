using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ContextInterfaceGenerator
{
    public class ContextDefinition
    {
        public ContextDefinition(XmlNode node)
        {
            SetEntityNamespace(node);
            SetClassName(node);
        }

        private void SetClassName(XmlNode node)
        {
            XmlAttribute className = node.Attributes["Class"];
            if (className != null)
                ClassName = className.InnerText;
        }

        private void SetEntityNamespace(XmlNode node)
        {
            XmlAttribute nameSpace = node.Attributes["EntityNamespace"];
            if (nameSpace != null)
                EntityNamespace = nameSpace.InnerText;
        }

        public string ClassName { get; set; }
        public string EntityNamespace { get; set; }
    }
}
