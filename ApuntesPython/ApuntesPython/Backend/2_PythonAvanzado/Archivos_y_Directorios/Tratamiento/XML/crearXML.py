#http://www.decodigo.com/python-crear-archivo-xml
import xml.etree.cElementTree as xml
import os

try:    
    root = xml.Element("root")
    doc = xml.SubElement(root, "doc")

    nodo1 = xml.SubElement(doc, "nodo1", name="nodo")
    nodo1.text = "Texto del nodo 1"

    xml.SubElement(doc, "nodo2", atributo="algo").text = "texto2"

    arbol = xml.ElementTree(root)
    arbol.write(os.path.dirname(os.path.abspath(__file__))+"/prueba.xml")

    print("Archivo guardado correctamente")
except:
    print("error a la hora de crear archivo")