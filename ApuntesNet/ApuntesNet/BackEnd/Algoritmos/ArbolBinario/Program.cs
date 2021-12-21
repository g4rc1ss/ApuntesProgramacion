using System;
using ArbolBinario.Clase;

namespace ArbolBinario
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var arbolParaPrueba = CrearArbolConDatosPrueba();
            var path5 = arbolParaPrueba.GetPathOfValue(5);
            var path4 = arbolParaPrueba.GetPathOfValue(4);

            for (var i = 0; i < (path4.Count < path5.Count ? path4.Count : path5.Count); i++)
            {
                if (path4[i] != path5[i])
                {
                    Console.WriteLine($"El superior en comun es {path4[i - 1]}");
                    break;
                }
            }
        }

        private static BinaryTree<int> CrearArbolConDatosPrueba()
        {
            var arbol = new BinaryTree<int>(1);
            // Agregar los hijos izquierdos
            arbol.AddLeftSoon(2);
            arbol.Left.AddLeftSoon(3);
            arbol.Left.AddRightSoon(4);
            arbol.Left.Left.AddLeftSoon(5);

            // Agregar los hijos Derechos
            arbol.AddRightSoon(6);
            arbol.Right.AddLeftSoon(7);
            arbol.Right.AddRightSoon(8);

            return arbol;
        }
    }
}
