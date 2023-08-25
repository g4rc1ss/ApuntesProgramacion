# Enumeradores

Los enumeradores te permiten definir un conjunto de constantes con nombres descriptivos.
```typescript
enum DiaSemana {
    Lunes,
    Martes,
    Miércoles,
    Jueves,
    Viernes,
    Sábado,
    Domingo
}
let dia: DiaSemana = DiaSemana.Martes;
console.log(dia); // Output: 1
```