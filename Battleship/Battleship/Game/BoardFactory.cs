using Battleship.Gameplay;
using Battleship.Enum;

namespace Battleship.Game
{
    public class BoardFactory : Program.Battleship
    {
        public Tuple<int, int, Direction> RandomPlacement(int boardSize)
        {
            Random random = new Random();
            int row = random.Next(0, boardSize);
            int col = random.Next(0, boardSize);
            List<Direction> directions = new List<Direction>() {Direction.Vertical, Direction.Horizontal};
            Direction direction = directions[random.Next(0, 2)];
            return new Tuple<int, int, Direction>(row, col, direction);
        }

        public void ManualPlacement(Player player, Board board, Enum.ShipType shipType)
        {
            Ship ship = new Ship();
            int shipLength = Ship.GetLength(shipType);
            bool isOk = false;

            while (!isOk)
            {
                Tuple<int, int, Direction> startPosition =
                    player.Type ? _input.PlacementValidation() : RandomPlacement(board.GetBoardSize());
                if (board.IsPlacementOk(player, startPosition, shipLength))
                {
                    for (int i = 0; i < shipLength; i++)
                    {
                        if (startPosition.Item3 == Direction.Horizontal)
                        {
                            Square square = new Square(new Tuple<int, int>(startPosition.Item1, startPosition.Item2 + i), SquareStatus.Ship);
                            ship.AddSquare(square);
                        }
                        else if (startPosition.Item3 == Direction.Vertical)
                        {
                            Square square = new Square(new Tuple<int, int>(startPosition.Item1 + i, startPosition.Item2), SquareStatus.Ship);
                            ship.AddSquare(square);
                        }
                    }
                    player.AddShip(ship);
                    isOk = true;
                }
                else
                {
                    if (player.Type)
                    {
                        _display.Message("You can't place your ship here!", ConsoleColor.Red);
                    }
                }
            }
        }
    }
}
