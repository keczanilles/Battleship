using Battleship.Util;

namespace Battleship.Program
{
    public class Battleship
    {
        private Display _display;
        private Input _input;
        private int _gameMode;
        private int _boardSize;

        public Battleship()
        {
            _display = new Display();
            _input = new Input();
        }

        public static void Main()
        {
            var program = new Battleship();

            while (true)
            {
                switch (program.Menu())
                {
                    case 1:
                        program._display.PrintMessage("Please select the size of the board!(between 10 and 20): ");
                        program._boardSize = program._input.BoardSizeValidation();
                        program._gameMode = program.GameMode();
                        break;
                    case 2:
                        Console.WriteLine("High score");
                        break;
                    case 3:
                        Console.WriteLine("GoodBye Illés és Dalma! Goodbye to the people who hated on me!");
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public int Menu()
        {
            _display.GameMenu("New Game", "Display high scores", "Exit");
            string selectMenu = _input.SelectMenu();
            while (_input.InputValidation(3, selectMenu) is false)
            {
                _display.PrintMessage("Not valid option!");
                selectMenu = Console.ReadLine();
            }
            return int.Parse(selectMenu);
        }



        public int GameMode()
        {
            _display.GameMenu("Player vs. Player", "Player vs. Computer");
            string selected = _input.SelectMenu();
            while (_input.InputValidation(2, selected) is false)
            {
                _display.PrintMessage("Not valid option!");
                selected = Console.ReadLine();
            }
            return int.Parse(selected);
        }

        public int GetBoardSize(string size)
        {
            return int.Parse(size);
        }
    }
}