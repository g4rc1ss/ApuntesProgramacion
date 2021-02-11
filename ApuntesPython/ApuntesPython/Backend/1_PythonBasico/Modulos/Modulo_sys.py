#-*- coding: utf-8 -*-

#Codigo en Python para verificar el sistema operativo y poder usar unas librerias/programas etc u otros


import sys
import os

print(sys.platform) #sys.platform se usa para verificar el sistema operativo sobre el que corre python

if "linux" in sys.platform:
    print("Estas usando un sistema Linux")

elif "win" in sys.platform:
    print("Estas Usando Un sistema Windows")
    os.system("pause")

else:
    print("O esto no fona, o no estas usando uno de los sistemas operativos tipicos")


#sys.version se usa para verficar el sistema la version de python(3 o 2)

if "3" in sys.version:
    print("python 3")

elif "2" in sys.version:
    print("python 2")