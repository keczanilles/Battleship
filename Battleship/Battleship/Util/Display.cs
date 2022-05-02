using Battleship.Game;

namespace Battleship.Util
{
    public class Display
    {

        public Display()
        { }

        public void GameMenu(params string[] options)
        {
            Console.WriteLine("Please select an option:");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i+1}. {options[i]}");
            }
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        
        public void PrintBoard(int boardSize, Board board)
        {
            
            Console.WriteLine();

            for (int i = 1; i < boardSize + 1; i++)
            {
                if (i == 1)
                {
                    Console.Write($"   {i}  ");
                }
                else
                {
                    Console.Write(i < 9 ? $"{i}  " : $"{i} ");
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
    }
}
