![1-moduleSetting](Capturas/1-moduleSetting.JPG)

Primero Vamos a un modulo del proyecto, click derecho y `Open Module Settings`

![1-moduleSetting](Capturas/2-goToArtifacts.JPG)

Después nos aparecerá esta ventana en la que seleccionaremos Artifacts

![1-moduleSetting](Capturas/3-selectTipoDeCompilacion.JPG)

Después le darémos al `+ > JAR > From modules with dependencies...`

![1-moduleSetting](Capturas/4-ConfigurarCreacionDelJar.JPG)

Veremos esta ventana en la que:

- Module: Seleccionamos el modulo que queremos convertir en ``.jar``, si seleccionamos el All Modules se compilaran todos los módulos en `.Jar` independientes porque los jar se crean por modulo

- Main Class: Seleccionaremos la clase Main del modulo seleccionado

Después seleccionaremos la segunda opción y le daremos a Ok

![1-moduleSetting](Capturas/5-buildArtifacts.JPG)

Una vez guardados los cambios, si queremos compilar y por tanto, crear el JAR, `Build > Build Artifacts...`

![1-moduleSetting](Capturas/6-UbicacionCreacionJar.JPG)

Se guardará en esa ruta


Una vez realizado podremos ejecutar el Jar dándole doble click siempre que tengamos Java instalado en el equipo o con el comando ``java -jar archivo.jar``