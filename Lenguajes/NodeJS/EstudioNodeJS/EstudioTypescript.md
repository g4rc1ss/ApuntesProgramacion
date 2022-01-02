# Introducción
Typescript es un lenguaje creado para poder proporcionar una serie de caracteristicas de las que carece el lenguaje Javascript como, por ejemplo, el tipado estatico.

Typescript es una lenguaje que se ha de compilar a Javascript, no es un lenguaje que pueda ser interpretado por los navegadores

Creamos el proyecto:
```powershell
npm init
```

## Instalar modulo typescript
Para usar typescript tenemos que instalarlo como si de una dependencia se tratase, por tanto:

```powershell
npm install typescript
yarn add typescript
```

## Configurar
Primero creamos el archivo de typescript y lo llamamos `tsconfig.json`
```JSON
{
    "compilerOptions": {
        // directorio donde se van a compilar en .js
        "outDir": "bin",
        // Indicamos que queremos que se pueda depurar los typescript
        "sourceMap": true
    },
    "include": [
        // ruta donde se almacenan los typescript
        "src/**/*"
    ]
}
```

`package.json` es donde se va a indicar todo lo relacionado con el proyecto como las dependencias, nombre del proyecto, archivo principal, intrucciones para iniciarlo, etc.

Para configurar automatizar los procesos de ejecucion del proyecto, hay una seccion dentro del archivo llamada `scripts` donde indicaremos: `"nombre": "comando o archivo to execute"`.

Un ejemplo de scripts para typescript podria ser el siguiente:
```json
"scripts": {
    "start": "tsc --project tsconfig.json && node .\\bin\\index.js",
    "reinstall": "yarn remove-node-modules && yarn install",
    "remove-node-modules": "npx rimraf node_modules **/node_modules"
}
```

## Typescript en VS Code
Para mi VS Code es de los mejores editores de codigo, despues de los IDE especificos para cada lenguaje.

Podemos configurar la compilacion y ejecucion del codigo directamente mediante el uso de tasks y el launch de Visual Studio Code, junto con un archivo de configuracion propio de typescript.

Ahora creamos el archivo `tasks.json`
```JSON
{
	"version": "2.0.0",
	"tasks": [
		{
			"type": "typescript",
			"tsconfig": "../tsconfig.json",
			"option": "watch",
			"problemMatcher": [
				"$tsc-watch"
			],
			"group": "build",
			"label": "tsc: build"
		}
	]
}
```
Creamos el archivo `launch.json`
```JSON
{
    "version": "0.2.0",
    "configurations": [
        {
            "type": "node",
            "request": "launch",
            "name": "Launch Program",
            "program": "${workspaceFolder}/bin/index.js",
            "preLaunchTask": "tsc: build",
            "outFiles": [
                "${workspaceFolder}/**/*.js",
                "!**/node_modules/**"
            ]
        }
    ]
}
```

# Estructura del código

```Typescript
namespace Prueba {
    import { Clase } from "./EspacioNombres/";
    /*
    *
    */   
}
```
- ``namespace`` -> indica la ubicación del programa

- ``import`` -> Para importar librerías y módulos

---
## Declaración de variables
```Typescript
let cadena: string = "";
let numero: number = 0;
let booleano: boolean = true;
let sinTipo: any;
```


# Programación Orientada a Objetos

## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Typescript
class Clase {
    nombre: string;
    apellidos: string;

    constructor(nombre: string, apellidos: string) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }

    nombreFuncion(): void {
        // Code
    }

    nombreRetorno(): string {
        return "";
    }
}
```

---
## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Se implementan como clases y se definen como entidades separadas de las clases.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido

El beneficio que da las interfaces es que permite tener una capa de abstraccion en el codigo, donde puedes hacer uso de ella para ejecutar ciertas clases usando la interfaz como instancia.

```Typescript
interface Gato {
    nombre: string;
    raza: string;
    color: string;
}
```

---
## Type
Un type nos permite definir el tipo de dato que vamos a usar en nuestras propiedades y métodos; pero a diferencia de las interfaces no podemos extender un type, ni ampliar sus capacidades. Pero si podemos declarar tipos personalizados y puede tener varios tipos de datos.

```Typescript
type Gato = {
    nombre: string;
    raza: string;
    color: string;
}
```
