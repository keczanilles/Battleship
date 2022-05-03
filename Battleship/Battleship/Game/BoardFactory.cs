using Battleship.Gameplay;
using Battleship.Util;

namespace Battleship.Game
{
    public class BoardFactory : Program.Battleship
    {
        public void RandomPlacement(Player player)
        {

        }
        public void ManualPlacement(Player player, Board board, int index)
        {
            List<ShipType> ships = new List<ShipType>()
            {
                ShipType.Carrier,
                ShipType.Battleship,
                ShipType.Cruiser,
                ShipType.Submarine,
                ShipType.Destroyer
            };
            int shipLength = Ship.ShipLength(ships[index]);
            Ship ship = new Ship(shipLength);

            bool isOk = false;
            while (!isOk)
            {
                Tuple<int, int, Direction> startPosition = _input.PlacementValidation();
                if (board.IsPlacementOk(player, startPosition, shipLength))
                {
                    for (int i = 0; i < shipLength; i++)
                    {

                        if (startPosition.Item3 == Direction.Horizontal)
                        {
                            Square square = new Square((startPosition.Item1, startPosition.Item2 + i), SquareStatus.Ship);
                            ship.AddSquare(square);
                        }
                        else if (startPosition.Item3 == Direction.Vertical)
                        {
                            Square square = new Square((startPosition.Item1 + i, startPosition.Item2), SquareStatus.Ship);
                            ship.AddSquare(square);
                        }

                    }
                    player.AddShip(ship);
                    isOk = true;
                }
                
            }
      



        }
        

    }
}
