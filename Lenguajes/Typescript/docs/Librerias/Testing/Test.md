# Testing

**Pruebas unitarias y de integración:**

En TypeScript, al igual que en cualquier otro lenguaje de programación, puedes escribir pruebas unitarias y de integración para asegurarte de que tus funciones, clases y componentes funcionen correctamente. Las pruebas unitarias se enfocan en probar componentes individuales de forma aislada, mientras que las pruebas de integración verifican el comportamiento de múltiples componentes en conjunto.

**Frameworks de pruebas:**

Hay varios frameworks populares para escribir pruebas en TypeScript, como Jest, Mocha y Jasmine. En este ejemplo, utilizaremos Jest, que es uno de los más utilizados y fáciles de configurar.

**Instalación:**

Primero, asegúrate de tener Node.js y npm instalados en tu entorno de desarrollo. Luego, puedes instalar Jest utilizando el siguiente comando:

```bash
npm install jest --save-dev
```

**Escribir pruebas:**

A continuación, crearemos un archivo de prueba llamado `suma.test.ts` para probar una función de suma simple:

```typescript
function sumar(a: number, b: number): number {
  return a + b;
}

test('Suma de dos números', () => {
  expect(sumar(2, 3)).toBe(5);
});
```

En este ejemplo, definimos una función `sumar` que suma dos números y devuelve el resultado. Luego, escribimos una prueba utilizando la función `test` de Jest. En la prueba, llamamos a la función `sumar` con los números 2 y 3 y utilizamos la función `expect` para verificar si el resultado es igual a 5 utilizando `toBe`.

**Ejecutar pruebas:**

Para ejecutar las pruebas, puedes agregar un script en tu archivo `package.json`:

```json
"scripts": {
  "test": "jest"
}
```

Luego, puedes ejecutar tus pruebas utilizando el siguiente comando:

```bash
npm test
```

Jest buscará automáticamente todos los archivos con el patrón `.test.ts` en tu proyecto y ejecutará las pruebas.

**Assertions (afirmaciones):**

Las afirmaciones (assertions) son utilizadas para verificar el resultado esperado de una prueba. Jest proporciona una amplia gama de afirmaciones que puedes utilizar en tus pruebas. Algunos ejemplos son:

- `expect(valor).toBe(otroValor)`: Verifica que `valor` sea estrictamente igual a `otroValor`.
- `expect(valor).toEqual(otroValor)`: Verifica que `valor` sea igual a `otroValor`, pero sin comprobación estricta.
- `expect(valor).toBeDefined()`: Verifica que `valor` esté definido.
- `expect(valor).toBeNull()`: Verifica que `valor` sea nulo.
- `expect(valor).toBeTruthy()`: Verifica que `valor` sea verdadero.
- `expect(valor).toBeFalsy()`: Verifica que `valor` sea falso.
- `expect(valor).toContain(elemento)`: Verifica que `valor` contenga `elemento` (en un arreglo o una cadena).

Estos son solo algunos ejemplos de afirmaciones disponibles en Jest. Puedes consultar la documentación de Jest para obtener una lista completa de afirmaciones y sus usos.

**Configuración adicional:**

Jest proporciona una amplia gama de configuraciones para adaptarse a tus necesidades. Puedes personalizar opciones como la ubicación de tus archivos de prueba, el informe de cobertura de código, las rutas excluidas, entre otras.

Para configurar Jest, puedes crear un archivo `jest.config.js` en la raíz de tu proyecto y agregar tus opciones de configuración.
