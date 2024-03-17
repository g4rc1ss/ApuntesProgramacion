#!/bin/python
# -*- coding: utf-8 -*-

# Cifrador por transposición columnar con palabra clave.
# El programa cifra cualquier texto mediante una palabra
# clave. De la clave, que solo puede contener letras, elimina
# los caracteres repetidos. Conserva en el criptograma
# todos los caracteres imprimibles, incluidos números y
# caracteres especiales y de signos de puntuacion.


import math

from Code import pyperclip


def main():
    print('''Este programa cifra un texto mediante una transposición controlada por una palabra clave''')
    mensaje = input('\nIntroduce el mensaje: ').upper()
    clave = eliminar_duplicados(input('\ny la palabra clave: '))
    criptograma = cifrar(mensaje, clave)
    criptograma = ordenar(criptograma, clave)
    print('\nEl criptograma es: \n',criptograma)
    # Copia el criptograma al portapapeles
    pyperclip.copy(criptograma)


def eliminar_duplicados(clave):
    clave = clave.upper()
    clave2 = clave[0] 
    for simbolo in clave:
            if simbolo not in clave2:
                    clave2 += simbolo
    return clave2


def cifrar(mensaje, clave):
    limite = math.ceil(len(mensaje)/len(clave))
    # Cada cadena del criptograma es una columna
    # de la tabla
    
    criptograma = [''] * len(clave)
    
    # Recorremos cada columna de la tabla
    for col in range(len(clave)):
        pos = col

        # En cada columna añadimos las letras hasta 
        # que pos sobrepase la longitud del mensaje
        while pos < len(mensaje):
            criptograma[col] += mensaje[pos]

            # desplazamos la posicion 
            pos += len(clave)

        
        # Para evitar espacios vacíos rellenamos
        # la lista criptograma[col] con X 
        if len (criptograma[col]) != limite:
            criptograma[col] += 'X'
    return criptograma



def ordenar(criptograma,clave):
    salida = []
    clave_ordenada = sorted(clave)
    for i in range(len(clave)):
        letra = clave_ordenada[i]
        salida.append(criptograma[clave.index(letra)])
    return ''.join(salida)


if __name__ == '__main__':
    main()
