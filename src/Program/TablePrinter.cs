namespace Ucu.Poo.GameOfLife;
using System;
using System.Text;
using System.Threading;
using System.Runtime;

public class TablePrinter
{ 
    bool[,] b //variable que representa el tablero
    int width //variabe que representa el ancho del tablero
    int height //variabe que representa altura del tablero
    public class PrintTable()
        while (true)
        { 
            Console.Clear();
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (b[x, y])
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
            Logic.UpdateBoard();
            //=================================================
            Thread.Sleep(300);
        }

}