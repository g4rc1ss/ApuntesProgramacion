using ShellProgressBar;
using System;
using System.Threading;

namespace ConsoleDesign.ProgressBar {
    //Importamos el modulo NuGet "ShellProgressBar"
    public class BarrasDeProgreso {
        public void BarraProgreso() {
            const int TOTALTICKS = 30;

            var options = new ProgressBarOptions {
                //Caracter a poner de la barra, por ejemplo un # o un █ 
                ProgressCharacter = '#',
                //
                ProgressBarOnBottom = false,
                //Se establece el color de fondo de la barra creada
                BackgroundColor = ConsoleColor.Cyan,
                //Se pone el caracter de fondo que se ira sustituyendo con el progreso
                BackgroundCharacter = '·',
                //Ponemos el color de la barra que va progresando(sino sera el color normal de la consola)
                ForegroundColor = ConsoleColor.Blue
            };

            /*
             * Argumentos de ProgressBar(int maxTicks, string message, ConsoleColor.White)
             * maxTicks -> es el numero de elementos total que tiene que procesar, esta ya
             * * divide para sacar el porcentaje sobre el 100%
             * message -> mensaje incial de la barra
             * 
             * Console.Color -> Indicas el color que va a tener la barra de progreso
             * ProgressBarOptions option -> explicado arriba
             */
            using (var pbar = new ShellProgressBar.ProgressBar(TOTALTICKS, "Initial message", options)) {
                for (var x = 0; x < TOTALTICKS; x++) {
                    //suma +1 el progreso
                    pbar.Tick();
                    //Para apreciar, pero dentro de este bucle va el codigo
                    Thread.Sleep(100);
                }
            }
            using (var pbar = new ShellProgressBar.ProgressBar(TOTALTICKS, "Initial message", ConsoleColor.Gray)) {
                for (var x = 0; x < TOTALTICKS; x++) {
                    //suma +1 el progreso
                    pbar.Tick();
                    //Para apreciar, pero dentro de este bucle va el codigo
                    Thread.Sleep(100);
                }
            }
        }
    }
}
