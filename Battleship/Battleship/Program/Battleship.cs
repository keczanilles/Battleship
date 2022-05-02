using Battleship.Util;

namespace Battleship.Program
{
    public class Battleship
    {
        private Display _display;
        private Input _input;

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
                        Console.WriteLine("new Game");
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
            _display.GameMenu();
            string selectMenu = _input.SelectMenu();
            while (_input.InputValidation(selectMenu) is false)
            {
                _display.PrintError("Not valid option!");
                selectMenu = Console.ReadLine();
            }
            return int.Parse(selectMenu);
        }
    }
}