#!/bin/python
# -*- coding: utf-8 -*-

# Cifrador transposición columnar simple

from Code import pyperclip


def main():
    mensaje = input('Introduce el mensaje: ')
    clave = int(input('y la clave numérica: '))
    mensaje = formatear_mensaje(mensaje)
    
    criptograma = salida(cifrar(mensaje, clave))


    # Imprime en pantalla el criptograma
    print(criptograma.upper())
    # Y lo copia al portapepeles
    pyperclip.copy(criptograma)


# Elimina espacios en blanco en el mensaje
def formatear_mensaje(mensaje):
    mensaje_nuevo = ''
    for simbolo in mensaje:
        if simbolo != ' ':
            mensaje_nuevo += simbolo
    return mensaje_nuevo


# Agrupa las letras en grupos de 5
def salida(criptograma):
    BLOQUE = 5
    texto = ''
    for i in range(len(criptograma)):
        if (i+1) % BLOQUE != 0:
            texto += criptograma[i]
        else:
            texto += criptograma[i]+' '
    return texto
        

def cifrar(mensaje, clave):
    # Cada cadena del criptograma es una columna
    # de la tabla
    criptograma = [''] * clave

    # Recorremos cada columna de la tabla
    for col in range(clave):
        pos = col

        # En cada columna añadimos las letras hasta 
        # que pos sobrepase la longitud del mensaje
        while pos < len(mensaje):
            criptograma[col] += mensaje[pos]

            # desplazamos la posicion 
            pos += clave

    # Convertimos la lista en una única cadena        
    return ''.join(criptograma)

# Si se ejecuta el programa (en vez de importarse)
# llama a la función main()
if __name__ == '__main__':
    main()
