# Interoperabilidad con Objective-C:
Swift fue diseñado para ser altamente compatible con Objective-C, lo que significa que puedes utilizar clases, métodos, propiedades y otros elementos escritos en Objective-C en un proyecto de Swift sin problemas.

Ejemplo:

Supongamos que tienes una clase en Objective-C llamada "Persona" que quieres utilizar en Swift:

```objective-c
// Persona.h
#import <Foundation/Foundation.h>

@interface Persona : NSObject

@property (nonatomic, strong) NSString *nombre;
@property (nonatomic) NSInteger edad;

- (void)saludar;

@end

// Persona.m
#import "Persona.h"

@implementation Persona

- (void)saludar {
    NSLog(@"Hola, mi nombre es %@ y tengo %ld años.", self.nombre, self.edad);
}

@end
```

Ahora, puedes utilizar esta clase en Swift:

```swift
import Foundation

let persona = Persona()
persona.nombre = "Juan"
persona.edad = 30
persona.saludar()
```

En este ejemplo, hemos importado el archivo de encabezado Objective-C usando `#import` y luego hemos creado una instancia de la clase "Persona" en Swift. Podemos acceder y establecer sus propiedades y llamar a su método "saludar" sin problemas.

# Interoperabilidad con C:
Swift también puede interoperar con código escrito en C utilizando el módulo `C` y el uso de `import` en Swift.

Ejemplo:

Supongamos que tienes una función escrita en C que quieres utilizar en Swift:

```c
// my_c_functions.h
#ifndef MY_C_FUNCTIONS_H
#define MY_C_FUNCTIONS_H

#include <stdio.h>

int sumar(int a, int b);

#endif
```

```c
// my_c_functions.c
#include "my_c_functions.h"

int sumar(int a, int b) {
    return a + b;
}
```

Ahora, puedes utilizar esta función en Swift:

```swift
import C

let resultado = sumar(5, 10)
print("Resultado: \(resultado)") // Resultado: 15
```

En este ejemplo, hemos importado el módulo `C` en Swift y hemos llamado a la función `sumar` escrita en C. La interoperabilidad con C es un poco más explícita en Swift que con Objective-C, ya que debes utilizar `import C` y asegurarte de que las funciones estén definidas en un archivo de cabecera adecuado.
