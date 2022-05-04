using Battleship.Game;

namespace Battleship.Gameplay
{
    public class Ship
    {
        private List<Square> _ships;
        
        public Ship()
        {
            _ships = new List<Square>();
        }

        public void AddSquare(Square square)
        {
            _ships.Add(square);
        }

        public List<Square> GetSquares()
        {
            return _ships;
        }

        public static int GetLength(ShipType shiptype)
        {
            switch (shiptype)
            {
                case ShipType.Carrier:
                    return 5;
                /*case ShipType.Battleship:
                    return 4;
                case ShipType.Cruiser:
                    return 3;
                case ShipType.Submarine:
                    return 3;
                case ShipType.Destroyer:
                    return 2;*/
                default:
                    return 0;
            }
        }
    }
}