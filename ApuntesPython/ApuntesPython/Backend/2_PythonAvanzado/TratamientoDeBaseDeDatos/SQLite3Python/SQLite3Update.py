#coding: utf-8

import sqlite3
import os

connection = sqlite3.connect(os.path.dirname(os.path.abspath(__file__))+"/database.db")

cursor = connection.cursor()

cursor.execute("UPDATE EMPRESA set SALARIO = 4500.00 where ID=1")

connection.commit()#guardar cambios de BBDD
print("Actualizaciones totales: ", connection.total_changes)

cursor.execute("SELECT id, nombre, direccion, salario from EMPRESA")

for i in cursor:
    print("ID: ", i[0])
    print("NOMBRE: ", i[1])
    print("DIRECCION: ", i[2])
    print("SALARIO: ", i[3])

connection.close()
