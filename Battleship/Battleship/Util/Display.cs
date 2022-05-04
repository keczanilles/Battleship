using Battleship.Game;
using Battleship.Gameplay;

namespace Battleship.Util
{
    public class Display
    {
        public Display()
        { }

        public static void Clear(int second)
        {
            Thread.Sleep(second * 1000);
            Console.Clear();
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public void NewLine()
        {
            Console.Write(Environment.NewLine);
        }

        public void PrintLogo()
        {
            Console.Write(@"                                     |__
                                     |\/
                                     ---
                                     / | [
                              !      | |||
                            _/|     _/|-++'
                        +  +--|    |--|--|_ |-
                     { /|__|  |/\__|  |--- |||__/
                    +---------------___[}-_===_.'____               /\
                ____`-' ||___-{]_| _[}-  |     |_[___\==--          \/   _
 __..._____--==/___]_|__|_____________________________[___\==--___,-----' .7
|                                                      Don Juan d'Hungary/
 \_______________________________________________________________________|");
            Console.WriteLine(Environment.NewLine);
        }

        public void Menu(params string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }

        public void Board(Player player, Player enemy, int boardSize, Board board, Gameplay.Game game)
        {
            Console.WriteLine();
            for (int i = 1; i < boardSize + 1; i++)
            {
                if (i == 1)
                {
                    Console.Write($"   {i} ");
                }
                else
                {
                    Console.Write(i < 10 ? $" {i} " : $"{i} ");
                }
            }
            Console.WriteLine();
            for (int row = 0; row < boardSize; row++)
            {
                Console.Write($"{(char)(row + 65)}  ");
                for (int col = 0; col < boardSize; col++)
                {
                    Console.Write(CheckSquareType(player, enemy, row, col, board, game));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public string CheckSquareType(Player player, Player enemy, int row, int col, Board board, Gameplay.Game game)
        {
            if (board._boardType)
            {
                foreach (Ship ship in player.GetShips())
                {
                    foreach (Square square in ship.GetSquares())
                    {
                        if (row == square.Position.Item1 && col == square.Position.Item2)
                        {
                            return Square.GetCharacter(square.GetSquareStatus());
                        }
                    }
                }
                return Square.GetCharacter(SquareStatus.Empty);
            }
            

            if (player.Shots.Contains(new Tuple<int, int>(row, col)))
            {
                foreach (Ship ship in enemy.GetShips())
                {
                    foreach (Square square in ship.GetSquares())
                    {
                        if (square.Position.Item1 == row && square.Position.Item2 == col)
                        {
                            return Square.GetCharacter(SquareStatus.Hit);
                        }
                    }
                }
                return Square.GetCharacter(SquareStatus.Missed);
            }
            return Square.GetCharacter(SquareStatus.Empty);
        }

        public void PlacementTurn(Player player, ShipType ship)
        {
            Console.WriteLine($"It's {player.Name}'s turn, please place down your {ship} which is {Ship.GetLength(ship)} squares long.");
        }
    }
}
