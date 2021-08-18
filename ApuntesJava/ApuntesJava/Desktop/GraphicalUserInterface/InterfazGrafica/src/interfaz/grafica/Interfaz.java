package interfaz.grafica;

import javax.swing.*;

public class Interfaz extends JFrame {
    String rangoEdad[] = {"10-15", "15-20", "20-25", "25-30", "30-35", "35-40", "40-45", "45-50"};

    //region Declarar Objetos de la GUI
    protected JButton botonAceptar;

    protected JLabel labelNombre;
    protected JLabel labelApellido;

    protected JTextField nombre;
    protected JTextField apellido;

    protected JComboBox comboEdad;

    protected JRadioButton radioSexoM;
    protected JRadioButton radioSexoF;
    protected ButtonGroup grupoSexo;

    protected JCheckBox checkAficionesLeer;
    protected JCheckBox checkAficionesTiroArco;
    protected JCheckBox checkAficionesExpoPerros;
    //endregion

    public Interfaz() {
        setBounds(0, 0, 400, 200);
        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle("Actividad 2");
    }

    public void cargaComponentes() {
        setLayout(null);
        labelNombre = new JLabel();
        labelNombre.setBounds(0, 0, 100, 20);
        labelNombre.setText("Nombre:");
        add(labelNombre);
        nombre = new JTextField();
        nombre.setBounds(0, 20, 100, 20);
        add(nombre);

        labelApellido = new JLabel();
        labelApellido.setBounds(102, 0, 100, 20);
        labelApellido.setText("Apellido:");
        add(labelApellido);
        apellido = new JTextField();
        apellido.setBounds(102, 20, 100, 20);
        add(apellido);

        comboEdad = new JComboBox();
        comboEdad.setBounds(0, 50, 100, 25);
        add(comboEdad);
        for (String edades : rangoEdad)
            comboEdad.addItem(edades);

        radioSexoM = new JRadioButton("Maculino");
        radioSexoM.setBounds(0, 80, 100, 25);
        add(radioSexoM);
        radioSexoF = new JRadioButton("Femenino");
        radioSexoF.setBounds(0, 100, 100, 25);
        add(radioSexoF);
        grupoSexo = new ButtonGroup();
        grupoSexo.add(radioSexoF);
        grupoSexo.add(radioSexoM);

        checkAficionesLeer = new JCheckBox("Leer");
        checkAficionesLeer.setBounds(120, 50, 200, 25);
        add(checkAficionesLeer);
        checkAficionesTiroArco = new JCheckBox("Tiro con Arco");
        checkAficionesTiroArco.setBounds(120, 70, 200, 25);
        add(checkAficionesTiroArco);
        checkAficionesExpoPerros = new JCheckBox("Exposicion de perros");
        checkAficionesExpoPerros.setBounds(120, 90, 200, 25);
        add(checkAficionesExpoPerros);

        botonAceptar = new JButton("Aceptar");
        botonAceptar.setBounds(80, 130, 200, 25);
        add(botonAceptar);

        // Una vez cargado los componentes visualizamos la ventana
        setVisible(true);
    }
}
