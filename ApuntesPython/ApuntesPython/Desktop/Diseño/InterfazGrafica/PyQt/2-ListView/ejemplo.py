from PyQt5 import QtWidgets
from ejemplo_ui import Ui_MainWindow
import sys
 
class mywindow(QtWidgets.QMainWindow):
    def __init__(self):
        super(mywindow, self).__init__()
        self.ui = Ui_MainWindow()
        self.ui.setupUi(self)
        self.ui.agregar.clicked.connect(self.btnAgregar)

    def btnAgregar(self):
        self.ui.lista = QtWidgets.QListWidgetItem("Hola")
        self.ui.lista.ad
            
       
if __name__ == "__main__":
    app = QtWidgets.QApplication([])
    application = mywindow()
    application.show()
    sys.exit(app.exec())