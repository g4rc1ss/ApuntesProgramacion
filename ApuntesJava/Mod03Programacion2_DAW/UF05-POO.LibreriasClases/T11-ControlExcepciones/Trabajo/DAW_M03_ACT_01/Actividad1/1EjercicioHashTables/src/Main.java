import tienda.stock.ListaContactos;
import tienda.stock.Producto;

import java.util.HashMap;

public class Main {
    public static void main(String[] args) {
        // region Comprobaciones
        ////// Comprobar que funciona el cambio de hashCode
        System.out.println(new Producto("nombre", 2).hashCode());
        System.out.println("nombre".hashCode());
        //endregion

        Producto producto1 = new Producto("producto", 23);
        Producto producto2 = new Producto("producto", 3432);
        Producto producto3 = new Producto("producto", 3435);

        // Creamos el hashmap y le agregamos productos
        ListaContactos listaContactos = new ListaContactos();
        listaContactos.altaContactos(producto1, 4);
        listaContactos.altaContactos(producto2, 56);
        listaContactos.altaContactos(producto3, 54);
        System.out.println(listaContactos.getStock(producto1));

        // Eliminamos el producto1 del hashmap y comprobamos si se ha eliminado correctamente
        listaContactos.eliminarProductos(producto1);
        System.out.println(listaContactos.getContactos().containsKey(producto1));

        // Modificamos productos
        Producto producto3Modificado = new Producto("nombre", 23);
        listaContactos.modificarProductos(producto3, producto3Modificado);
        System.out.println(listaContactos.getStock(producto3Modificado));

        ////// Comprobar que funciona el cambio a equals
        System.out.println(listaContactos.equals(new Producto("producto", 3432))
                        ? "El resultado del equals de las Keys es True"
                        : "El resultado del equals de las Keys es False");

        // Limpiamos la tabla de Hashes entera
        System.out.println(listaContactos.limpiarHashMap());
    }
}
