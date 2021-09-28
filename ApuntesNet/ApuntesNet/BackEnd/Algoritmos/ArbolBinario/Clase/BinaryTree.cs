using System.Collections.Generic;

namespace ArbolBinario.Clase {
    internal class BinaryTree<T> {
        public BinaryTree<T> Left { get; private set; }
        public BinaryTree<T> Right { get; private set; }
        private readonly T objectToSave;

        public BinaryTree() {

        }

        public BinaryTree(T value) {
            objectToSave = value;
        }

        public void AddLeftSoon(T value) {
            Left = new BinaryTree<T>(value);
        }

        public void AddRightSoon(T value) {
            Right = new BinaryTree<T>(value);
        }

        public T getValue() {
            return objectToSave;
        }
    }

    internal static class BinaryTreeExtensions {
        public static List<T> GetPathOfValue<T>(this BinaryTree<T> root, T valueToSearch) {
            var listaValor = new List<T> {
                root.getValue()
            };

            if (root.getValue().Equals(valueToSearch)) {
                return listaValor;
            }

            if (root.Left is not null) {
                var listaLeft = GetPathOfValue(root.Left, valueToSearch);
                if (listaLeft.Contains(valueToSearch))
                    listaValor.AddRange(listaLeft);
            }

            if (root.Right is not null) {
                var listaRight = GetPathOfValue(root.Right, valueToSearch);
                if (listaRight.Contains(valueToSearch))
                    listaValor.AddRange(listaRight);
            }

            return listaValor;
        }
    }
}
