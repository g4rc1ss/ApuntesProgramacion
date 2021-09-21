# coding: utf-8
# pip install mysql

import MySQLdb as mysql

# Conectamos con la base de datos MySQL
cnx = mysql.Connect(user='root', password='123456',
                    host='127.0.0.1', database='prueba')

cursor = cnx.cursor()  # creamos el objeto para trabajar con la bd

cursor.execute("select * from prueba.pruebaTable")  # hacemos una consulta

for (id, nombre) in cursor:  # Leemos el resultado de la consulta
    print("id ", id)
    print("nombre ", nombre)

# Cerramos la conexion
print("Conexion cerrada")
cnx.close()
