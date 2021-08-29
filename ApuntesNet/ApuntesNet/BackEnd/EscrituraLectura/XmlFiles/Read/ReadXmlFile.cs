using System;
using System.Xml;

namespace XmlFiles.Read {
    internal class ReadXmlFile {
        public ReadXmlFile(string nombreArchivo) {
            var document = new XmlDocument();
            document.Load(nombreArchivo);

            foreach (XmlNode node in document.DocumentElement.ChildNodes) {
                var id = node.Attributes["id"].Value;
                Console.WriteLine($"Id: {id}");

                foreach (XmlNode elements in node.ChildNodes) {
                    Console.WriteLine($"{elements.Name} : {elements.InnerText}");
                }
            }
        }
    }
}
