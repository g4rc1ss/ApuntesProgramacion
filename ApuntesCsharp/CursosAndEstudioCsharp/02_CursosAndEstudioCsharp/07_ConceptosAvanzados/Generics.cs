using System;

namespace CursosAndEstudioCsharp._07_ConceptosAvanzados
{
    // Declare the generic class.
    public class GenericList<T>
    {
        public void Add(T input) { }
    }

    public class TestGenericList
    {
        private class ExampleClass { }

        public static void TestGeneric()
        {
            // Declare a list of type int.
            var list1 = new GenericList<int>();
            list1.Add(1);

            // Declare a list of type string.
            var list2 = new GenericList<string>();
            list2.Add("");

            // Declare a list of type ExampleClass.
            var list3 = new GenericList<ExampleClass>();
            list3.Add(new ExampleClass());

            Ejemplo<int>(7);
            Ejemplo<string>("hola");
            Ejemplo<DateTime>(DateTime.Now);
        }

        public static void Ejemplo<T>(T tipo)
        {
            Console.WriteLine(tipo);
        }

    }
}
