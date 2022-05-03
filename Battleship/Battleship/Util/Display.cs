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

        public void Menu(params string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }

        public void Board(int boardSize, Board board)
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
                    SquareStatus squareStatus = board.CheckSquare((row, col));
                    Console.Write(Square.GetCharacter(squareStatus));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PlacementTurn(int index, Player player, List<ShipType> ships)
        {
            Console.WriteLine($"It's {player.Name}'s turn, please place down your {ships[index]} which is {Ship.ShipLength(ships[index])} squares long.");
        }
    }
}
