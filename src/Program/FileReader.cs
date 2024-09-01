namespace Ucu.Poo.GameOfLife;
using System.IO;

public class FileReader
{
    string url = "board.txt";
    public bool[,] Board { get; private set; }

    public FileReader(string url)
    {
        string content = File.ReadAllText(url);
        string[] contentLines = content.Split('\n');
        Board = new bool[contentLines.Length, contentLines[0].Length];

        for (int y = 0; y < contentLines.Length; y++)
        {
            for (int x = 0; x < contentLines[y].Length; x++)
            {
                if (contentLines[y][x] == '1')
                {
                    Board[x, y] = true; 
                }
            }
        }
    }

}