namespace Ucu.Poo.GameOfLife;

public class Logic
{
    static bool[,] gameBoard;  /* contenido del tablero */
    private int boardWidth;
    private int boardHeight; 

    public Logic(bool[,] initialBoard)
    {
        gameBoard = initialBoard;
        boardWidth = gameBoard.GetLength(0);
        boardHeight = gameBoard.GetLength(1);
    }

    public void UpdateBoard()
    {
        bool[,] cloneBoard = new bool[boardWidth, boardHeight];
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                int aliveNeighbors = 0;
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && gameBoard[i, j])
                        {
                            aliveNeighbors++;
                        }
                    }
                }

                if (gameBoard[x, y])
                {
                    aliveNeighbors--;
                }

                if (gameBoard[x, y] && aliveNeighbors < 2)
                {
                    //Celula muere por baja población
                    cloneBoard[x, y] = false;
                }
                else if (gameBoard[x, y] && aliveNeighbors > 3)
                {
                    //Celula muere por sobrepoblación
                    cloneBoard[x, y] = false;
                }
                else if (!gameBoard[x, y] && aliveNeighbors == 3)
                {
                    //Celula nace por reproducción
                    cloneBoard[x, y] = true;
                }
                else
                {
                    //Celula mantiene el estado que tenía
                    cloneBoard[x, y] = gameBoard[x, y];
                }

            }
        }
        gameBoard = cloneBoard;
    }
    public bool[,] GetBoard()
    {
        return gameBoard;
    }
}