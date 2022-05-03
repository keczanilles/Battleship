using Battleship.Game;

namespace Battleship.Gameplay
{
    public class Ship
    {
        private List<Square> _ships;
        private int _length;


        public Ship(int length)
        {
            _ships = new List<Square>();
            _length = length;
        }

        public void AddSquare(Square square)
        {
            _ships.Add(square);
        }

        public static int ShipLength(ShipType shiptype)
        {
            switch (shiptype)
            {
                case ShipType.Carrier:
                    return 5;
                case ShipType.Battleship:
                    return 4;
                case ShipType.Cruiser:
                    return 3;
                case ShipType.Submarine:
                    return 3;
                case ShipType.Destroyer:
                    return 2;
                default:
                    return 0;
            }
        }
    }
}