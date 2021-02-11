# SOCKETS CON SSL

Existe una gran cantidad de módulos que ofrecen una alta abstracción a las implementaciones más bajas, permitiendo reducir la complejidad de las operaciones con un simple import y poco más. En este caso, para el tratamiento de sockets podemos contar con el módulo socket, el cual nos ofrece una abstracción de la interfaz de BSD Berkeley Sockets, y también con el módulo ssl, el cual nos facilita el cifrado SSL/TLS para los sockets mediante el uso de la librería OpenSSL.

Primeramente, lo que vamos a hacer es generar de forma simple el certificado que utilizará nuestro servidor:

```
1. Generamos la clave privada:

openssl genrsa -des3 -out server.key 1024

2. Generamos una solicitud de firma de certificado (CSR), donde especificaremos todos los atributos de identificación:

openssl req -new -key server.key -out server.csr

3. Eliminamos la passphrase de la clave para simplificar nuestro programa:

cp server.key server.key.org

openssl rsa -in server.key.org -out server.key

rm server.key.org

4. Generamos el certificado autofirmado:

openssl x509 -req -days 365 -in server.csr -signkey server.key -out server.crt
```


