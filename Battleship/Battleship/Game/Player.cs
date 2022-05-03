namespace Battleship.Gameplay
{
    public class Player
    {
        private List<Ship> _ships;
        public bool IsAlive { get; }
        public string Name { get; private set; }

        public Player(string name)
        {
            _ships = new List<Ship>();
            Name = name;
        }

        public void AddShip(Ship ship)
        {
            _ships.Add(ship);
        }

        public List<Ship> GetShips()
        {
            return _ships;
        } 
    }
}