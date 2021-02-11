#-*- coding: utf-8 -*-
import os
ruta = os.path.dirname(os.path.abspath(__file__))
with open(ruta+'/archivo.txt', 'w') as f:
    f.write('Hola, que tal?')
with open(ruta+'/archivo.txt', 'r') as f:
    for line in f:
        print("linea: %s" %(line))

#with open(ruta+'/archivo.txt', 'wb') as f:
#    pass

with open(ruta+'/archivo.txt', 'r') as f:
    archivo = f.read(1000)
    print("contenido: %s" %(archivo))



'''
El propio with&ManejoArchivos se encarga de cerrar el archivo, pero si te quedas mas tranquilo cerrandolo
tu, mejor que mejor
'''

'''

El with&ManejoArchivos es una sentencia de codigo que se ejecuta siempre
sea cual sea la circunstancia... se suele utilizar para abrir archivos de texto y asi,
el mismo se encargara de cerrar esos archivos abiertos como en el caso de arriba

se puede usar:
    
    with&ManejoArchivos open('/etc/passwd', 'r'):
        bloque-codigo
        
    o
    
    with&ManejoArchivos open('etc'passwd', 'r') as archivo:
        bloque
        
        
el bloque with&ManejoArchivos se ejecutara aunque exista excepciones

hay que tener en cuenta el el bloque de codigo with&ManejoArchivos no es un bucle, simplemente es una sentencia que se ejecuta
una vez que sirve para que se ejecute siempre, por tanto dentro se ha de meter algo importante de codigo...
tambien detallar que el codigo siempre se va a ejecutar a no ser qie haya errores... asique en vez de with&ManejoArchivos,
puede ser manejado mediante excepciones... eso como se quiera mejor...

cosas como cerrar conexiones... archivos de texto.... etc etc se ejecutaran mejor en with&ManejoArchivos.

'''