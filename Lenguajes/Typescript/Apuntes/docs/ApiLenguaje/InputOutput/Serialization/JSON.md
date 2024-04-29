# Serializacion JSON

**Serialización de objetos a JSON:**

La serialización convierte un objeto JavaScript en una cadena JSON. Puedes utilizar la función `JSON.stringify()` para realizar la serialización. Aquí tienes un ejemplo:

```typescript
interface Persona {
  nombre: string;
  edad: number;
}

const persona: Persona = {
  nombre: 'Juan',
  edad: 30
};

// Serialización del objeto a JSON
const personaJSON = JSON.stringify(persona);

console.log(personaJSON); // Salida: {"nombre":"Juan","edad":30}
```

En este ejemplo, tenemos una interfaz `Persona` que define la estructura de nuestro objeto. Luego, creamos un objeto `persona` con valores específicos. Utilizamos `JSON.stringify()` para convertir el objeto en una cadena JSON, que almacenamos en la variable `personaJSON`. Al imprimir `personaJSON`, obtendremos la representación en formato JSON del objeto.

**Deserialización de JSON a objetos:**

La deserialización convierte una cadena JSON en un objeto JavaScript. Puedes utilizar la función `JSON.parse()` para realizar la deserialización. Aquí tienes un ejemplo:

```typescript
const personaJSON = '{"nombre":"Juan","edad":30}';

// Deserialización de JSON a objeto
const persona = JSON.parse(personaJSON) as Persona;

console.log(persona); // Salida: { nombre: 'Juan', edad: 30 }
```

En este ejemplo, tenemos una cadena JSON en la variable `personaJSON`. Utilizamos `JSON.parse()` para convertir la cadena JSON en un objeto JavaScript. Es importante especificar el tipo del objeto utilizando el operador `as Persona` para asegurarnos de que TypeScript lo interprete correctamente. Al imprimir `persona`, obtendremos el objeto JavaScript resultante de la deserialización.

**Consideraciones adicionales:**

Al serializar y deserializar objetos JSON en TypeScript, ten en cuenta las siguientes consideraciones:

- Asegúrate de que el objeto que estás serializando no contenga referencias a funciones o datos no serializables, ya que solo se conservarán los valores de datos en el JSON resultante.
- Al deserializar JSON, es importante especificar el tipo esperado utilizando el operador `as` o una conversión adecuada para que TypeScript pueda realizar el chequeo de tipos.
- Si el JSON contiene datos que no se ajustan al tipo esperado, se generará una excepción durante la deserialización. Asegúrate de manejar adecuadamente los errores al deserializar JSON.
