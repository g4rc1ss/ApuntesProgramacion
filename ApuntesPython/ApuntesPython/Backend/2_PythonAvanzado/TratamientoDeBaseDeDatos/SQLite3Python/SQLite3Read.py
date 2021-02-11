#-*- coding: utf-8 -*-

import sqlite3
import os

connection = sqlite3.connect(os.path.dirname(os.path.abspath(__file__))+"/database.db")#conectamos con la base de datos

cursor = connection.cursor() #creamos el cursor para las consultas

print("La base de datos se ha abierto")

#Ejecutamos la consulta
cursor.execute("SELECT id, nombre, direccion, salario from EMPRESA")

for i in cursor:
    print("ID = ", i[0])
    print("NOMBRE = ", i[1])
    print("DIRECCION = ", i[2])
    print("SALARIO = ", i[3], "\n")

print("Operacion satisfactoria...")

connection.close()