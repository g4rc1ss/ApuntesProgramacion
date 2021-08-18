package InterfazBuilder;

import java.awt.BorderLayout;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JTextField;
import javax.swing.JLabel;
import javax.swing.JButton;

public class EjercicioPrueba extends JFrame implements ActionListener{

	String strg1;
	String strg2;
	
	private JPanel contentPane;
	private JTextField textField;
	private JTextField textField_1;
	private JTextField textField_2;

	JButton btnSumar;
	JButton btnRestar;
	JButton btnMultiplicar;
	JButton btnDividir;
	JButton btnLimpiar;
	
	
	public EjercicioPrueba() {
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 456, 315);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		textField = new JTextField();
		textField.setBounds(135, 50, 86, 20);
		contentPane.add(textField);
		textField.setColumns(10);
		
		textField_1 = new JTextField();
		textField_1.setBounds(135, 81, 86, 20);
		contentPane.add(textField_1);
		textField_1.setColumns(10);
		
		textField_2 = new JTextField();
		textField_2.setBounds(306, 67, 86, 20);
		contentPane.add(textField_2);
		textField_2.setColumns(10);
		
		JLabel lblPrimerNmero = new JLabel("Primer número:");
		lblPrimerNmero.setBounds(36, 53, 89, 14);
		contentPane.add(lblPrimerNmero);
		
		JLabel lblSegundoNmero = new JLabel("Segundo número:");
		lblSegundoNmero.setBounds(24, 84, 101, 14);
		contentPane.add(lblSegundoNmero);
		
		JLabel lblResultado = new JLabel("Resultado:");
		lblResultado.setBounds(236, 70, 66, 14);
		contentPane.add(lblResultado);
		
		btnSumar = new JButton("Sumar");
		btnSumar.setBounds(55, 129, 102, 35);
		contentPane.add(btnSumar);
		btnSumar.addActionListener(this);
		
		btnRestar = new JButton("Restar");
		btnRestar.setBounds(55, 175, 102, 35);
		contentPane.add(btnRestar);
		btnRestar.addActionListener(this);
		
		btnMultiplicar = new JButton("Multiplicar");
		btnMultiplicar.setBounds(167, 129, 102, 35);
		contentPane.add(btnMultiplicar);
		btnMultiplicar.addActionListener(this);
		
		btnDividir = new JButton("Dividir");
		btnDividir.setBounds(167, 175, 102, 35);
		contentPane.add(btnDividir);
		btnDividir.addActionListener(this);
		
		btnLimpiar = new JButton("Limpiar");
		btnLimpiar.setBounds(279, 129, 89, 81);
		contentPane.add(btnLimpiar);
		btnLimpiar.addActionListener(this);
	}
	
	
	
	
	@Override
	public void actionPerformed(ActionEvent e) {
		
		try{
			
			if(e.getSource() == btnSumar ){
		
				strg1 = textField.getText();
				strg2 = textField_1.getText();
	
				int num1 = Integer.parseInt(strg1);
				int num2 = Integer.parseInt(strg2);
		
				int resultadoSuma = num1 + num2;
		
				String resultadoStrg = String.valueOf(resultadoSuma);
		
				textField_2.setText(resultadoStrg);
			
			}
			
			if(e.getSource() == btnRestar ){
				
				strg1 = textField.getText();
				strg2 = textField_1.getText();
	
				int num1 = Integer.parseInt(strg1);
				int num2 = Integer.parseInt(strg2);
		
				int resultadoResta = num1 - num2;
		
				String resultadoStrg = String.valueOf(resultadoResta);
		
				textField_2.setText(resultadoStrg);
			
			}
			
			if(e.getSource() == btnMultiplicar ){
				
				strg1 = textField.getText();
				strg2 = textField_1.getText();
	
				int num1 = Integer.parseInt(strg1);
				int num2 = Integer.parseInt(strg2);
		
				int resultadoMulti = num1 * num2;
		
				String resultadoStrg = String.valueOf(resultadoMulti);
		
				textField_2.setText(resultadoStrg);
			
			}
			
			if(e.getSource() == btnDividir ){
				
				strg1 = textField.getText();
				strg2 = textField_1.getText();
	
				int num1 = Integer.parseInt(strg1);
				int num2 = Integer.parseInt(strg2);
		
				int resultadoDivi = num1 / num2;
		
				String resultadoStrg = String.valueOf(resultadoDivi);
		
				textField_2.setText(resultadoStrg);
			
			}
			
			if(e.getSource() == btnLimpiar){
				
				textField.setText("");
				textField_1.setText("");
				textField_2.setText("");
				
			}
			
		}catch(NumberFormatException e1){
			
			setTitle("Falta meter numeros");
			
		}
	}
		
		
	
	
	
	
	
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					EjercicioPrueba frame = new EjercicioPrueba();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}




	

	
	
}
