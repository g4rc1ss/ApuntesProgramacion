#-*- coding: utf-8 -*-

'''

    Esta libreria es para generar listas uni y bidimensionales, se ha de crear un objeto para
    contener la informacion del numero de filas y columnas y asi poder gestionar mejor las medidas
    añadidas al array.

    Tambien permite una visualizacion del array y su contenido...
    Ejemplo:
        [
            from arraygenerator import Array
            crear = Array()
            dimension = crear.genarray(filas=10, columnas=10, relleno='*')
            crear.visarray(dimension, crear.lenfilas(), crear.lencolumnas())
        ]
'''

class Array:
    matrizPrueba  = []
    nfilas=None
    ncolumnas=None

    def genarray(self, filas=1, columnas=1, relleno=None):
        for x in range(filas):
            self.matrizPrueba.append([])
            for y in range(columnas):
                self.matrizPrueba[x].append(relleno)
        self.nfilas = filas
        self.ncolumnas = columnas
        return self.matrizPrueba

    def visarray(self,matriz, filas, columnas):
        for x in range(filas):
            print("")
            for y in range(columnas):
                print(str(matriz[x][y]) + "\t", end='')

    def lenfilas(self):
        return self.nfilas

    def lencolumnas(self):
        return self.ncolumnas
