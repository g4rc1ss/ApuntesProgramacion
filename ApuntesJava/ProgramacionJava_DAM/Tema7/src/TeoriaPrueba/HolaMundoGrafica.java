package TeoriaPrueba;

import javax.swing.JFrame; //La clase JFrame encapsula el concepto de una ventana
import javax.swing.JLabel; //La clase JLabel  tiene por objetivo mostrar un texto dentro de un JFrame.

public class HolaMundoGrafica extends JFrame { /*Para que la clase muestre  una ventana debe
                                                heredar de la clase JFrame:*/
    private final JLabel label1;  //Definimos  un objeto de la clase JLabel:

    public HolaMundoGrafica() {
        setLayout(null); /*m�todo heredado de la clase JFrame con el par�metro null,
                           significa que utilizaremos posicionamiento absoluto    
                           para los controles visuales dentros del JFrame.*/
        label1 = new JLabel("Hola Mundo."); //crear el objeto de la clase JLabel con el texto a mostrar
        label1.setBounds(20, 10, 200, 300); //Ubicamos y damos tama�o(p�xeles) al texto: columna, fila, ancho, alto
        add(label1); //metodo heredado de  JFrame que  a�ade el control JLabel al control JFrame.
//JFrame contiene una barra de menu y un Content Pane (panel) accesible a trav�s del m�todo getContentPane()
//Para a�adir nuestra etiqueta a JFrame habr�a que escribir: getContentPane().add(label1), es suficiente con //add(label1)
//getContentPane().setBackground(Color.blue);
    }

    public static void main(String[] ar) {
        HolaMundoGrafica grafica1 = new HolaMundoGrafica();
        grafica1.setBounds(10, 10, 400, 400); //Ubicamos y damos tama�o a la ventana: columna, fila, ancho, alto
        grafica1.setVisible(true); // Se hace visible el Jframe
        grafica1.setResizable(false); /*el operador no puede modificar el tama�o de la ventana*/

        grafica1.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //para que cuando cerremos la ventana no siga ejecutandose el
        //programa
    }

}
