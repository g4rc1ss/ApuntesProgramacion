package Ejercicios;

public class MainEjerVectores {

	public static void main(String[] args) {
		float rdo;
		
		EjerVectores vec=new EjerVectores();

	vec.teclear();
	
	rdo=vec.calcularPromedio();
	
	vec.visualizar(rdo);
		
	vec.mayorMenor(rdo);
	}

}
