
``socket.AF_INET, socket.SOCK_STREAM`` son los parámetros que nos crearán un objeto socket TCP/IP.

Los tipos de sockets en Python son los siguientes:

- SOCK_STREAM: Este protocolo nos da una comunicación fiable de dos direcciones en un flujo de datos(TCP)

- SOCK_DGRAM: Este protocolo nos da una conexión no fiable. (UDP)

- SOCK_RAW: este protocolo es para acceder a los campos e interfaces internos de la red.

- SOCK_RDM: Este protocolo garantiza la llegada de paquetes pero no garantiza el orden de llegada

- SOCK_SEQPACKET: datagramas fiables y secundarios, de longitud fija, basado en la conexión.

- SOCK_PACKET: Coloca el socket en modo promiscuo en la que recibe todos los paquetes de la red.

