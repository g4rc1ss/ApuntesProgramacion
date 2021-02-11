# -*- utf: 8 -*-

class prueba(object):
    nombre = None

    def __new__(cls, nombre):
        cls.nombre = nombre
        print("__new__")

    def __init__(self):
        print("__init__")

    def __str__(self):
        print("__str__")

    def __len__(self):
        return 5


prueba = prueba("Asier")

print( str(prueba) )
#len(prueba)