using Battleship.Util;
using Battleship.Gameplay;

namespace Battleship.Program
{
    public class Battleship
    {
        private protected Display _display;
        private protected Input _input;
        private protected int _gameMode;
        private protected int _boardSize;

        public Battleship()
        {
            _display = new Display();
            _input = new Input();
        }

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var program = new Battleship();

            while (true)
            {
                switch (program.Menu())
                {
                    case 1:
                        program._display.Message("Please select the size of the board! (between 10 and 20):");
                        program._boardSize = program._input.BoardSizeValidation();
                        program._gameMode = program.GameMode();
                        Game game = new Game(program._boardSize, program._gameMode);
                        Console.ReadLine();
                        break;
                    case 2:
                        program._display.Message("High score!");
                        break;
                    case 3:
                        program._display.Message("Game over!");
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public int Menu()
        {
            _display.Menu("New Game", "Display high scores", "Exit");
            string select = _input.Select();
            while (_input.InputValidation(3, select) is false)
            {
                _display.Message("Not valid option!");
                select = Console.ReadLine();
            }
            return int.Parse(select);
        }

        public int GameMode()
        {
            _display.Menu("Player vs. Player", "Player vs. Computer");
            string select = _input.Select();
            while (_input.InputValidation(2, select) is false)
            {
                _display.Message("Not valid option!");
                select = Console.ReadLine();
            }
            return int.Parse(select);
        }
    }
}