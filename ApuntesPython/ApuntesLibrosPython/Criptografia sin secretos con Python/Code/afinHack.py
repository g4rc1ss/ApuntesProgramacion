# -*- coding: utf-8 -*-

# Fuerza bruta contra la cifra Afín.

from Code import cifraAfin
from Code import detectarEspanol
from Code import pyperclip

from Code import criptomat

MODO_SILENCIO = False

def main():
    print('Este programa realiza un ataque por fuerza bruta contra la cifra Afín')
    criptograma = input('\nIntroduce el criptograma: ')
    texto = criptoanalisis(criptograma)

    if texto != None:
        print('\nCopiando mensaje al portapapeles:')
        print(texto)
        pyperclip.copy(texto)
    else:
        print('No fue posible hallar la clave.')


def criptoanalisis(mensaje):
    print('Buscando...')
    print('(Pulsa Ctrl-C or Ctrl-D para salir.)')

    # Comenzamos a recorrer todas las claves
    for clave_A in range(2,97):
        if criptomat.mcd(clave_A, len(cifraAfin.SIMBOLOS)) != 1:
            continue
        for clave_B in range(0,97):
            texto = cifraAfin.descifrar_mensaje(mensaje, clave_A, clave_B)
            if not MODO_SILENCIO:
                print('Probando clave (%s, %s)... (%s)' % (clave_A, clave_B, texto[:40]))

            if detectarEspanol.es_espanol(texto, 0.25)[0]:
                # Le permite al usuario comprobar la solución
                print('\nPosible hallazgo:')
                print('\tClave: (%s, %s)' % (clave_A, clave_B))
                print('\tTexto plano: ' + texto[:100])
                print('\nPulsa F para finalizar o Enter para continuar:')
                response = input('> ')
                if response.strip().upper().startswith('F'):
                    return texto
    return None


if __name__ == '__main__':
    main()
