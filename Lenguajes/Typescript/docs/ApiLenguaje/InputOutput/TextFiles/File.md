**Lectura de un archivo de texto:**

```typescript
import { readFile } from 'fs';

// Ruta del archivo de texto
const rutaArchivo = 'ruta/del/archivo.txt';

// Lectura del archivo de texto
readFile(rutaArchivo, 'utf8', (error, datos) => {
  if (error) {
    console.error('Error al leer el archivo:', error);
    return;
  }
  
  console.log('Contenido del archivo de texto:', datos);
});
```

En este ejemplo, utilizamos la función `readFile()` para leer el contenido del archivo de texto especificado en la `rutaArchivo`. El segundo parámetro `'utf8'` indica la codificación del archivo de texto. En la devolución de llamada, verificamos si se produjo algún error durante la lectura y, de ser así, lo mostramos en la consola. Si la lectura se realiza correctamente, mostramos el contenido del archivo de texto en la consola.

**Consideraciones adicionales:**

Al leer archivos de texto, ten en cuenta las siguientes consideraciones:

- Asegúrate de proporcionar la ruta correcta del archivo en la `rutaArchivo`. Puedes utilizar rutas relativas o absolutas según tus necesidades.
- El segundo parámetro de `readFile()` especifica la codificación del archivo de texto. Si no se proporciona, los datos se devolverán como un objeto `Buffer`. Si conoces la codificación del archivo, asegúrate de especificarla para obtener el contenido en formato de cadena de texto.
- Si necesitas leer archivos grandes o realizar operaciones más complejas, como leer el archivo en fragmentos o realizar análisis y procesamiento adicional, puedes considerar el uso de `createReadStream()` en lugar de `readFile()`. `createReadStream()` te permite leer el archivo en fragmentos y trabajar con ellos de manera eficiente.
