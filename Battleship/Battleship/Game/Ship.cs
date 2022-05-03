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
    }
}