'''
    El modulo shutil sirve para realizar operaciones de alto nivel con archivo
    y directorios. Entre esas operaciones esta la copia, borrado o mover, como
    copias permisos y estado de los archivos y directorios


    Copiar un arbol de directorios y archivos

        La función shutil.copytree() copia un directorio origen y todo su contenido 
        a un directorio destino que no debe existir. Durante el proceso se copiarán 
        permisos y fechas-horas con shutil.copystat(). Además, para copiar los archivos
        (individuales) se utilizará la función shutil.copy2() que incluye permisos y metadatos.

    ej:
        shutil.copytree(src, dst, symlinks=False, ignore=None, copy_function=copy2, ignore_dangling_symlinks=False)
'''
import shutil, os

ruta = os.path.abspath(os.path.dirname(__file__))
origen = ruta + '\\copiar'
destino = ruta + '\\prueba'
ignorar_pat = shutil.ignore_patterns('*.dat', 'destino.txt', 'dir11')

if os.path.exists(origen):
    try:
        # Si ignore=None no se excluyen archivos/directorios
                
        arbol = shutil.copytree(origen, destino, ignore=ignorar_pat) 
        print('Árbol copiado a', arbol)
    except:
        print('Error en la copia')