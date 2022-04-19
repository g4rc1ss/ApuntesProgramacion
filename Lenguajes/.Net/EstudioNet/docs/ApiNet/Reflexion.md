Permite obtener información sobre los ensamblados cargados y los tipos definidos dentro de ellos, como clases, interfaces y tipos de valor (es decir, estructuras y enumeraciones). También se puede usar para crear instancias de tipos en tiempo de ejecución, para llamarlas y para acceder a ellas.

Normalmente, la reflexión se usa para lo siguiente:
- **Assembly** para definir y cargar ensamblados, cargar módulos enumerados en el manifiesto del ensamblado y buscar un tipo en este ensamblado y crear una instancia a partir de él.
- **Module** para detectar información, como el ensamblado que contiene el módulo y las clases del módulo. También puede obtener todos los métodos globales u otros métodos específicos no globales definidos en el módulo.
- **ConstructorInfo** para detectar información, como el nombre, los parámetros, los modificadores de acceso (por ejemplo, public o private) y detalles de implementación (por ejemplo, abstract o virtual) de un constructor. Usar el método `GetConstructors` o `GetConstructor` de un `Type` para invocar un constructor específico.
- **MethodInfo** para detectar información, como el nombre, el tipo de retorno, los parámetros, los modificadores de acceso (por ejemplo, public o private) y detalles de implementación (por ejemplo, abstract o virtual) de un método. Usar el método `GetMethods` o `GetMethod` de un `Type` para invocar un método específico.
- **FieldInfo** para detectar información como el nombre, los modificadores de acceso (por ejemplo, public o private) y detalles de la implementación (por ejemplo, static) de un campo, así como para obtener o establecer los valores del campo.
- **EventInfo** para detectar información, como el nombre, el tipo de datos del controlador de eventos, los atributos personalizados, el tipo declarativo y el tipo reflejado de un evento, y para agregar o quitar controladores de eventos.
- **PropertyInfo** para detectar información, como el nombre, el tipo de datos, la declaración de tipo, el tipo reflejado y el estado de solo lectura o de escritura de una propiedad, así como para obtener o establecer los valores de la propiedad.
- **ParameterInfo** para detectar información, como el nombre del parámetro, el tipo de datos, si un parámetro es de entrada o de salida, y la posición del parámetro en una firma de método.
- **CustomAttributeData** para detectar información sobre atributos personalizados cuando se trabaja en el contexto de solo reflexión de un dominio de aplicación. CustomAttributeData permite examinar los atributos sin crear instancias de ellos. Las clases del espacio de nombres `System.Reflection.Emit` proporcionan una forma especializada de reflexión que permite compilar tipos en tiempo de ejecución.
