package garaje.mecanico.herencias;

import garaje.mecanico.herencias.padre.Trabajo;

public class Revision extends Trabajo {

    @Override
    public double calcularPrecioTotal() {
        double totalHoras = super.calcularPrecioTotal();
        return totalHoras + 20;
    }
}
