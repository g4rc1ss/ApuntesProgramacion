## Módulos integrados

Python viene con una [biblioteca de módulos estándar](https://docs.python.org/3/library/).

Algunos módulos están integrados en el intérprete; estos proporcionan acceso a operaciones que no son parte del núcleo del lenguaje pero que están integrados, ya sea por eficiencia o para proporcionar acceso a primitivas del sistema operativo, como las llamadas al sistema.  
Un módulo en particular merece cierta atención: `sys`, que está integrado en cada intérprete de Python. Las variables `sys.ps1` y `sys.ps2` definen las cadenas utilizadas como indicadores primarios y secundarios si el intérprete está en el modo interactivo:

```text
>>> import sys
>>> sys.ps1
'>>> '
>>> sys.ps2
'... '
```

La variable `sys.path` es una lista de cadenas que determina la ruta de búsqueda del intérprete para los módulos: vea lo que imprime para usted cuando ejecuta el código de la tarea.

Recuerda que puedes usar el atajo &shortcut:CodeCompletion; después de un punto (.) para explorar los métodos disponibles de un módulo. Puede leer más acerca de los módulos estándar <a href="https://docs.python.org/3/tutorial/modules.html#standard-modules">aquí</a>.

Para obtener información más estructurada y detallada, también puede consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6019#built-in-modules?utm_source=jba&utm_medium=jba_courses_links).  

### Tarea
Imprima la fecha y hora actuales usando un módulo integrado importado `datetime`.  

<div class='hint'>Use la función <code>datetime.datetime.today()</code>.</div>