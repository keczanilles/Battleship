using Battleship.Util;

namespace Battleship.Gameplay
{
    public class Board
    {
        private Square[,] _ocean;
        private int _boardSize;
        public bool _boardType { get; set; }

        public Board(int boardSize, int gameMode, bool type)
        {
            _ocean = new Square[boardSize, boardSize];
            _boardSize = boardSize;
            _boardType = type;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    _ocean[row, col] = new Square(new Tuple<int, int>(row, col), SquareStatus.Empty);
                }
            }
        }

        
        public bool IsPlacementOk(Player player, Tuple<int, int, Direction> startPosition, int shipLength)
        {
            int row = startPosition.Item1;
            int col = startPosition.Item2;
            Direction direction = startPosition.Item3;
            List<Ship> ships = player.GetShips();

            if (direction == Direction.Horizontal)
            {
                return CheckHorizontal(player, row, col, direction, shipLength, ships);
            }
            else
            {
                return CheckVertical(player, row, col, direction, shipLength, ships);
            }
        }


        public bool CheckNeighbours(Ship ship, int row, int col)
        {
            foreach (var square in ship.GetSquares())
            {
                Tuple<int, int> shipPositions = new Tuple<int, int>(square.Position.Item1, square.Position.Item2);

                List<Tuple<int, int>> neighbours = new List<Tuple<int, int>>()
                {
                    Tuple.Create(row + 1, col),
                    Tuple.Create(row - 1, col),
                    Tuple.Create(row, col + 1),
                    Tuple.Create(row, col - 1)
                };

                if (neighbours.Contains(shipPositions))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckHorizontal(Player player, int row, int col, Direction direction, int shipLength, List<Ship> ships)
        {
            if (row < _boardSize && col <= (_boardSize - shipLength) && col >= 0)
            {
                foreach (Ship ship in ships)
                {
                    bool hasNeighbours;
                    for (int i = 0; i < shipLength; i++)
                    {
                        hasNeighbours = CheckNeighbours(ship, row, col + i);

                        if (hasNeighbours)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public bool CheckVertical(Player player, int row, int col, Direction direction, int shipLength, List<Ship> ships)
        {
            if (row <= (_boardSize - shipLength) && col < _boardSize && col >= 0)
            {
                foreach (Ship ship in ships)
                {
                    bool hasNeighbours;
                    for (int i = 0; i < shipLength; i++)
                    {
                        hasNeighbours = CheckNeighbours(ship, row + i, col);
                        if (hasNeighbours)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public SquareStatus CheckSquare((int, int) position)
        {
            return _ocean[position.Item1, position.Item2].GetSquareStatus();
        }
    }
}