#!/bin/python
# -*- coding: utf-8 -*-

# Ataque de diccionario frente a la cifra Vigenère.
# Solo funciona si la clave está en diccionario.txt
# y se ha usado la tabla tradicional de Vigenère.
# Dominio Público.

from Code import Vigenere
import pyperclip

from Code import detectarEspanol


def main():
    print('Este programa efectúa un ataque de diccionario a la cifra Vigenère')
    criptograma = input('\nCriptograma > ')
    texto = romper_vigenere(criptograma)

    if texto != None:
        print('Copiando texto al portapapeles: ')
        print(texto)
        pyperclip.copy(texto)
    else:
        print('Ataque fallido.')

      
def romper_vigenere(criptograma):
    fo = open('diccionario.txt')
    palabras = fo.readlines()
    fo.close()
    Vigenere.generar_tabla(Vigenere.ALFABETO)
    intento = 1
    for palabra in palabras:
        # elimina el caracter nueva línea al final
        palabra = palabra.strip() 
        if intento % 100 == 0: print(palabra)
        texto_llano = Vigenere.descifrarMensaje(palabra, criptograma)
        if detectarEspanol.es_espanol(texto_llano)[0]:
            # Comprueba con el usuario si se ha encontrado la clave.
            print()
            print('Posible hallazgo:')
            print('Clave ' + str(palabra) + ': ' + texto_llano[:100])
            print()
            print('Escribe F para FINALIZAR o pulsa Enter para CONTINUAR:')
            respuesta = input('> ')

            if respuesta.upper().startswith('F'):
                return texto_llano
        intento += 1

if __name__ == '__main__':  
    main()
