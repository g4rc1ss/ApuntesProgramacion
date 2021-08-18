package practicar;

public class Practica1 {
	
	
	
	void metodo(){
		System.out.println("El valor absoluto del numero es: "+Math.abs(-8));
		System.out.println("La raiz cuadrade del numero es: "+Math.sqrt(4));
		System.out.println(Math.ceil(4.232322));
		System.out.println(Math.floor(4.232322));
		System.out.println(Math.pow(2,4));
		System.out.println(Math.PI);
		System.out.println(Math.E);
		System.out.println(Math.random());
		System.out.println((byte)(Math.random()*2));
	}
	
	
	
	
	
	public static void main(String[] args) {
		
		Practica1 prac=new Practica1();
		
		prac.metodo();

	}

}
