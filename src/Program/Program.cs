using System;

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un FileReader para leer el tablero desde el archivo
            FileReader reader = new FileReader("board.txt");

            // Crear la lógica del juego con el tablero leído
            Logic gameLogic = new Logic(reader.Board);

            // Crear el impresor de la tabla con el tablero inicial y la lógica del juego
            TablePrinter printer = new TablePrinter(reader.Board, gameLogic);

            // Ejecutar el juego
            printer.PrintAndRun();
        }
    }
}
