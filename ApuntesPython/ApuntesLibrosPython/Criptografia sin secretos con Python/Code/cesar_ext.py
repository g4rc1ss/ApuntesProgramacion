#!/bin/python
# -*- coding: utf-8 -*-

# Cifra César extendida
print("""Este programa cifra o descifra un
texto mediante la cifra César \n""")

from Code import pyperclip

# Símbolos que pueden cifrarse
ALFABETO = '!"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~'

# Almacena la cadena cifrada/descifrada
salida = ''

# Guarda la opción deseada
modo = input('¿Deseas cifrar o descifrar? (c/D) ')

# Se almacena el texto y la clave 
texto = input('Introduce el texto: ')
clave = int(input('Y la clave (1-25): '))

# Ejecuta el proceso letra a letra
for simbolo in texto:
    if simbolo in ALFABETO:
        # Identifica la posición de cada símbolo
        pos = ALFABETO.find(simbolo)
        # y ejecuta la operación de cifrado/descifrado
        if modo == 'c':
            pos = (pos + clave) % len(ALFABETO)
        elif modo == 'D':
            pos = (pos - clave) % len(ALFABETO)

        # Añade el nuevo símbolo a la cadena
        salida += ALFABETO[pos]
        
    # Añade a la cadena el símbolo sin cifrar ni descifrar
    else:
        salida += simbolo

# Imprime en pantalla el resultado
print(salida)

# Copia el mensaje al portapapeles
pyperclip.copy(salida)

