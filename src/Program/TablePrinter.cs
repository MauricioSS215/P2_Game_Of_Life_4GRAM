namespace Ucu.Poo.GameOfLife;
using System;
using System.Text;
using System.Threading;
using System.Runtime;

public class TablePrinter
{
    private bool[,] board; //variable que representa el tablero
    private int width; //variabe que representa el ancho del tablero
    private int height; //variabe que representa altura del tablero
    private Logic gameLogic;

    public TablePrinter(bool[,] initialBoard, Logic logic)
    {
        board = initialBoard;
        width = board.GetLength(0);
        height = board.GetLength(1);
        gameLogic = logic;
    }

    public void PrintAndRun()
    {
        while (true)
        {
            Console.Clear();
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (board[x, y])
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }

                s.Append("\n");
            }

            Console.WriteLine(s.ToString());
            //=================================================
            //Invocar método para calcular siguiente generación
            gameLogic.UpdateBoard();
            board = gameLogic.GetBoard();
            //=================================================
            Thread.Sleep(300);
        }
        

    }
}