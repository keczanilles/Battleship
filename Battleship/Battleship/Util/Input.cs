namespace Battleship.Util
{
    public class Input
    {
        public string SelectMenu()
        {
            return Console.ReadLine();
        }

        public bool InputValidation(int length, string input)
        {
            int[] inputNumber = new int[length];
            for (int i = 0; i < length; i++)
            {
                inputNumber[i] = i+1;
            }
            if (inputNumber.Contains(int.Parse(input)))
            {
                return true;
            }
            return false;
        }
        public int BoardSizeValidation()
        {
            while (true)
            {
                string size = SelectMenu();
                try
                {
                    if (int.Parse(size) >=10 && int.Parse(size) <=20)
                    {
                        return int.Parse(size);
                    }
                    else
                    {
                        new Display().PrintMessage("Please provide a number between 10 and 20!");
                        continue;
                    }
                } catch (FormatException)
                {
                    new Display().PrintMessage("Please provide a number between 10 and 20!");
                }
            }
               
            
            
        }
        

    }
}
