import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class InterfazGrafica extends JFrame implements ActionListener {

    //Paneles
    private JPanel panelPrincipal;
    private JPanel panelSeleccion;
    private JPanel panelEncendido;
    private JPanel panelComprobacion;


    //Objetos del panel principal
    private JButton seleccionFarolas;
    private JButton encendidoFarolas;
    private JButton comprobacionFarolas;

    //Objetos del panel de seleccion
    private JButton aceptar;
    private JButton atrasSeleccion;
    private JButton aceptarAviso;//Este boton es usado cuando para un aviso que sale cuando pones un numero superior a 14

    private JTextField[] maximoSeleccion = new JTextField[5];//A?adimos un JTextField para que se teclee el numero maximo de farolas que se encienden
    private JLabel[] calles = new JLabel[5];
    private JFrame aviso; //A?adimos un Frame nuevo para un aviso de errores

    //Objetos del panel de Encendido

    private JButton[][] botonEncendidoFarolas = new JButton[5][14];
    private int xBotonEncendidoFarolas = 5;
    private int yBotonEncendidoFarolas = 14;
    private boolean[][] botonEncendidoFarolasComprobar = new boolean[5][14];
    private JButton atrasEncendido;
    private JLabel[] callesEncendido = new JLabel[5];
    private JLabel[] izquierdaDerecha = new JLabel[2];
    private byte contadorComprobacionCreacionBoolean = 0;

    //Objetos del panel de Comprobacion

    private JButton atrasComprobacion;
    private JComboBox seleccionDeCalles;
    private JButton botonResultadoSeleccionCalles;
    private JTextArea resultadoMostradoConsulta;
    private String[] meterDatos = {"Calle 1", "Calle 2", "Calle 3", "Calle 4", "Calle 5"};

    //Variables Normales
    private int[] nFarolasEncendidas = new int[5]; // Se usara como informacion del segundo boton
    private int[] nFarolasSeleccionadas = new int[5]; // Se usara como informacion del primer boton
    private int nFarolasEncendidasTotales = 0;
    private int comprobarNFarSeleccionadas = 0;

    //Este constructor se usa como el JFrame del programa
    public InterfazGrafica() {

        setBounds(0, 0, 1278, 700);
        setVisible(true);
        setResizable(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle("Programa de gestion de Farolas");

    }

    //Ahora vamos a usar metodos para los diferentes JPanel que hay

    //En este metodo vamos a crear el panel principal del programa (lo primero que aparece)
    public void panelPrincipal() {

        //Con el siguiente codigo realizamos la creacion del panel, instanciadolo, a?adiendo las medidas
        //necesarias, a?adiendo color de fondo...
        panelPrincipal = new JPanel();
        panelPrincipal.setLayout(null);
        panelPrincipal.setBounds(0, 0, 1278, 700);
        panelPrincipal.setBackground(Color.DARK_GRAY);
        add(panelPrincipal);
        panelPrincipal.setVisible(true);

        //Titulo del panel
        JLabel farolas = new JLabel("Encendido y apagado de Farolas");
        farolas.setBounds(450, 10, 600, 50);
        farolas.setForeground(Color.white);
        farolas.setFont(new Font("tahoma", Font.PLAIN, 36));
        panelPrincipal.add(farolas);

        //Boton numero 1 del panel
        seleccionFarolas = new JButton(" Seleccion de Farolas");
        seleccionFarolas.setBounds(140, 100, 300, 500);
        seleccionFarolas.setBackground(Color.WHITE);
        panelPrincipal.add(seleccionFarolas);
        seleccionFarolas.addActionListener(this);

        //Boton numero 2 del panel
        encendidoFarolas = new JButton("Encendido de Farolas");
        encendidoFarolas.setBounds(450, 100, 300, 500);
        encendidoFarolas.setBackground(Color.WHITE);
        panelPrincipal.add(encendidoFarolas);
        encendidoFarolas.addActionListener(this);

        //Boton numero 3 del panel
        comprobacionFarolas = new JButton("Realizar Consultas");
        comprobacionFarolas.setBounds(770, 100, 300, 500);
        comprobacionFarolas.setBackground(Color.WHITE);
        panelPrincipal.add(comprobacionFarolas);
        comprobacionFarolas.addActionListener(this);

    }

    ////////////////////////////////////////////PANEL DE SELECCION\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void panelBotonSeleccion() {

        //Hacemos desaparecer el panel principal para poder acceder a otros paneles
        panelPrincipal.setVisible(false);

        //creamos el nuevo panel
        panelSeleccion = new JPanel();
        panelSeleccion.setLayout(null);
        panelSeleccion.setBounds(0, 0, 1278, 700);
        panelSeleccion.setBackground(Color.DARK_GRAY);
        add(panelSeleccion);
        panelSeleccion.setVisible(true);

        //Creacion de Elementos Dentro del panel creado anteriormente

        //Creamos un boton para guardar los cambios de las farolas seleccionadas
        aceptar = new JButton("Guardar Cambios de configuracion");
        aceptar.setBounds(0, 500, 1278, 150);
        aceptar.setBackground(Color.WHITE);
        panelSeleccion.add(aceptar);
        aceptar.addActionListener(this);//gestionamos el textfiel etc

        //Creamos un boton para volver al panel principal
        atrasSeleccion = new JButton("Volver al Menu principal");
        atrasSeleccion.setBounds(0, 0, 1278, 100);
        atrasSeleccion.setBackground(Color.WHITE);
        panelSeleccion.add(atrasSeleccion);
        atrasSeleccion.addActionListener(this);//simplemente volvemos al menu principal

        //A?adimos un JLabel para indicar que tiene que insertar en el JTextField :))
        JLabel indicacionTextFieldSeleccion = new JLabel("Introduce el numero maximo de farolas que se pueden encender");
        indicacionTextFieldSeleccion.setForeground(Color.white);
        indicacionTextFieldSeleccion.setFont(new Font("tahoma", Font.PLAIN, 18));
        indicacionTextFieldSeleccion.setBounds(400, 150, 550, 50);
        panelSeleccion.add(indicacionTextFieldSeleccion);

        //Creamos un array de JLabel para poner calle 1, calle 2...
        int filaLabel = 210;//para las coordenadas
        int calle = 1;//para el nombre
        for (int x = 0; x < calles.length; x++) {
            calles[x] = new JLabel("Calle " + (calle));
            calles[x].setBounds(500, filaLabel, 50, 30);
            calles[x].setForeground(Color.white);
            panelSeleccion.add(calles[x]);
            filaLabel += 50;
            calle++;
        }

        //Variables para coordenadas
        //int y = 210;
        int fila = 210;
        for (int z = 0; z < maximoSeleccion.length; z++) {
            maximoSeleccion[z] = new JTextField();
            maximoSeleccion[z].setBounds(620, fila, 65, 30);
            panelSeleccion.add(maximoSeleccion[z]);
            fila += 50;
        }

    }

    //////////////////////////////////////PANEL DE ENCENDIDO\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void panelBotonEncendido() {

        //Hacemos desaparecer el panel principal para poder acceder a otros paneles
        panelPrincipal.setVisible(false);

        //creamos el nuevo panel
        panelEncendido = new JPanel();
        panelEncendido.setLayout(null);
        panelEncendido.setBounds(0, 0, 1278, 700);
        panelEncendido.setBackground(Color.DARK_GRAY);
        add(panelEncendido);
        panelEncendido.setVisible(true);

        //Creamos los objetos del botones

        //Con estos for vamos a crear un array BIDIMENSIONAL de botones para poder interactuar con ellos
        int columnaYFarolas = 180;//se usara para las coordenadas de las columnas
        int filaXFarolas = 150;//se usara para las coordenadas de las filas
        for (int x = 0; x < xBotonEncendidoFarolas; x++) {//Este for se encarga de la creacion de las filas de la matriz que son 5
            for (int y = 0; y < yBotonEncendidoFarolas; y++) {//Este for se encarga de la creacion de las columnas de la matriz que son 14

                setLayout(null);//posicionamos nosotros donde nos da la gana
                botonEncendidoFarolas[x][y] = new JButton("?");//creamos el objeto
                botonEncendidoFarolas[x][y].setBounds(columnaYFarolas, filaXFarolas, 60, 45);//posicionamos mediante variables
                panelEncendido.add(botonEncendidoFarolas[x][y]);//a?adimos al panel los 70 botones
                botonEncendidoFarolas[x][y].addActionListener(this);//indicamos donde tienen que dirigirse para realizar los eventos
                botonEncendidoFarolas[x][y].setBackground(Color.WHITE);//indicamos el color de fondo del boton en blanco
                columnaYFarolas += 70;//sumamos 70 px de distancia en columna por cada boton(la separacion a lo ancho de un boton con otro)

                if (contadorComprobacionCreacionBoolean == 0) { //Se utiliza para que solo inicialice los boolean a false una vez en to-do el programa

                    botonEncendidoFarolasComprobar[x][y] = false;//creamos un array bidimensional para cada boton de tipo boolean para saber
                    //si la farola esta encendida o no
                    contadorComprobacionCreacionBoolean++;//rompemos la condicion para no poder volver a entrar
                }
                if (botonEncendidoFarolasComprobar[x][y])//Si la farola esta encendida me la pones en amarillo
                    botonEncendidoFarolas[x][y].setBackground(Color.yellow);

                if (y == 6)//condicion para que cuando genere 7 botones:
                    columnaYFarolas += 20;//realiza una suma de 20 pixeles de distancia, de esta forma separamos Farolas Izquierda y Farolas Derecha

                if (y == 13) {//realizamos una condicion indicando que cuando y(Columna) llegue a la posicion 13 del array haga lo siguiente

                    filaXFarolas += 90; //sume una distancia de 90 px a la fila siguiente(la distancia con los botones de abajo suyo)
                    columnaYFarolas = 180;//ponga el posicionamiento de los botones a 180 px respecto del marco
                }
            }
        }
        int calle = 1;//uilizamos la variable para el texto del JLabel
        int calleFila = 150;//Se usara para ir sumando las coordenadas
        for (int x = 0; x < callesEncendido.length; x++) {//con este for se crearan los JLabel

            callesEncendido[x] = new JLabel("Calle " + calle);//se crean los objetos
            callesEncendido[x].setBounds(100, calleFila, 65, 30);//Se a?ade el posicionamiento donde van a ir los Labels
            callesEncendido[x].setForeground(Color.WHITE);//Color del texto Blanco
            panelEncendido.add(callesEncendido[x]);//a?adimos los JPanel al Panel
            calleFila += 95;//sumamos las coodenadas de filas
            calle++;//sumamos uno para indicar calle 1, calle 2...5
        }
        //abajo es la creacion de un array de JLabel que indican cuales son las farolas de la derecha y de la izquierda
        String indicacion = "Izquierda";//String por el array de JLabel
        int columna = 380;
        for (int x = 0; x < izquierdaDerecha.length; x++) {

            izquierdaDerecha[x] = new JLabel(indicacion);
            izquierdaDerecha[x].setBounds(columna, 100, 200, 30);
            izquierdaDerecha[x].setFont(new Font("tahoma", Font.PLAIN, 25));
            izquierdaDerecha[x].setForeground(Color.WHITE);
            panelEncendido.add(izquierdaDerecha[x]);
            columna += 450;
            indicacion = "Derecha";
        }

        //Creamos un boton para volver al menu principal
        atrasEncendido = new JButton("Volver al Menu principal");
        atrasEncendido.setBounds(0, 0, 1278, 80);
        atrasEncendido.setBackground(Color.WHITE);
        panelEncendido.add(atrasEncendido);
        atrasEncendido.addActionListener(this);//simplemente volvemos al menu principal

        //Comprobar que haya farolas seleccionadas
        for (int var : nFarolasSeleccionadas)
            comprobarNFarSeleccionadas += var;

        if (comprobarNFarSeleccionadas == 0)
            //creamos un array de farolasEncendidas para mas adelante realizar una comparacion con las seleccionadas
            for (int x = 0; x < nFarolasEncendidas.length; x++)
                nFarolasEncendidas[x] = 0;
    }

    /////////////////////////////////////////////PANEL DE COMPROBACION \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void panelBotonComprobacion() {

        //Hacemos desaparecer el panel principal para poder acceder a otros paneles
        panelPrincipal.setVisible(false);

        //creamos el nuevo panel
        panelComprobacion = new JPanel();
        panelComprobacion.setLayout(null);
        panelComprobacion.setBounds(0, 0, 1278, 700);
        panelComprobacion.setBackground(Color.DARK_GRAY);
        add(panelComprobacion);
        panelComprobacion.setVisible(true);

        //Creamos un boton para volver al menu principal
        atrasComprobacion = new JButton("Volver al Menu principal");
        atrasComprobacion.setBounds(0, 0, 1278, 80);
        atrasComprobacion.setBackground(Color.WHITE);
        panelComprobacion.add(atrasComprobacion);
        atrasComprobacion.addActionListener(this);//simplemente volvemos al menu principal

        //Creamos un ComboBox de las calles para comprobar las farolas
        seleccionDeCalles = new JComboBox();
        seleccionDeCalles.setBounds(350, 250, 500, 40);
        panelComprobacion.add(seleccionDeCalles);
        for (String meterDato : meterDatos)
            seleccionDeCalles.addItem(meterDato);

        //Creamos un JButton para realizar la comprobacion
        botonResultadoSeleccionCalles = new JButton("Comprobar");
        botonResultadoSeleccionCalles.setBounds(350, 500, 500, 60);
        panelComprobacion.add(botonResultadoSeleccionCalles);
        botonResultadoSeleccionCalles.addActionListener(this);

        //Creamos un JLabel para poner la indicacion de que se debe de hacer
        JLabel indicacionCallesSeleccion = new JLabel("Selecciona una calle para obtener la informacion");
        indicacionCallesSeleccion.setBounds(350, 150, 600, 30);
        indicacionCallesSeleccion.setForeground(Color.WHITE);
        indicacionCallesSeleccion.setFont(new Font("courier new", Font.PLAIN, 18));
        panelComprobacion.add(indicacionCallesSeleccion);

        //Creamos un JTextArea para devolver el resultado de la consulta
        resultadoMostradoConsulta = new JTextArea();
        JScrollPane scrollResultadoMostradoConsulta = new JScrollPane(resultadoMostradoConsulta);
        resultadoMostradoConsulta.setLineWrap(true);
        scrollResultadoMostradoConsulta.setBounds(350, 300, 500, 190);
        panelComprobacion.add(scrollResultadoMostradoConsulta);
    }

    ///////////////////////////////////Gestionamos los eventos\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    //______________________________________________________________________________________\\
    @Override
    public void actionPerformed(ActionEvent e) {

        ////////////////////Los enventos del panelPrincipal\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        if (e.getSource() == seleccionFarolas)
            panelBotonSeleccion();//llamamos al metodo de seleccion

        else if (e.getSource() == encendidoFarolas)
            panelBotonEncendido();//llamamos al metodo de encendido de farolas

        else if (e.getSource() == comprobacionFarolas)
            panelBotonComprobacion();//llamamos al metodo de comprobacion de farolas

            /////////////////////////eventos del panelBotonSeleccion\\\\\\\\\\\\\\\\\\\\\
        else if (e.getSource() == atrasSeleccion) {//volvemos al menu principal
            panelPrincipal.setVisible(true);
            panelSeleccion.setVisible(false);
        }
        //Este if se encarga de guardar los cambios de las farolas maximas a encender
        else if (e.getSource() == aceptar) {
            int nFarolasSeleccionadasTotales;
            boolean comprobarAviso = false; // Este boolean se usa para el aviso del JFrame, como esta en un for se consigue que solo salga un JFrame, no varios
            String[] maximo = new String[5];//El String que va a coger el dato del JTextField

            //Este for se encarga de la conversion del String a int y a?adirlos en el array nFarolasSeleccionadas[]
            for (int x = 0; x < nFarolasSeleccionadas.length; x++) {
                maximo[x] = maximoSeleccion[x].getText();
                if (maximo[x].equals("")) {//Se usa para que no de error cuando los TextField se queden vacios, los sustituira
                    nFarolasSeleccionadas[x] = 0;
                } else {
                    nFarolasSeleccionadas[x] = Integer.parseInt(maximo[x]);
                }
            }

            //Este for se encarga de realizar una comprobacion del maximo de farolas que se pueden seleccionar, si se selecciona mas de 14 aparecera
            //un aviso se?alando que se han de a?adir menos numeros
            for (int nFarolasSeleccionada : nFarolasSeleccionadas) {
                //Con este if se comprueba que el numero que se selecciona de farolas sea menos de 14
                if (nFarolasSeleccionada <= 14) {
                    nFarolasSeleccionadasTotales = 0;//Esta variable se usa para guardar el resultado de la suma de todas las farolas seleccionadas en el array
                    for (int farolasSeleccionada : nFarolasSeleccionadas) //Este for es para realizar la suma
                        nFarolasSeleccionadasTotales += farolasSeleccionada;//suma del contenido del array de la seleccion de farolas
                    //aqui se a?ade otro titulo al JButton para que cuando se guarden los cambios del numero de farolas aparezca cual es el maximo de estas seleccionadas
                    seleccionFarolas.setText(nFarolasSeleccionadasTotales + " Faloras totales a encender");
                }
                //Se utiliza un else if por la condicion, indicando que si se agrega un numero mayor a 7 y el boolean esta en false, se entrara
                else if (!comprobarAviso) {
                    aviso = new JFrame();
                    aviso.setLayout(null);
                    aviso.setBounds(400, 300, 320, 300);
                    aviso.setVisible(true);
                    setDefaultCloseOperation(EXIT_ON_CLOSE);

                    JLabel avisoLabel = new JLabel("Has a?adido un dato mayor a 14");
                    avisoLabel.setBounds(40, 25, 250, 25);
                    aviso.add(avisoLabel);

                    aceptarAviso = new JButton("Aceptar");
                    aceptarAviso.setBounds(40, 60, 250, 25);
                    aviso.add(aceptarAviso);
                    aceptarAviso.addActionListener(this);
                    comprobarAviso = true;//rompemos el bucle para que solo aparezca un JFrame
                }
            }
            //Este if se usa para saber mediante el boolean de comprobarAviso, cuando se debe de cambiar el JPanel...
            //si aparece el aviso no se cambiara de panel y si no aparece se cambiara
            if (comprobarAviso) {
                panelPrincipal.setVisible(false);//cambiamos de paneles
                panelSeleccion.setVisible(true);
            } else {
                panelPrincipal.setVisible(true);//cambiamos de paneles
                panelSeleccion.setVisible(false);
            }
        }//Fin de getSource()

        else if (e.getSource() == aceptarAviso)//Para el boton del aviso del JFrame
            aviso.dispose();//Se utiliza para cerrar la ventana del aviso

        /////////////////////////////////////////// Eventos del panelEncendido \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        boolean romperBucleEncendidoFarolas = false;

        try {//para coger las excepciones
            //si x es menor que el tama?o del array entrara al bucle, se usa para que cuando haya leido todas los datos pues salga de el
            for (int x = 0; x < 5 && !romperBucleEncendidoFarolas; x++) {
                //aqui se leen los datos del array con el bucle para poner el maximo de farolas que se pueden encender
                for (int y = 0; y < 14 && !romperBucleEncendidoFarolas; y++) {
                    //generamos un tercer for para gestionar un tercer array, el de seleccion porque si hubiese dos for, la seleccion hecha activaria un numero de posiciones en y
                    for (int z = 0; z < nFarolasSeleccionadas[x] && !romperBucleEncendidoFarolas; z++) {
                        if (e.getSource() == botonEncendidoFarolas[x][y]) {//compara si el boton pulsado esta dentro
                            //compara con la boolean del boton pulsado si esta la farola apagada y si el numero de farolas que se van encendiendo es menor al maximo seleccionadas
                            if (!botonEncendidoFarolasComprobar[x][y] && nFarolasEncendidas[x] < nFarolasSeleccionadas[x]) {
                                botonEncendidoFarolas[x][y].setBackground(Color.yellow);//enciende la farola
                                botonEncendidoFarolasComprobar[x][y] = true;//indica que la farola esta encendida
                                nFarolasEncendidas[x]++;//array en el que con cada vuelta de x se indica cuantas se van encendiendo
                                nFarolasEncendidasTotales++;//Este se usara para el titulo del boton de encendido
                                y = 14;//rompemos y para que no siga sumando indices
                                romperBucleEncendidoFarolas = true;//rompemos bucle porque ya ha encontrado el boton pulsado, no tiene que seguir dando vueltas
                            } else if (botonEncendidoFarolasComprobar[x][y]) {//cuando se vuelva a pulsar el boton de la farola, esta estara encendida, por tanto si se pulsa es para apagarla
                                botonEncendidoFarolas[x][y].setBackground(Color.white);//apagamos la farola
                                botonEncendidoFarolasComprobar[x][y] = false;//indicamos que la farola esta apagada
                                nFarolasEncendidas[x]--;// quitamos una farola encendida del array, puesto que la estamos apagando
                                nFarolasEncendidasTotales--;//quitamos una del contador del titulo del boton
                                romperBucleEncendidoFarolas = true;//rompemos bucle
                            }//fin de Else if

                            if (nFarolasEncendidasTotales == 1)//si solo hay una farola encendida, queda mas bonito este texto que esta en singular
                                encendidoFarolas.setText(nFarolasEncendidasTotales + " Farola encendida");
                            else if (nFarolasEncendidasTotales > 1) //si hay mas de una farola encendida hablamos en plural
                                encendidoFarolas.setText(nFarolasEncendidasTotales + " Farolas encendidas");
                            else if (nFarolasEncendidasTotales == 0)// si no hay ninguna farola encendida dejamos el titulo como estaba
                                encendidoFarolas.setText("Encendido y apagado de Farolas");
                        }// fin de e.getSource == botonEncendidoFarolas[x][y]
                    }//fin for z
                }//fin de for y
            }//fin de for x
        } catch (Exception excepcion) {
            excepcion.printStackTrace();
        }

        if (e.getSource() == atrasEncendido) {//boton de atras para ir al menu pincipal
            panelPrincipal.setVisible(true);
            panelEncendido.setVisible(false);
        }

        /////////////////////////////////Eventos del panelComprobacion\\\\\\\\\\\\\\\\\\\\\\\\\\

        else if (e.getSource() == atrasComprobacion) {//boton para volver al menu principal
            panelPrincipal.setVisible(true);
            panelComprobacion.setVisible(false);
        } else if (e.getSource() == botonResultadoSeleccionCalles) {// el boton de comprobar del panel de comprobacion

            String calles = (String) seleccionDeCalles.getSelectedItem();//creamos esta variable local para obtener el item seleccionado del ComboBox y asi gestionarlo
            boolean romperBucleComprobar = false;// se va a usar para romper bucle, una vez realizada la instruccion necesaria no tiene que dar vueltas a lo tonto
            resultadoMostradoConsulta.setText("");//Limpiamos el texto del comboBox
            byte numeroFarolasNoEncendidas = 0;//contado para el numero de farolas no encendidas se usara para cuando se vaya a comprobar una calle que no esta encendida de un mensaje indicandolo
            byte nFarolasIzquierdaEncendidas = 0;//numero de farolas encendidas a la izquierda de la calle
            byte nFarolasDerechaEncendidas = 0;//numero de farolas encendidas a la derecha de la calle
            byte titulo = 0;//se usara como un boolean pero con numeros, cuando sea 1 no entrara mas... se usara para poner una vez un "titulo"
            byte yTemporalPar = 0;
            byte yTemporalImpar = 1;
            byte tituloVisibilidad = 0;
            boolean romperBucle = false;
            byte contadorTruePar = 0;
            byte contadorTrueImpar = 0;
            boolean mostrarRegularNo = true;

            //realizamos los dos for para la gestion del array bidimensional booleano que indica si las farolas estan o no encendidas
            for (int x = 0; x < xBotonEncendidoFarolas && !romperBucleComprobar; x++) {
                for (int y = 0; y < yBotonEncendidoFarolas; y++) {
                    if (calles == null)
                        throw new AssertionError();
                    if (calles.equals("Calle " + (x + 1))) {//comparamos el nombre del item con la calle
                        if (botonEncendidoFarolasComprobar[x][y]) {//Si la farola esta encendida entrara a la condicion
                            romperBucleComprobar = true;//cuando entre, como ya ha encontrado la farola encendida indicamos que queremos romper bucle, pero solo romperemos el de y
                            //porque la comparativa va por columnas, no filas
                            if (y < 7 && botonEncendidoFarolasComprobar[x][y]) {//si el indice de la columna es menor que 7 y encima la farola esta encendida entrara
                                //para contar las farolas que hay a la izquierda encendidas
                                if (titulo == 0) {//ponemos el "titulo" mencionado anteriormente, sirve para separar los datos y que queden mas organizados
                                    resultadoMostradoConsulta.append("-------------------IZQUIERDA------------------" + "\n");
                                    titulo = 1;
                                }
                                resultadoMostradoConsulta.append("Esta encendida la farola numero: " + (y + 1) + "\n");//indicamos la farola encendida, el y + 1 es para que la persona vea
                                //que el programa funciona bien, puesto que nosotros contamos desde 1 pero el indica es desde 0
                                nFarolasIzquierdaEncendidas++;//a?adimos uno al numero de farolas encendidas
                            }
                            if (y >= 7) {//su el indice de y es mayor o igual a 7 entrara a las farolas de la derecha
                                if (titulo == 1) {//limitamos el titulo en solo a 1 para organizar los datos a escribir
                                    resultadoMostradoConsulta.append("-------------------DERECHA------------------" + "\n");
                                    titulo = 2;
                                }
                                resultadoMostradoConsulta.append("Esta encendida la farola numero: " + (y + 1) + "\n");//indicamos la farola a la derecha encendida
                                nFarolasDerechaEncendidas++;// a?adimos uno a las farolas de la derecha encendidas
                            }
                        } else if (!botonEncendidoFarolasComprobar[x][y]) { // si la farola no estaba encendida
                            romperBucleComprobar = true;//romperemos bucle
                            numeroFarolasNoEncendidas++;//a?adiremos 1 al numero de farolas no encendidas
                            if (numeroFarolasNoEncendidas == 14) {//y cuando ese numero llegue a 14, querra decir que ninguna farola estara encendida, por tanto:
                                resultadoMostradoConsulta.append("No hay ninguna farola encendida");//se indica el mensaje
                                mostrarRegularNo = false;//Para que si no hay ninguna farola encendida solo muestre el mensaje de arriba
                            }
                        }//fin de else if( botonEncendidoFarolasComprobar[x][y] == false )
                    }// fin de if( calles.equals( "Calle " + (x + 1) ) )
                }//Fin de for y
            }//Fin de for x

            if (nFarolasIzquierdaEncendidas != 0 || nFarolasDerechaEncendidas != 0) {//si alguna de las farolas, sea cual sea esta encendida entrara al condicional
                resultadoMostradoConsulta.append("---------------------TOTAL--------------------" + "\n");//pondra el titulo de totales
                //Indicara cuantas farolas de la izquierda y cuantas de la derecha habia encendidas en total
                if (nFarolasIzquierdaEncendidas == 1)
                    resultadoMostradoConsulta.append(nFarolasIzquierdaEncendidas + " Farola encendida a la izquierda" + "\n");
                if (nFarolasIzquierdaEncendidas > 1)
                    resultadoMostradoConsulta.append(nFarolasIzquierdaEncendidas + " Farolas encendidas a la izquierda" + "\n");
                if (nFarolasDerechaEncendidas == 1)
                    resultadoMostradoConsulta.append(nFarolasDerechaEncendidas + " Farola encendida a la derecha" + "\n");
                if (nFarolasDerechaEncendidas > 1)
                    resultadoMostradoConsulta.append(nFarolasDerechaEncendidas + " Farolas encendidas a la derecha" + "\n");
            }// fin de if( nFarolasIzquierdaEncendidas != 0 || nFarolasDerechaEncendidas != 0 )

            if (mostrarRegularNo) {//Para saber si se debe mostrar el mensaje o no
                for (int x = 0; x < 5 && !romperBucle; x++) {
                    for (int y = 0; y < 14 && !romperBucle; y++) {
                        if (tituloVisibilidad == 0) {//Solo mostramos una vez el titulo
                            resultadoMostradoConsulta.append("-------------------VISIBILIDAD------------------" + "\n");
                            tituloVisibilidad = 1;
                        }
                        if (botonEncendidoFarolasComprobar[x][yTemporalPar]) {//Comprobamos si estan encendidas las farolas pares
                            yTemporalPar += 2;
                            contadorTruePar++;
                            if (contadorTruePar == 7) {
                                resultadoMostradoConsulta.append("El encendido de las farolas es regular" + "\n");
                                romperBucle = true;
                            }
                        } else if (botonEncendidoFarolasComprobar[x][yTemporalImpar]) {//comprobamos si estan encendidas las farolas impares
                            yTemporalImpar += 2;
                            contadorTrueImpar++;
                            if (contadorTrueImpar == 7) {
                                resultadoMostradoConsulta.append("El encendido de las farolas es regular" + "\n");
                                romperBucle = true;
                            }
                        } else {
                            resultadoMostradoConsulta.append("El encendido de las farolas no es regular" + "\n");
                            romperBucle = true;
                        }//fin else
                    }//Fin for y
                }//Fin for x
            }//Fin if( mostrarRegularNo == true )
        } //Fin de if(e.getSource() == botonResultadoSeleccionCalles)
    } //Fin de ActionPerformed
} //Fin de public class
