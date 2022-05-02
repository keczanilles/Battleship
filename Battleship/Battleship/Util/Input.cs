namespace Battleship.Util
{
    public class Input
    {
        public string SelectMenu()
        {
            return Console.ReadLine();
        }

        public bool InputValidation(string input)
        {
            if (new int[] {1, 2, 3}.Contains(int.Parse(input)))
            {
                return true;
            }
            return false;
        }

    }
}
