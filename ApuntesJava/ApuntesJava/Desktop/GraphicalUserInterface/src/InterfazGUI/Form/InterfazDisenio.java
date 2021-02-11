package InterfazGUI.Form;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class InterfazDisenio {

    private JButton button1;
    private JPanel panel1;
    private JPasswordField passwordField2;

    public JPanel getPanel1() {
        return panel1;
    }

    public InterfazDisenio() {
        button1.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                System.out.println(passwordField2.getText());
            }
        });
    }

}
