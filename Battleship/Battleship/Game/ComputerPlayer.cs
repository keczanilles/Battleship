using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Game
{
    public class ComputerPlayer : Gameplay.Player
    {
        public ComputerPlayer(string name, bool type) : base(name, type)
        {
            Name = name;
            Type = type;
        }

        public Tuple<int, int> RandomAttack(int boardSize, List<Tuple<int, int>> Shots)
        {
            Random random = new Random();
            while (true)
            {
                int row = random.Next(0, boardSize);
                int col = random.Next(0, boardSize);
                if (!Shots.Contains(new Tuple<int, int>(row, col)))
                {
                    return new Tuple<int, int>(row, col);
                }
            }
        }
    }
}
