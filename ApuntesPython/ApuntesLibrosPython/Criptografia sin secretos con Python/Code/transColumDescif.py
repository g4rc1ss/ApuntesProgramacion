#!/bin/python
# -*- coding: utf-8 -*-

# Descifra la transposición columnar simple

import math

from Code import pyperclip


def main():
    criptograma = input('Introduce el criptograma: ')
    clave = int(input('y la clave numérica: '))
    criptograma = formatear_mensaje(criptograma)
    
    texto_plano = descifrar(criptograma, clave)

    # Imprime en pantalla el texto llano
    print(texto_plano.lower())
    # Y lo copia al portapepeles
    pyperclip.copy(criptograma)


# Elimina espacios en blanco en el mensaje
def formatear_mensaje(criptograma):
    mensaje_nuevo = ''
    for simbolo in criptograma:
        if simbolo != ' ':
            mensaje_nuevo += simbolo
    return mensaje_nuevo


def descifrar(criptograma, clave):
    # Número de columnas de la matriz
    num_col = math.ceil(len(criptograma)/clave)

    # Número de filas
    num_filas = clave

    # Número de celdas vacías
    celdas_vacias = (num_col * num_filas) - len(criptograma)

    # Cada cadena de texto es una columna
    texto_plano = [''] * num_col
    col = 0
    fila = 0

    for simbolo in criptograma:
        texto_plano[col] += simbolo
        col += 1 # siguiente columna

        # Si no hay más columnas o estamos en
        # una celda vacía, regresamos a la primera
        # columna de la siguiente fila
        if (col == num_col) or (col == num_col -1 and fila >= num_filas - celdas_vacias):
            col = 0
            fila += 1
    return ''.join(texto_plano)
    
    
# Si se ejecuta el programa (en vez de importarse)
# llama a la función main()
if __name__ == '__main__':
    main()
