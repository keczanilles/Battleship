namespace Battleship.Gameplay
{
    public class Player : Program.Battleship
    {
        private List<Ship> _ships;
        public bool IsAlive { get; private set; }
        public string Name { get; private set; }
        public List<Tuple<int, int>> Shots { get; private set; }
        

        public Player(string name)
        {
            _ships = new List<Ship>();
            Name = name;
            Shots = new List<Tuple<int, int>>();
            IsAlive = true;
        }

        public void AddShip(Ship ship)
        {
            _ships.Add(ship);
        }

        public List<Ship> GetShips()
        {
            return _ships;
        }

        public void IsOver()
        {
            var hashSet = new HashSet<SquareStatus>();
            foreach (Ship ship in _ships)
            {
                foreach (Square square in ship.GetSquares())
                {
                    hashSet.Add(square.GetSquareStatus());
                }
            }
            if (hashSet.Count == 1 && hashSet.Contains(SquareStatus.Hit))
            {
                IsAlive = false;
            }
        }

        public void Attack(Player enemy)
        {
            _display.Message($"It's {Name}'s turn to attack!");
            Tuple<int, int> shot = _input.ShotValidation(Shots);
            Shots.Add(shot);
            foreach (Ship ship in enemy.GetShips())
            {
                foreach (Square square in ship.GetSquares())
                {
                    if (square.Position.Item1 == shot.Item1 && square.Position.Item2 == shot.Item2)
                    {
                        square.ChangeStatus(SquareStatus.Hit);
                    }
                    
                }
            }
        }
    }
}