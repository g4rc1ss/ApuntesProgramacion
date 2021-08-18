public class Pajaro {
	
	private static int numPajaros=0; //lo pone en cursiva
	private final char color;
	private final int edad;

	public Pajaro() {
		color='v';
		edad=0;
		numeroPajaros();
	}
	public Pajaro(char c, int e){
		color=c;
		edad=e;
		numeroPajaros();
	}
   public static void numeroPajaros(){
	numPajaros++;
}
	


   static void visualizar(){
	System.out.println("Número de pajaros: "+numPajaros);
}
	public static void main(String[] args) {
		Pajaro paj1, paj2;
		paj1=new Pajaro();
		paj2=new Pajaro('b',6);
		Pajaro.visualizar();                       

	}

}
