#!/bin/python
# -*- coding: utf-8 -*-

# Ataque de diccionario a la cifra de sustitución simple

from Code import detectarEspanol
import pyperclip

from Code import sustitucionSimple

MODO = False

def main():
    criptograma = input('Criptograma > ')
    textoLlano = ataque(criptograma)

    if textoLlano == None:
        # ataque() devuelve None si no ha encontrado la clave
        print('El ataque falló.')
    else:
        # El texto llano se muestra en la pantalla y se copia al portapapeles
        print('Mensaje copiado al portapapeles.')
        print(textoLlano)
        pyperclip.copy(textoLlano)


def alfabetoSustitucion(clave):
    # crea un alfabeto de sustitución con la clave
    nuevaClave = ''
    clave = clave.upper()
    alfabeto = list(sustitucionSimple.LETRAS)
    for i in range(len(clave)):
        if clave[i] not in nuevaClave:
            nuevaClave += clave[i]
            alfabeto.remove(clave[i])
    clave = nuevaClave + ''.join(alfabeto)
    return clave


def ataque(mensaje):
    print('Probando con %s posibles palabras del diccionario...' % len(detectarEspanol.PALABRAS_ESPANOL)) 

    print('(Pulsa Ctrl-C o Ctrl-D para abandonar.)')
    
    intento = 1
    # Prueba de cada una de las claves posibles
    for clave in detectarEspanol.PALABRAS_ESPANOL:
        if intento % 100 == 0 and not MODO:
            print('%s claves probadas. (%s)' % (intento, clave))
        clave = alfabetoSustitucion(clave)
        textoLlano = sustitucionSimple.descifrarMensaje(clave, mensaje)
        if detectarEspanol.porcentaje_palabras(textoLlano) > 0.20:
        
            # Comprueba con el usuario si el texto tiene sentido
            print()
            print('Posible hallazgo:')
            print('clave: ' + str(clave))
            print('Texto llano: ' + textoLlano[:100])
            print()
            print('Pulsa S si es correcto, o Enter para seguir probando:')
            respuesta = input('> ')
            if respuesta.upper().startswith('S'):
                return textoLlano
        intento += 1
    return None

if __name__ == '__main__':
    main()
