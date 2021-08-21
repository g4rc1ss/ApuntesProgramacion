# Documentación DocString

Las cadenas de documentación o docstrings son textos que se escriben entre triples comillas dentro de los programas para documentarlos. Cuando se desarrolla un proyecto donde colaboran varias personas contar con información clara y precisa que facilite la comprensión del código es imprescindible y beneficia a todos los participantes y al propio proyecto.

Las funciones, clases y módulos deben ir convenientemente documentados. La información de las docstrings estará disponible cuando se edite el código y, también, durante la ejecución de los programas:

```python
def area_trapecio(BaseMayor, BaseMenor, Altura):
    '''area_trapecio: Calcula el área de un trapecio.
    area_trapecio = (BaseMayor + BaseMenor) * Altura / 2''' 
    return (BaseMayor + BaseMenor) * Altura / 2
  
print(area_trapecio(10,4,4))  # Resultado: 28
print(area_trapecio.__doc__)
```

### Ver documentación en la consola

``python -m pydoc DocStrings``

### Guardar la documentación en formato HTML

``python -m pydoc -w DocStrings``

### Ejecutar un servidor Web para leer los documentos
``python -m pydoc -p 8080``