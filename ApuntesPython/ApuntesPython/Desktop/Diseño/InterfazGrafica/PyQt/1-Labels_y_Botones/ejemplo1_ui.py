# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'ventana1.ui'
#
# Created by: PyQt5 UI code generator 5.11.3
#
# WARNING! All changes made in this file will be lost!

from PyQt5 import QtCore, QtGui, QtWidgets

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(800, 600)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.editCel = QtWidgets.QLineEdit(self.centralwidget)
        self.editCel.setGeometry(QtCore.QRect(210, 150, 121, 20))
        self.editCel.setObjectName("editCel")
        self.botonMostrar = QtWidgets.QPushButton(self.centralwidget)
        self.botonMostrar.setGeometry(QtCore.QRect(130, 200, 121, 41))
        self.botonMostrar.setObjectName("botonMostrar")
        self.label = QtWidgets.QLabel(self.centralwidget)
        self.label.setGeometry(QtCore.QRect(210, 290, 111, 21))
        self.label.setText("")
        self.label.setObjectName("label")
        self.botonDefault = QtWidgets.QPushButton(self.centralwidget)
        self.botonDefault.setGeometry(QtCore.QRect(290, 200, 121, 41))
        self.botonDefault.setObjectName("botonDefault")
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 800, 21))
        self.menubar.setObjectName("menubar")
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName("statusbar")
        MainWindow.setStatusBar(self.statusbar)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow"))
        self.botonMostrar.setText(_translate("MainWindow", "mostrarLabel"))
        self.botonDefault.setText(_translate("MainWindow", "default"))


if __name__ == "__main__":
    import sys
    app = QtWidgets.QApplication(sys.argv)
    MainWindow = QtWidgets.QMainWindow()
    ui = Ui_MainWindow()
    ui.setupUi(MainWindow)
    MainWindow.show()
    sys.exit(app.exec_())

