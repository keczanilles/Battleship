using Battleship.Util;

namespace Battleship.Gameplay
{
    public class Board
    {
        private Square[,] _ocean;
        private int _boardSize;

        public Board(int boardSize, int gameMode)
        {
            _ocean = new Square[boardSize, boardSize];
            _boardSize = boardSize;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    _ocean[row, col] = new Square((row, col), SquareStatus.Empty);
                }
            }
        }

        public bool IsPlacementOk(Player player, Tuple<int, int, Direction> startPosition, int shipLength)
        {
            int row = startPosition.Item1;
            int col = startPosition.Item2;
            Direction direction = startPosition.Item3;
            List<Ship> ships = player.ReturnShips();

            if (direction == Direction.Horizontal)
            {
                return CheckHorizontal(player, row, col, direction, shipLength, ships);
                
            }
            else
            {
                return CheckVertical(player, row, col, direction, shipLength, ships);
            }
            
            return false;
        }

        public bool CheckHorizontal(Player player, int row, int col, Direction direction, int shipLength, List<Ship> ships)
        {
            if (row < _boardSize && col < (_boardSize - shipLength) && col >= 0)
            {
                foreach(Ship ship in ships)
                {
                    for (int i = 0; i < shipLength; i++)
                    {

                    }
                }
            }
            return false;
        }

        public bool CheckVertical(Player player, int row, int col, Direction direction, int shipLength, List<Ship> ships)
        {
            if (row < _boardSize && col < _boardSize && col >= 0)
            {

            }
            return false;
        }

        public SquareStatus CheckSquare((int, int) position)
        {
            return _ocean[position.Item1, position.Item2]._squareStatus;
        }
    }
}