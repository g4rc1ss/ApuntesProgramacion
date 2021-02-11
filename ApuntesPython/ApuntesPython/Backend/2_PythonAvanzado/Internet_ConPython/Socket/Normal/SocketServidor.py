#-*- coding: utf-8 -*-

import socket

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

#Con el metodo bind le indicamos que puerto debe escuchar y de que servidor esperar conexiones
#Es mejor dejarlo en blanco para recibir conexiones externas si es nuestro caso
sock.bind(("127.0.0.1", 9999))

#Aceptamos conexiones entrantes con el metodo listen, y ademas aplicamos como parametro
#El numero de conexiones entrantes que vamos a aceptar
sock.listen(1)

#Instanciamos un objeto src (socket cliente) para recibir datos, al recibir datos este
#devolvera tambien un objeto que representa una tupla con los datos de conexion: IP y puerto
src, addr = sock.accept()

cont = 1
while cont == 1:#aqui seria while True, pero para ver bien el resultado salimos del bucle
    # Recibimos el mensaje, con el metodo recv recibimos datos y como parametro
    # la cantidad de bytes para recibir
    recibido = src.recv(1024)

    # Si se reciben datos nos muestra la IP y el mensaje recibido
    print(str(addr[0]) + " dice: ", recibido)
    # Devolvemos el mensaje al cliente
    src.send(recibido)
    cont = 0

sock.close()
src.close()
