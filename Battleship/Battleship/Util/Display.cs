using Battleship.Enum;
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

        public void Message(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void InlineMessage(string message)
        {
            Console.Write(message);
        }

        public void NewLine()
        {
            Console.Write(Environment.NewLine);
        }

        public void PrintLogo(ConsoleColor color)
        {
            Console.ForegroundColor = color;
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
            Console.ResetColor();
        }

        public void Menu(params string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }

        public void Board(Player player, Player enemy, int boardSize, Board board)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            string halfSpace = "\u2000";
            

            for (int i = 1; i < boardSize + 1; i++)
            {
                if (i == 1)
                {
                    Console.Write($"{halfSpace}  0{i}  ");
                }
                else
                {
                    Console.Write(i < 10 ? $"0{i}  " : $"{i}  ");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
            for (int row = 0; row < boardSize; row++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{(char)(row + 65)}  ");
                Console.ResetColor();
                for (int col = 0; col < boardSize; col++)
                {
                    Console.Write(CheckSquareType(player, enemy, row, col, board));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public string CheckSquareType(Player player, Player enemy, int row, int col, Board board)
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
