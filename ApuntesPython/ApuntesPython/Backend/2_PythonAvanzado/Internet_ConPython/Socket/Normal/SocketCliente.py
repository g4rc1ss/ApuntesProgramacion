# -*- coding: utf-8 -*-

import socket

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

sock.connect((str("127.0.01"), int(9999)))

sock.send(str("Hola servidor").encode('utf-8'))

recibido = sock.recv(1024)
print("Recibido: ", recibido)