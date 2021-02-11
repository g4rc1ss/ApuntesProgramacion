from PyQt5 import QtWidgets
from ejemplo1_ui import Ui_MainWindow
import sys
 
class mywindow(QtWidgets.QMainWindow):
    def __init__(self):
        super(mywindow, self).__init__()
        self.ui = Ui_MainWindow()
        self.ui.setupUi(self)
        self.ui.botonMostrar.clicked.connect(self.btnMostrar) # connecting the clicked signal with btnClicked slot
        self.ui.botonDefault.clicked.connect(self.btnDefault)
 
    def btnMostrar(self):
        texto = self.ui.editCel.text()
        self.ui.label.setText(texto)
    
    def btnDefault(self):
        self.ui.label.setText("Hola")
       
 
if __name__ == "__main__":
    app = QtWidgets.QApplication([])
    application = mywindow()
    application.show()
    sys.exit(app.exec())