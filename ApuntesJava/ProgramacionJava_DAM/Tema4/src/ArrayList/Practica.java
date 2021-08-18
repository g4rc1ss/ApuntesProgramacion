package ArrayList;

/*
1-Crear 3 ArrayList {Enteros, Float y String}

2-Introducir datos

3-Recorrer con {for, foreach e Interactor}-
*/
import java.util.ArrayList;
import java.util.Iterator;

public class Practica {

	
	ArrayList<Integer> Enteros = new ArrayList<Integer>(); 
	ArrayList<Float> Floats=new ArrayList<Float>(); 
	ArrayList<String> Strings=new ArrayList<String>(); 

	void datos(){
		
		//Enteros
		Enteros.add(45);
		Enteros.add(78);
		Enteros.add(12);
		
		//Floats
		Floats.add(4.5F);
		Floats.add(7.8F);
		Floats.add(1.2F);
		
		//Strings
		Strings.add("Cuarenta y cinco");
		Strings.add("Setenta y ocho");
		Strings.add("Doce");
		}
        
		void visualizar(){
			
                    for(int i = 0;i<Enteros.size();i++){
                        System.out.println(Enteros.get(i));
                    }
			
                    for(Float i: Floats){
                        System.out.println(i);
                    }

			
                    Iterator it = Strings.iterator(); 
                        while(it.hasNext())
                        System.out.print(it.next()+"     "); 
                }

	public static void main(String[] args) {
		
            Practica obj = new Practica();
            obj.datos();
            obj.visualizar();
		
	}

}
