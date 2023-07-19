# Elasticsearch
Elasticsearch es un motor de búsqueda y análisis de datos distribuido. Está diseñado para manejar grandes volúmenes de datos de manera rápida y eficiente

1. **Búsqueda de texto completo**: Elasticsearch es especialmente eficiente en la búsqueda de texto en grandes conjuntos de datos

2. **Estructura de documentos JSON**: Los datos en Elasticsearch se almacenan en documentos JSON, lo que proporciona una estructura flexible y permite una fácil indexación y búsqueda.

3. **Escalabilidad**: Es altamente escalable y permite distribuir datos y consultas en múltiples nodos, lo que facilita el manejo de grandes volúmenes de información.

4. **Velocidad**: Elasticsearch utiliza técnicas de búsqueda en memoria y paralelización para ofrecer consultas rápidas y respuestas en tiempo real.

5. **Motor de análisis**: Además de búsqueda, Elasticsearch es un potente motor de análisis que permite realizar agregaciones, estadísticas, visualizaciones y análisis de datos complejos.

6. **Alta disponibilidad y tolerancia a fallos**: Ofrece mecanismos de replicación y sharding para garantizar la disponibilidad de los datos y la resistencia a fallos.

7. **API RESTful**: Elasticsearch proporciona una interfaz API RESTful que permite interactuar con el sistema utilizando solicitudes HTTP, lo que facilita su integración con diversas aplicaciones y lenguajes de programación.


## Consulta de coincidencia (match)
Buscar documentos que contengan un término específico en un campo determinado.

```json
GET /mi_indice/_search
{
  "query": {
    "match": {
      "descripcion": "elasticsearch"
    }
  }
}
```

## Consulta de término (term)
Buscar documentos que coincidan exactamente con un valor en un campo específico.

```json
GET /mi_indice/_search
{
  "query": {
    "term": {
      "departamento.keyword": "ventas"
    }
  }
}
```

## Consulta de rango (range)
Buscar documentos cuyo valor en un campo se encuentre dentro de un rango determinado.

```json
GET /mi_indice/_search
{
  "query": {
    "range": {
      "edad": {
        "gte": 18,
        "lte": 30
      }
    }
  }
}
```

## Consulta de combinación (bool)
Combina varias consultas utilizando operadores lógicos (AND, OR, NOT).

```json
GET /mi_indice/_search
{
  "query": {
    "bool": {
      "must": [
        { "match": { "titulo": "elasticsearch" } },
        { "range": { "fecha_publicacion": { "gte": "2023-01-01" } } }
      ],
      "must_not": { "term": { "categoria.keyword": "excluida" } }
    }
  }
}
```

## Consulta de término (term) con filtro
Combina una consulta de término con un filtro para buscar documentos que coincidan exactamente con un valor, pero sin afectar el puntaje de relevancia.

```json
GET /mi_indice/_search
{
  "query": {
    "constant_score": {
      "filter": {
        "term": { "categoria.keyword": "tecnologia" }
      }
    }
  }
}
```

## Consulta de agregación (aggregation)
Realiza una consulta para obtener estadísticas o agrupar datos.

```json
GET /mi_indice/_search
{
  "size": 0,
  "aggs": {
    "promedio_edad": {
      "avg": {
        "field": "edad"
      }
    },
    "departamentos": {
      "terms": {
        "field": "departamento.keyword"
      }
    }
  }
}
```


## Consulta de filtrado (Filtering)
Buscará documentos en el índice "mi_indice" que tengan el campo "departamento.keyword" con el valor "ventas" y que también tengan un salario mayor o igual a 50000
```json
GET /mi_indice/_search
{
  "query": {
    "bool": {
      "filter": [
        { "term": { "departamento.keyword": "ventas" } },
        { "range": { "salario": { "gte": 50000 } } }
      ]
    }
  }
}
```

## Crear un documento (Create)
Crea un documento con la estructura JSON que le pases
```json
POST /mi_indice/_doc
{
  "nombre": "Juan",
  "apellido": "Pérez",
  "edad": 30,
  "departamento": "tecnología",
  "salario": 60000
}
```

## Actualizar un documento (Update)
Busca el documento con id 1 y actualiza el valor de `salario` a `65000`

> Si el documento no existe, se creará uno nuevo con el id y el valor que le estamos agregando
```json
POST /mi_indice/_update/1
{
  "doc": {
    "salario": 65000
  }
}
```

## Eliminar un documento (Delete)

```json
DELETE /mi_indice/_doc/1
```
