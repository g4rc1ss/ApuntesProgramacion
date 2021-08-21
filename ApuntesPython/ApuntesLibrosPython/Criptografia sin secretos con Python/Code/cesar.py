#!/bin/python
# -*- coding: utf-8 -*-

# Cifra César
print("""Este programa cifra o descifra un
texto mediante la cifra César \n""")

# Símbolos que pueden cifrarse
ALFABETO = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'

# Almacena la cadena cifrada/descifrada
salida = ''

# Guarda la opción deseada
modo = input('¿Deseas cifrar o descifrar? (c/D) ')

# Se almacena el texto y la clave 
texto = input('Introduce el texto: ')
clave = int(input('Y la clave (1-25): '))

# Ejecuta el proceso letra a letra
for simbolo in texto.upper():
    if simbolo in ALFABETO:
        # Identifica la posición de cada símbolo
        pos = ALFABETO.find(simbolo)
        # y ejecuta la operación de cifrado/descifrado
        if modo == 'c':
            pos = (pos + clave) % 26
        elif modo == 'D':
            pos = (pos - clave) % 26

        # Añade el nuevo símbolo a la cadena
        salida += ALFABETO[pos]
        
    # Añade a la cadena el símbolo sin cifrar ni descifrar
    else:
        salida += simbolo

# Imprime en pantalla el resultado
print(salida)

