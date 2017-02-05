
public class Board {
	private Tile[,] board;
	public Board() {
        board = new Tile[4, 4];
		for (int i = 0; i < board.GetLength(0); i++)
		{
			 for(int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = new Tile();
            }
		}
	}

    public Tile[,] getBoard()
    {
        return board;
    }

}
