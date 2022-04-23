# Visitor
También llamado: **Visitante**

## Proposito

Patrón que te permite separar algoritmos de los objetos sobre los que operan.

## Problema

Busca separar un algoritmo de la estructura de un objeto. La operación se implementa de forma que no se modifique el código de las clases sobre las que opera.

Usa el patrón Visitor cuando:
- Una estructura de objetos contiene muchas clases de
objetos con interfaces distintas, y se quiere realizar
sobre ellos operaciones que son distintas en cada clase
concreta
- Se quieren realizar muchas operaciones distintas sobre
los objetos de una estructura, sin incluir dichas
operaciones en las clases
- Las clases que forman la estructura de objetos no
cambian, pero las operaciones sobre ellas sí

## Solucion

El patrón Visitor sugiere que coloques el nuevo comportamiento en una clase separada llamada visitante, en lugar de intentar integrarlo dentro de clases existentes. El objeto que originalmente tenía que realizar el comportamiento se pasa ahora a uno de los métodos del visitante como argumento, de modo que el método accede a toda la información necesaria contenida dentro del objeto.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147789350-ee611007-e2a2-4d43-9828-511b99fa4635.png)
