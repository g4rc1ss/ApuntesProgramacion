# Cifrados

## Instalación
 ```
pip install cryptodome
 ```

 ## Cifrados

### Cifrado Simétrico

En este modo se usa una contraseña única para cifrar y descifrar el archivo o archivos para poder acceder a ellos.

Este es un método seguro e inseguro dependiendo por donde se mire.

Es seguro si solo quieres acceder tu a los archivos y nadie mas tiene que saber la contraseña, si es asi, este es un método muy bueno para ello

---
### Cifrado Asimétrico

En este modo se usa un par de claves.
Se generan dos claves, la ``publica`` y la ``privada``

Esto se usa porque hace muchos años cuando se requería compartir información, usar un método de cifrado Simétrico era inseguro porque había que compartir claves.

Con este sistema se crean dos claves, la clave publica se usa para cifrar y la clave privada para descifrar, la clave publica se la tienes que dar a la otra persona(con la que quieres compartir) y la privada te la quedas. Entonces la otra persona cifrará el archivo con la clave publica y este estará cifrado todo el viaje y llegara a ti, que teniendo la clave privada, podrás leer el archivo
