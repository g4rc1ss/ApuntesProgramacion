import glob
import os

'''
    El modulo glob se utiliza para buscar en una ruta todos los nombres o directorios
    que coincidan con un determinado patrón que puede tener comodines como ( *  ?  [] )
    ej:
        glob.glob(pathname, recursive=False)

    Comodines:
    ?       Un caracter
    *       Uno o mas caracteres
    []      Caracteres permitidos(filtra sobre estos caracteres)
    [x-y]   Rango de caracteres permitidos
    Con recursive=True se puede usar
    ** que indica busqueda de archivos en subcarpetas

    la funcion glob.iglob() es como la funcion glob() normal, pero
    en vez de devolver los elementos de la lista que coinciden, retorna
    un iterador evitando que se tengan que almacenar las entradas en memoria

    La funcion glob.scape() se usa para cuando los nombres de archivos o directorios pueden
    contener caracteres especiales como los utilizados en patrones. La funcion adapta pathname
    para que los caracteres especiales tengan el mismo tratamiento que el resto

    ej:
        escape("/Viajar?.txt) devuelve "Viajar[?].txt"

    
'''

ruta = os.path.abspath(os.path.dirname(__file__))+"\\prueba"

raices = [ruta+'\\1\\1?',
        ruta+'\\2\\1?\\*',
        ruta+'\\3\\1[45]',
        ruta+'\\4\\1[!45]',
        ruta+'\\3\\1[0-9a-z]'
]

for raiz in raices:
    print("\n"+raiz)
    rutas = glob.glob(raiz)
    print(f"rutas {len(rutas)}")
    for path in rutas:
        print(path)
    
#Glob con recursividad

rutas = glob.glob(ruta, recursive=True)
print(f"\nrutas: {len(rutas)}")
for ruta in rutas:
    print(ruta)