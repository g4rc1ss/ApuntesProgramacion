package garaje.mecanico;

import garaje.mecanico.enums.*;
import garaje.mecanico.herencias.ReparacionChapaPintura;
import garaje.mecanico.herencias.ReparacionMecanica;
import garaje.mecanico.herencias.Revision;
import garaje.mecanico.herencias.padre.Trabajo;

import java.util.ArrayList;

/*
 * FUNCIONALIDADES PARA TRATAR LOS TRABAJOS Y LOS ARRAYLIST
 */
public class GestionTrabajos {
    private ArrayList listaTrabajos = new ArrayList();


    public int registrarTrabajo(Object tipoTrabajo, String descripcion) {
        if (tipoTrabajo instanceof Revision) {
            ((Revision) tipoTrabajo).setDescripcion(descripcion);
            ((Revision) tipoTrabajo).setIdTrabajo(listaTrabajos.size());
            listaTrabajos.add(tipoTrabajo);
            return ((Revision) tipoTrabajo).getIdTrabajo();
        } else if (tipoTrabajo instanceof ReparacionMecanica) {
            ((ReparacionMecanica) tipoTrabajo).setDescripcion(descripcion);
            ((ReparacionMecanica) tipoTrabajo).setIdTrabajo(listaTrabajos.size());
            listaTrabajos.add(tipoTrabajo);
            return ((ReparacionMecanica) tipoTrabajo).getIdTrabajo();
        } else if (tipoTrabajo instanceof ReparacionChapaPintura) {
            ((ReparacionChapaPintura) tipoTrabajo).setDescripcion(descripcion);
            ((ReparacionChapaPintura) tipoTrabajo).setIdTrabajo(listaTrabajos.size());
            listaTrabajos.add(tipoTrabajo);
            return ((ReparacionChapaPintura) tipoTrabajo).getIdTrabajo();
        }
        return -1;
    }

    public boolean aumentarHoras(int idTrabajo, double numHorasSumar) {
        try {
            Trabajo trabajoObtenido = (Trabajo) listaTrabajos.get(idTrabajo);
            if (trabajoObtenido.getEstadoReparacion() != Estado.finalizada) {
                trabajoObtenido.setNumHoras(trabajoObtenido.getNumHoras() + numHorasSumar);
                return true;
            }
        } catch (Exception ex) {
            System.out.println("Se ha introducido mal el id del trabajo");
            return true;
        }
        return false;
    }

    public boolean aumentarCostePiezas(int idTrabajo, double costePiezasSumar) {
        try {
            Trabajo trabajoObtenido = (Trabajo) listaTrabajos.get(idTrabajo);
            if (trabajoObtenido.getEstadoReparacion() != Estado.finalizada) {
                trabajoObtenido.setPrecioMaterial(trabajoObtenido.getPrecioMaterial() + costePiezasSumar);
                return true;
            }
        } catch (Exception ex) {
            System.out.println("Se ha introducido mal el id del trabajo");
            return true;
        }
        return false;
    }

    public void finalizarTrabajo(int idTrabajo) {
        try {
            Trabajo trabajoObtenido = (Trabajo) listaTrabajos.get(idTrabajo);
            trabajoObtenido.setEstadoReparacion(Estado.finalizada);
        } catch (Exception ex) {
            System.out.println("Se ha introducido mal el id del trabajo");
        }
    }

    public String mostrarTrabajo(int idTrabajo) {
        try {
            Object trabajoObtenido = listaTrabajos.get(idTrabajo);
            if (trabajoObtenido instanceof Revision) {
                return ("Identificador del trabajo " + ((Revision)trabajoObtenido).getIdTrabajo() + "\n" +
                        "Descripcion del trabajo " + ((Revision)trabajoObtenido).getDescripcion() + "\n" +
                        "Precio del trabajo " + ((Revision)trabajoObtenido).calcularPrecioTotal() + "€ \n");

            } else if (trabajoObtenido instanceof ReparacionMecanica) {
                return ("Identificador del trabajo " + ((ReparacionMecanica)trabajoObtenido).getIdTrabajo() + "\n" +
                        "Descripcion del trabajo " + ((ReparacionMecanica)trabajoObtenido).getDescripcion() + "\n" +
                        "Precio del trabajo " + ((ReparacionMecanica)trabajoObtenido).calcularPrecioTotal() + "€ \n");

            } else if (trabajoObtenido instanceof ReparacionChapaPintura) {
                return ("Identificador del trabajo " + ((ReparacionChapaPintura)trabajoObtenido).getIdTrabajo() + "\n" +
                        "Descripcion del trabajo " + ((ReparacionChapaPintura)trabajoObtenido).getDescripcion() + "\n" +
                        "Precio del trabajo " + ((ReparacionChapaPintura)trabajoObtenido).calcularPrecioTotal() + "€ \n");
            }
        } catch (Exception ex) {
            System.out.println("Se ha introducido mal el id del trabajo");
            return null;
        }
        return null;
    }
}
