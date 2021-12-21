using System;
using System.Linq;
using System.Xml.Linq;

namespace XmlFiles.Read
{
    internal class ReadXmlWithLinq
    {
        public ReadXmlWithLinq(string nombreArchivo)
        {
            var document = XElement.Load(nombreArchivo);

            // document.Descendants("empleado") - Se buscan todos los elementos con el nombre que se le pasa, en este caso "empleado"
            // item.Attribute("id").Value == "1" - Obtener el atributo "id" de los elementos obtenidos antes y se compara con el valor que se quiere
            // item.Element("nombre").Value == "Empleado 1" - Obtener el elemento "nombre" de los empleados y se compara con el nombre que queremos
            var buscarEmpleado = (from item in document.Descendants("empleado")
                                  where item.Attribute("id").Value == "1" && item.Element("nombre").Value == "Empleado 1"
                                  select item).ToList();

            foreach (var item in buscarEmpleado)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
