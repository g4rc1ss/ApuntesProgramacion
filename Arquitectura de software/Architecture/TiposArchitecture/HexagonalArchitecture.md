# Hexagonal Architecture
Esta arquitectura lo que viene a decir es que la logica de la aplicacion debe de estar aislada de elementos exteriores, nada de acoplamiento con capas como bases de datos, API, etc.

Para poder realizar esta desacoplacion, se utiliza la inversion de dependencias. Esto consiste en el uso de interfaces para establecer contratos y usar la capacidad de abstraccion, de esta forma, las dependencias pueden resolverse desde otros puntos.

1. **Application** Es donde se ejecuta el core de la aplicacion, se definen las interfaces de las que va a hacer uso.  
**Es importante** dejar claro que las interfaces las define la aplicación y se ubicaran en la zona de **ports**. Debe de quedar claro porque gracias a esto es como se consigue el desacomplamiento de las capas.
1. **Ports**: Contiene la definicion de las interfaces en la capa de aplicacion.
1. **Adapters**: Aqui se implementan las clases necesarias para hacer funcionar la aplicacion, por ejemplo, el API, la Base de datos, etc.  
Las clases ubicadas en esta capa deberán implementar las interfaces de **ports**.

![Captura de pantalla 2022-01-07 175136](https://user-images.githubusercontent.com/28193994/148578321-cc23ef13-dd41-4afb-81b6-02c55a4cafb6.png)

De esta manera podemos apreciar que los adaptadores dependen de los **ports** y el core tambien, por tanto, este nunca se verá afectado si realizamos cambios en el resto de capas.

Si decidimos cambiar la presentacion, capa de datos o en general, cualquier capa aparte de core, simplemente debemos de implementar la interfaz que necesitemos ubicada en **ports** y modificar los archivos que se encargan de implementar las clases para indicar las nuevas y ya estaria el cambio. Si neceitamos modificar core, no hemos realizado bien la arquitectura.

> Creo que es un concepto bastante interesante, puesto que permite crear aplicaciones escalables en cuanto a arquitectura se refiere para poder ir realizando cambios, como actualizaciones de Frameworks, etc.
