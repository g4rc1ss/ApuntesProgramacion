package coches.facturacion;
public class Coche {

			//Atributos de instancia
	
		String matricula, marca, modelo;
		float precioBase;
	
			//Constructores
	
		Coche(){
			
		}
		Coche(String matricula, String marca,String modelo,float precioBase){
			this.matricula=matricula;
			this.marca=marca;
			this.modelo=modelo;
			this.precioBase=precioBase;
		}
		Coche(float precioBase){
			
		}
		
			//Getters y Setters
			
		public String getMatricula() {
			return matricula;
		}
		public void setMatricula(String matricula) {
			this.matricula = matricula;
		}
		public String getMarca() {
			return marca;
		}
		public void setMarca(String marca) {
			this.marca = marca;
		}
		public String getModelo() {
			return modelo;
		}
		public void setModelo(String modelo) {
			this.modelo = modelo;
		}
		public float getPrecioBase() {
			return precioBase;
		}
		public void setPrecioBase(float precioBase) {
			this.precioBase = precioBase;
		}
	
			//Metodo
	
		float precioColor(String color){
			
			float importe;
			
			switch(color){
				
				case "blanco":
				
						importe=precioBase;
					
					break;
				
				case "rojo": case "verde": case "azul":
					
						importe=precioBase*1.05F;
					
					break;
				
				case "marron": case "naranja":
					
						importe=precioBase*1.10F;
						
					break;
					
				default:
					
						importe=precioBase*1.15F;
			}
			
			return importe;
		}
	
	
		void Visualizar(float importe){
			
			System.out.println("El precio del coche es: "+importe);
		}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
