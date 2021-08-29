using System;
using System.Xml.XPath;

namespace XmlFiles.Read {
    internal class ReadXmlWithXpath {
        public ReadXmlWithXpath(string nombreArchivo) {
            var document = new XPathDocument(nombreArchivo);
            var navigator = document.CreateNavigator();

            var nodes = navigator.Select("/empresa");
            nodes.MoveNext();
            var nodesNavigator = nodes.Current;

            var nodesText = nodesNavigator.SelectDescendants(XPathNodeType.Element, false);

            while (nodesText.MoveNext()) {
                Console.WriteLine($"{nodesText.Current.Name} : {nodesText.Current.Value}");
            }
        }
    }
}
