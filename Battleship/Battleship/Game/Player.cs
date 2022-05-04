namespace Battleship.Gameplay
{
    public class Player : Program.Battleship
    {
        private List<Ship> _ships;
        public bool IsAlive { get; }
        public string Name { get; private set; }
        public List<Tuple<int, int>> Shots { get; private set; }
        

        public Player(string name)
        {
            _ships = new List<Ship>();
            Name = name;
            Shots = new List<Tuple<int, int>>();
        }

        public void AddShip(Ship ship)
        {
            _ships.Add(ship);
        }

        public List<Ship> GetShips()
        {
            return _ships;
        }

        public void Attack(Player enemy)
        {
            _display.Message($"It's {Name}'s turn to attack!");
            Tuple<int, int> shot = _input.ShotValidation(Shots);
            Shots.Add(shot);

        }
    }
}