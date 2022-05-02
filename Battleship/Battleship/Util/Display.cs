namespace Battleship.Util
{
    public class Display
    {

        public Display()
        { }

        public void GameMenu()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Display high-scores");
            Console.WriteLine("3. Exit");
        }

        public void PrintError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
}
