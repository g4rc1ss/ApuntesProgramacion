package tienda.stock;

public class Producto {
    private String nombreProducto;
    private int precio;

    public Producto(String nombreProducto, int precio) {
        this.nombreProducto = nombreProducto;
        this.precio = precio;
    }

    // region Getters and Setters
    public String getNombreProducto() {
        return nombreProducto;
    }

    public void setNombreProducto(String nombreProducto) {
        this.nombreProducto = nombreProducto;
    }

    public int getPrecio() {
        return precio;
    }

    public void setPrecio(int precio) {
        this.precio = precio;
    }
    //endregion


    @Override
    public boolean equals(Object obj) {
        // Pasamos el objeto que recibimos a tipo Producto(como es para comparar productos...)
        Producto objProducto = (Producto) obj;
        // true o false si se cumplen que sea el mismo nombre y precio
        return nombreProducto.equals(objProducto.getNombreProducto()) &&
                precio == objProducto.getPrecio();
    }

    @Override
    public int hashCode() {
        return nombreProducto.hashCode() + precio;
    }
}
