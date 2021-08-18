/*Restar 2 números tipo float.
Los números no se teclean, sino que se inicializan las variables.
Métodos:
restar()para realizar la resta
visualizar() para visualizar el resultado.
*/
public class EjerMetod1 {

	float n1=3.5F;
	float n2=1.5F;
	float resultado;
	
void restar(){
	resultado=n1-n2;
	
}
void visualizar(){
	System.out.println(resultado);
}
	
	
	
	public static void main(String[] args) {
		
		EjerMetod1 E=new EjerMetod1();
		E.restar();
		E.visualizar();

		
		
		
		
	}

}
