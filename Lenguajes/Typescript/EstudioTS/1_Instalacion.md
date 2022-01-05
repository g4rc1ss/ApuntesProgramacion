# Introducción
Typescript es un lenguaje creado para poder proporcionar una serie de caracteristicas de las que carece el lenguaje Javascript como, por ejemplo, el tipado.

Typescript es una lenguaje que se ha de transpilar a Javascript, no es un lenguaje que pueda ser interpretado por los navegadores

Creamos el proyecto:
```powershell
npm init
```

## Instalar modulo typescript
Para usar typescript tenemos que instalarlo como si de una dependencia se tratase, por tanto:

```powershell
npm install typescript
```

## Configurar
**package.json** es donde se va a indicar todo lo relacionado con el proyecto como las dependencias, nombre del proyecto, archivo principal, intrucciones para iniciarlo, etc.

Abrimos el archivo **package.json** y agregamos la siguiente opcion
```json
"scripts": {
    "tsc": "tsc"
}
```
Ejecutamos el siguiente comando
```powershell
npm run tsc -- --init
```

Gracias a este comando, inicializamos un archivo llamado **tsconfig.json**, este archivo se encarga de la configuracion de este lenguaje. Donde se va a compilar, establecer restricciones, etc. Por el momento descomentamos la linea `OutDir`, que es donde se ubicarán los archivos transpilados a **JS**.

![image](https://user-images.githubusercontent.com/28193994/148195995-55dc6d74-eb72-4b98-9942-289cb8522309.png)


Hay un modulo en Node, que nos permite directamente la ejecucion de `Typescript` sin transpilación, pero no es nada recomendable el uso de este en un entorno de produccion. Por tanto se hara la lo siguiente:

Instalamos el modulo **ts-node-dev**
```powershell
npm install --save-dev ts-node-dev
```

Dentro del **package.json** agregamos dos scripts mas, uno para entorno de desarrollo y otro para produccion.

```json
"scripts": {
  "build": "npm install && npm run tsc",
  "tsc": "tsc",
  "dev": "ts-node-dev --respawn --transpile-only ./app/app.ts",
  "prod": "tsc && node ./build/app.js",
  "reinstall": "npm run remove-node-modules && npm install",
  "clean": "npx rimraf node_modules **/node_modules && npx rimraf ./build"
},
```

Para ejecutar el programa, se puede usar el comando
```powershell
npm run **option**

# example
npm run dev
```

## Typescript en VS Code
Depurar Typescript con Visual Studio Code se puede hacer de varias formas.

1. Ejecutando el comando correspondiente, por ejemplo con la configuracion anterior, `npm run dev`
1. Accediendo al archivo `package.json`, justo encima de donde pone **scripts** hay una opcion generada por VsCode que se llama **Debug**, le damos y nos aparecera un menu, seleccionamos la opcion que queremos ejecutar y listo.
1. En el editor, en el panel izquierdo, seleccionamos la opcion llamada `Run and Debug`![image](https://user-images.githubusercontent.com/28193994/148217474-15390367-2897-4452-ae7e-8906920921c1.png), le damos a `create launch.json`, no seleccionamos nada, queremos una configuracion vacia y luego, dentro del archivo, le damos a `ctrl + espace` y seleccionamos `Run npm start` para que genere la plantilla. Al final deberia de quedar de la siguiente forma.
    ```json
    "configurations": [
        {
            "command": "npm run dev",
            "name": "Develop",
            "request": "launch",
            "type": "node-terminal",
            
        },
        {
            "command": "npm run prod",
            "name": "Production",
            "request": "launch",
            "type": "node-terminal"
        }
    ]
    ```
