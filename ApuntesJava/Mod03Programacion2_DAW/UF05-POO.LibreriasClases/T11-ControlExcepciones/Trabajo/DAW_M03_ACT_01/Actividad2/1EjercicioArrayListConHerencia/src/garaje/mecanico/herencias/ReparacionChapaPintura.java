package garaje.mecanico.herencias;

import garaje.mecanico.herencias.padre.Trabajo;

public class ReparacionChapaPintura extends Trabajo {

    @Override
    public double calcularPrecioTotal() {
        double totalHoras = super.calcularPrecioTotal();
        return totalHoras + (getPrecioMaterial() * 1.3);
    }
}
