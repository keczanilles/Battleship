using Battleship.Gameplay;
using Battleship.Util;

namespace Battleship.Game
{
    public class BoardFactory : Program.Battleship
    {
        public void RandomPlacement(Player player)
        {

        }
        public void ManualPlacement(Player player, Board board)
        {
            Ship Carrier = new Ship();
            Ship Battleship = new Ship();
            Ship Cruiser = new Ship();
            Ship Submarine = new Ship();
            Ship Destroyer = new Ship();
            Tuple<int, int, Direction> startPosition = _input.PlacementValidation();
            Console.WriteLine(startPosition);

            

        }
    }
}
