using System.Xml;

namespace XmlFiles.Write;

internal class WriteXmlFile
{
    public WriteXmlFile(string nombreArchivo)
    {
        var document = new XmlDocument();

        var xmlDeclaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
        var elementRoot = document.DocumentElement;
        document.InsertBefore(xmlDeclaration, elementRoot);

        var empresa = document.CreateElement(string.Empty, "empresa", string.Empty);
        document.AppendChild(empresa);

        for (var x = 1; x < 4; x++)
        {
            var empleado = document.CreateElement(string.Empty, "empleado", string.Empty);
            empleado.SetAttribute("id", $"{x}");
            empresa.AppendChild(empleado);

            var nombre = document.CreateElement(string.Empty, "nombre", string.Empty);
            var textName = document.CreateTextNode($"Empleado {x}");
            nombre.AppendChild(textName);
            empleado.AppendChild(nombre);

            var status = document.CreateElement(string.Empty, "status", string.Empty);
            var textStatus = document.CreateTextNode("activo");
            status.AppendChild(textStatus);
            empleado.AppendChild(status);
        }

        document.Save(nombreArchivo);
    }
}
