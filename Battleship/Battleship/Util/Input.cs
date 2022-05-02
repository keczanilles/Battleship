namespace Battleship.Util
{
    public class Input
    {
        public string Select()
        {
            return Console.ReadLine();
        }

        public bool InputValidation(int possibilities, string input)
        {
            string[] inputNumber = new string[possibilities];
            for (int i = 0; i < possibilities; i++)
            {
                inputNumber[i] = (i + 1).ToString();
            }
            if (inputNumber.Contains(input))
            {
                return true;
            }
            return false;
        }

        public int BoardSizeValidation()
        {
            while (true)
            {
                string size = Select();
                try
                {
                    if (int.Parse(size) >= 10 && int.Parse(size) <= 20)
                    {
                        return int.Parse(size);
                    }
                    new Display().Message("Please provide a number between 10 and 20!");
                }
                catch (FormatException)
                {
                    new Display().Message("Please provide a number between 10 and 20!");
                }
            }
        }
    }
}
