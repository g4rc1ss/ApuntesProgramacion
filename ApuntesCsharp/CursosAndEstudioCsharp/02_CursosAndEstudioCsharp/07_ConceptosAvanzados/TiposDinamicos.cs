namespace CursosAndEstudioCsharp._07_ConceptosAvanzados
{
    internal class TiposDinamicos
    {
        public TiposDinamicos()
        {
            var ec = new ExampleClass();
            //ec.exampleMethod1(10, 4);

            dynamic dynamic_ec = new ExampleClass();
            dynamic_ec.exampleMethod1(10, 4);

            dynamic_ec.someMethod("some argument", 7, null);
            dynamic_ec.nonexistentMethod();

            dynamic d = 8;
            var suma = d + 4;
        }

        private class ExampleClass
        {
            public ExampleClass() { }
            public ExampleClass(int v) { }

            public void exampleMethod1(int i) { }
            public void exampleMethod2(string str) { }
        }
    }
}
