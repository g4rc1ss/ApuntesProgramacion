#!/bin/python
# -*- coding: utf-8 -*-

# Cifra de autoclave de Vigenère
# David Arboledas Brihuega
# Dominio público

from Code import pyperclip

LETRAS = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'

def main():
    mensaje = """En un hermoso camino bordeando el alto tajo, una enjuta figura, delgada como un junco, arrastraba sus pies."""
    clave = 'En un lugar de la Mancha'
    
    modo = 'cifrado' # poner 'cifrado' o 'descifrado'

    if modo == 'cifrado':
        salida = cifrarMensaje(clave, mensaje)
    elif modo == 'descifrado':
        salida = descifrarMensaje(clave, mensaje)

    print('Mensaje %s: ' % (modo.title()))
    print(salida)
    pyperclip.copy(salida)
    print()
    print('El mensaje se ha copiado al portapapeles.')


def limpiar (texto): # Deja solo letras y espacios
    cadena = ''
    for simbolo in texto.upper():
        if simbolo in LETRAS or simbolo == ' ':
            cadena += simbolo
    return cadena

    
def cifrarMensaje(clave, mensaje):
    return cifrar_descifrar(clave, mensaje, 'cifrado')


def descifrarMensaje(clave, mensaje):
    return cifrar_descifrar(clave, mensaje, 'descifrado').lower()


def cifrar_descifrar(clave, mensaje, modo):
    salida = []  # Almacena la cadena cifrada/descifrada

    if modo == 'cifrado':
        clave += mensaje
        # Se quitan todos los símbolos no alfabéticos
        clave=''.join(limpiar(clave).split())
        mensaje = limpiar(mensaje)
    elif modo == 'descifrado':
        clave=''.join(limpiar(clave).split())
        
    indice_clave = 0
    clave = clave.upper()

    for simbolo in mensaje:  # Recorre todos los símbolos 
        pos = LETRAS.find(simbolo.upper())
        if pos != -1:  # Si existe
            if modo == 'cifrado':
                pos += LETRAS.find(clave[indice_clave])      
            elif modo == 'descifrado':
                pos -= LETRAS.find(clave[indice_clave]) 
                if len(clave)<len(''.join(mensaje.split())):
                    clave += LETRAS[pos]
            pos %= len(LETRAS)  # Indica la posición del carácter
            
            salida.append(LETRAS[pos])
            indice_clave += 1 # Se desplaza a la siguiente letra de la clave
            
        else:  # Si simbolo NO está
            salida.append(simbolo)    

    return ''.join(salida)


if __name__ == '__main__':
    main()
