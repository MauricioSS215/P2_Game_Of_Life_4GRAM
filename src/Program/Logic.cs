namespace Ucu.Poo.GameOfLife;
//comentarios nuevos puesto para el estudio
public class Logic
{
    static bool[,] gameBoard;  /* contenido del tablero */
    private int boardWidth;//ancho del tablero
    private int boardHeight;//altura del tablero

    public Logic(bool[,] initialBoard)//constructor 
    {
        gameBoard = initialBoard;
        boardWidth = gameBoard.GetLength(0);//toma el ancho del tablero (get)
        boardHeight = gameBoard.GetLength(1);//toma el largo del tablero (get)
    }

    public void UpdateBoard()//clase creada para actualizar el tablero en cada ciclo
    {
        bool[,] cloneBoard = new bool[boardWidth, boardHeight];//se clona el tablero originial para ir actualizando el estado del tablero
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                int aliveNeighbors = 0;// bucles anidados para contar el numero de celulas vivas alrededor de cada celda
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && gameBoard[i, j])//bucles anidados que recorren para verificar en un 3x3 cada celda actual,
                        {
                            aliveNeighbors++;//si la  celda actual esta dentro de los limites y si esta viva gameboard es true
                        }// y si ambas son true, aliveNeighbors se incrementa
                    }
                }

                if (gameBoard[x, y])//si la celda actual (x,y) esta viva, aliveNeighbors se reduce en 1
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
        gameBoard = cloneBoard;//despues de que se comprueba las celdas y el cloneboard actualizado, se actualiza al nuevo estado
    }
    public bool[,] GetBoard()
    {
        return gameBoard;//devuelve el estado actual del tablero "gameBoard"
    }
}