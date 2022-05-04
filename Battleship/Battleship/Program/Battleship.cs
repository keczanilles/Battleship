using Battleship.Game;
using Battleship.Util;

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
                program._display.PrintLogo();
                program._display.Message("Welcome to our Battleship Game!\n");
                switch (program.Menu())
                {
                    case 1:
                        Display.Clear(0);
                        program._display.Message("Please select the game mode:\n");
                        program._gameMode = program.GameMode();
                        Display.Clear(0);
                        program._display.Message("Please select the size of the board: /10 - 20/\n");
                        program._boardSize = program._input.BoardSizeValidation();
                        Display.Clear(0);
                        Gameplay.Game game = new Gameplay.Game(program._boardSize, program._gameMode);
                        break;
                    case 2:
                        Display.Clear(0);
                        program._display.Message("High score!");
                        break;
                    case 3:
                        Display.Clear(0);
                        program._display.Message("This is the day you will always remember as the day you almost caught Captain Jack Sparrow.");
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