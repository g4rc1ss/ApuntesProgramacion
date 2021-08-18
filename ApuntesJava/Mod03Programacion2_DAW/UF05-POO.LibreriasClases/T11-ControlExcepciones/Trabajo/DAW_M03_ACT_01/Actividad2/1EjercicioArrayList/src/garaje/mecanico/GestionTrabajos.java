package garaje.mecanico;

import garaje.mecanico.enums.*;

import java.util.ArrayList;

/*
 * FUNCIONALIDADES PARA TRATAR LOS TRABAJOS Y LOS ARRAYLIST
 */
public class GestionTrabajos {
    private ArrayList<Trabajo> listaTrabajos = new ArrayList();

    // Calculo total de precio por horas
    private double precioTotal(Trabajo trabajo) {
        double precioTotalHoras = trabajo.getNumHoras() * 30;
        if (trabajo.getTipoTrabajo() == TipoTrabajo.reparacionMecanica)
            return (precioTotalHoras + (trabajo.getPrecioMaterial() * 1.1));
        else if (trabajo.getTipoTrabajo() == TipoTrabajo.reparacionChapaPintura)
            return precioTotalHoras + (trabajo.getPrecioMaterial() * 1.3);
        else if (trabajo.getTipoTrabajo() == TipoTrabajo.revision)
            return precioTotalHoras + 20;
        return 0;
    }

    public int registrarTrabajo(TipoTrabajo tipoTrabajo, String descripcion) {
        Trabajo trabajo = new Trabajo(
                listaTrabajos.size(),
                descripcion,
                0,
                Estado.recibida_comenzada,
                tipoTrabajo,
                0
        );
        listaTrabajos.add(trabajo);
        return trabajo.getIdTrabajo();
    }

    public boolean aumentarHoras(int idTrabajo, double numHorasSumar) {
        try {
            Trabajo trabajoObtenido = listaTrabajos.get(idTrabajo);
            if (trabajoObtenido.getEstadoReparacion() != Estado.finalizada) {
                trabajoObtenido.setNumHoras(trabajoObtenido.getNumHoras() + numHorasSumar);
                return true;
            }
        } catch (Exception ex) {
            System.out.println("Se ha introducido mal el id del trabajo");
            return false;
        }
        return false;
    }

    public boolean aumentarCostePiezas(int idTrabajo, double costePiezasSumar) {
        try {
            Trabajo trabajoObtenido = listaTrabajos.get(idTrabajo);
            if (trabajoObtenido.getEstadoReparacion() != Estado.finalizada) {
                trabajoObtenido.setPrecioMaterial(trabajoObtenido.getPrecioMaterial() + costePiezasSumar);
                return true;
            }
        } catch (Exception ex) {
            System.out.println("Se ha introducido mal el id del trabajo");
            return false;
        }
        return false;
    }

    public void finalizarTrabajo(int idTrabajo) {
        try {
            Trabajo trabajoObtenido = listaTrabajos.get(idTrabajo);
            trabajoObtenido.setEstadoReparacion(Estado.finalizada);
        } catch (Exception ex) {
            System.out.println("Se ha introducido mal el id del trabajo");
        }
    }

    public String mostrarTrabajo(int idTrabajo) {
        try {
            Trabajo trabajoObtenido = listaTrabajos.get(idTrabajo);
            return ("Identificador del trabajo " + trabajoObtenido.getIdTrabajo() + "\n" +
                    "Descripcion del trabajo " + trabajoObtenido.getDescripcion() + "\n" +
                    "Precio del trabajo " + precioTotal(trabajoObtenido) + "€ \n"
            );
        } catch (Exception ex) {
            System.out.println("Se ha introducido mal el id del trabajo");
            return null;
        }
    }
}
