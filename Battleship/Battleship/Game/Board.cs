namespace Battleship.Game
{
    public class Board
    {
        private Square[,] _ocean;
        public Board(int boardSize)
        {
            for (int row = 0; row < boardSize; row++)
            {
                for(int col = 0; col < boardSize; col++)
                {
                    _ocean[row, col] = new Square((row,col));
                }
            }
        }

        public bool IsPlacementOk()
        {
            throw new NotImplementedException();
        }

        public SquareStatus CheckSquare((int, int) position)
        {
            return _ocean[position.Item1, position.Item2]._squareStatus;
        }
    }
}