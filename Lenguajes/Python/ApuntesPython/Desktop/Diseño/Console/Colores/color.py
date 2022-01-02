from colorama import init, Fore, Back, Style, Cursor
import os, sys
from time import sleep

#Inicializamos colorama (Importante usarlo)
init()

#Los metodos RESET y RESET ALL son para restablecer los estilos 
# y colores
print(f"{Fore.RED}Texto color rojo")
print(f"{Back.WHITE}Texto color rojo sobre fondo blanco")
print(f"{Back.WHITE+Style.BRIGHT}txt rojo brill.s/blanco{Back.RESET}")
print(f"{Style.RESET_ALL}Texto con valores por defecto")
print(f"{Fore.WHITE+Back.BLUE}Texto blanco sobre azul{Back.RESET}")
print("Texto blanco sobre fondo negro")

#niveles de intensidad
print(f"{Style.DIM+Fore.WHITE}Intesidad baja")
print(f"{Style.NORMAL}Intensidad normal")
print(f"{Style.BRIGHT}Intensidad alta")

Style.RESET_ALL
Fore.RESET
Back.RESET
sleep(5)
os.system("cls" if "win" in sys.platform else "clear")
#-----------------------------------
#Desplazar el cursor antes de dar formato
'''
    Colorama incluye la clase Cursor que permite, antes de dar formato,
    mover el cursor a una posicioón absoluta de la pantalla o una posicion
    relativa
'''

#init() pero esta mas arriba
print("Copiando archivos...")
for arch in ["111", "222", "333", "444", "555"]:
    sleep(1)
    print(Cursor.UP(1)+Cursor.FORWARD(20)+Fore.YELLOW+str(arch))

print(f"{Cursor.POS(25, 2)+Fore.GREEN}>>> Proceso Finalizado")
