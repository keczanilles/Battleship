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

        public void BoardSize()
        {
            Console.WriteLine("Please select the size of the board!(between 10 and 20): ");
        }
    }
}
