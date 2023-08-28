Para definir un enumerador en Swift, utiliza la siguiente sintaxis:

```swift
enum NombreDelEnum {
    case caso1
    case caso2
    // Agrega más casos si es necesario
}
```

Cada caso dentro del enumerador representa un valor único asociado con el nombre del enumerador.

Ejemplo de un enumerador que representa los días de la semana:

```swift
enum DiaSemana {
    case lunes
    case martes
    case miercoles
    case jueves
    case viernes
    case sabado
    case domingo
}
```

Una vez que has definido un enumerador, puedes utilizarlo para declarar variables y constantes y asignarles valores de los casos del enumerador.

Ejemplo de uso de un enumerador:

```swift
var diaLaboral = DiaSemana.lunes
```

En este ejemplo, hemos declarado una variable llamada `diaLaboral` de tipo `DiaSemana` y le hemos asignado el valor `lunes` del enumerador.

Los enumeradores también pueden tener valores asociados, lo que los hace más flexibles. Puedes asociar datos a cada caso del enumerador.

Ejemplo de enumerador con valores asociados:

```swift
enum FiguraGeometrica {
    case circulo(Double)
    case cuadrado(Double)
    case rectangulo(ancho: Double, altura: Double)
}
```

En este ejemplo, hemos definido un enumerador `FiguraGeometrica` con tres casos: `circulo`, `cuadrado` y `rectangulo`. El caso `circulo` tiene un valor asociado de tipo `Double`, que representa el radio del círculo. El caso `cuadrado` tiene un valor asociado de tipo `Double`, que representa el lado del cuadrado. El caso `rectangulo` tiene dos valores asociados, `ancho` y `altura`, ambos de tipo `Double`.

Ejemplo de uso de un enumerador con valores asociados:

```swift
let miFigura: FiguraGeometrica = .rectangulo(ancho: 5.0, altura: 3.0)

switch miFigura {
case .circulo(let radio):
    print("El círculo tiene un radio de \(radio) unidades.")
case .cuadrado(let lado):
    print("El cuadrado tiene un lado de \(lado) unidades.")
case .rectangulo(let ancho, let altura):
    print("El rectángulo tiene un ancho de \(ancho) unidades y una altura de \(altura) unidades.")
}
```

En este ejemplo, hemos declarado una constante `miFigura` de tipo `FiguraGeometrica` y le hemos asignado el valor `rectangulo(ancho: 5.0, altura: 3.0)`. Luego, utilizamos un switch para imprimir información específica dependiendo del caso del enumerador y sus valores asociados.
