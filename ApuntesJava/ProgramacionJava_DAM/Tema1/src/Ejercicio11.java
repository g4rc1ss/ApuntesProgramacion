
public class Ejercicio11 {
    public static void main(String[] args) {
		/*11.-Asignar a una variable un peso en Kg (con decimales) visualizar el coste en � de ese peso en oro. 
		Teniendo en cuenta que el precio del oro son 400$  la onza,   1kg=32,15 onzas, buscar en Internet la equivalencia del dolar en euros.
		Realizar el ejercicio utilizando constantes donde corresponda.*/


        double Kg = 5.5;
        double onzas = Kg * 32.15;
        double euros=onzas * 400;
        double $ =euros*1.11667;

        System.out.println(Kg + "Kg de oro cuestan " +euros + "euros, lo que seran " + $ + " dolares estadounidenses.");
    }
}
