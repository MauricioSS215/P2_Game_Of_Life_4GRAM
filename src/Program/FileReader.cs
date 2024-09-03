namespace Ucu.Poo.GameOfLife;
using System.IO;
//nuevos comentarios puestos para estudio
public class FileReader
{
    string url = "board.txt"; //ruta de acceso al archivo
    public bool[,] Board { get; private set; } //clase tipo booleana con un arreglo en 2D(array)

    public FileReader(string url) //clase constructor
    {
        string content = File.ReadAllText(url);//lee_todo_lo que hay dentro del archivo
        string[] contentLines = content.Split('\n');//se convierte cada linea en una cadena y luego se divide 
        Board = new bool[contentLines.Length, contentLines[0].Length]; //dimensiones del arreglo 2D

        for (int y = 0; y < contentLines.Length; y++)
        {
            for (int x = 0; x < contentLines[y].Length; x++)
            {
                if (contentLines[y][x] == '1')//verifica si en la posicion hay un uno, si es asi,cambia Board a un true sino se mantiene
                {
                    Board[x, y] = true; 
                }
            }
        }
    }

}