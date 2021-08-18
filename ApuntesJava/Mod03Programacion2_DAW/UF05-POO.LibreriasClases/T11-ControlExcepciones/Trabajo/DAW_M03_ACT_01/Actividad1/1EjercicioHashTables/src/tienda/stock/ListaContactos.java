package tienda.stock;

import java.util.HashMap;

public class ListaContactos {
    private HashMap<Producto, Integer> contactos = new HashMap<>();

    public void eliminarProductos(Producto producto) {
        contactos.remove(producto);
    }

    public void modificarProductos(Producto clave, Producto newClave) {
        int valor = contactos.get(clave);
        contactos.put(newClave, valor);
        contactos.remove(clave);
    }

    public void altaContactos(Producto producto, int stock) {
        contactos.put(producto, stock);
    }

    public int getStock(Producto clave) {
        return contactos.get(clave);
    }

    public boolean limpiarHashMap() {
        contactos.clear();
        return true;
    }

    // region Getters and Setters
    public HashMap<Producto, Integer> getContactos() {
        return contactos;
    }

    public void setContactos(HashMap<Producto, Integer> contactos) {
        this.contactos = contactos;
    }
    //endregion

    @Override
    public boolean equals(Object o) {
        for (Producto proc: contactos.keySet())
            if(proc.equals(o))
                return true;
        return false;
    }
}
