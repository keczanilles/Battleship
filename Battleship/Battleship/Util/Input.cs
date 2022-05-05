using Battleship.Enum;

namespace Battleship.Util
{
    public class Input
    {
        public string Select()
        {
            new Display().InlineMessage("- ");
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
                    new Display().Message("Please provide a number between 10 and 20!", ConsoleColor.Red);
                }
                catch (FormatException)
                {
                    new Display().Message("Please provide a number between 10 and 20!", ConsoleColor.Red);
                }
            }
        }

        public Tuple<int, int, Direction> PlacementValidation()
        {
            while (true)
            {
                string input = Select();
                if (input.Length == 3 && Char.IsLetter(input[0]) && Char.IsDigit(input[1]) && Char.IsLetter(input[2]))
                {
                    int row = char.ToUpper(input[0]) - 65;
                    int col = (input[1] - '0') - 1;
                    Direction direction;
                    if (Char.ToUpper(input[2]) == 'H')
                    {
                        direction = Direction.Horizontal;
                    }
                    else if (Char.ToUpper(input[2]) == 'V')
                    {
                        direction = Direction.Vertical;
                    }
                    else
                    {
                        new Display().Message("Not valid direction!", ConsoleColor.Red);
                        continue;
                    }
                    return new Tuple<int, int, Direction>(row, col, direction);
                }
                else if (input.Length == 4 && Char.IsLetter(input[0]) && Char.IsDigit(input[1]) && Char.IsDigit(input[2]) && Char.IsLetter(input[3]))
                {
                    int row = char.ToUpper(input[0]) - 65;
                    int col = (((input[1] - '0') * 10) + (input[2] - '0')) - 1;
                    Direction direction;
                    if (Char.ToUpper(input[3]) == 'H')
                    {
                        direction = Direction.Horizontal;
                    }
                    else if (Char.ToUpper(input[3]) == 'V')
                    {
                        direction = Direction.Vertical;
                    }
                    else
                    {
                        new Display().Message("Not valid direction!", ConsoleColor.Red);
                        continue;
                    }
                    return new Tuple<int, int, Direction>(row, col, direction);
                }
                else
                {
                    new Display().Message("Not a valid option!", ConsoleColor.Red);
                }
            }
        }

        public Tuple<int, int> ShotValidation(List<Tuple<int, int>> shots, int boardSize)
        {
            while (true)
            {
                bool isOk = true;
                string input = Select();
                if (input.Length == 2 && char.IsLetter(input[0]) && char.IsDigit(input[1]))
                {
                    int row = char.ToUpper(input[0]) - 65;
                    int col = (input[1] - '0') - 1;
                    if (row < boardSize && col < boardSize && col >= 0)
                    {
                        foreach (Tuple<int, int> shot in shots)
                        {
                            if (row == shot.Item1 && col == shot.Item2)
                            {
                                isOk = false;
                            }
                        }
                        if (isOk)
                        {
                            return Tuple.Create(row, col);
                        }
                        else
                        {
                            new Display().Message("You have already tried this one!", ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        new Display().Message("Not valid option!", ConsoleColor.Red);
                    }
                }
                else if (input.Length == 3 && char.IsLetter(input[0]) && char.IsDigit(input[1]) && char.IsDigit(input[2]))
                {
                    int row = char.ToUpper(input[0]) - 65;
                    int col = (((input[1] - '0') * 10) + (input[2] - '0')) - 1;
                    if (row < boardSize && col < boardSize && col >= 0)
                    {
                        foreach (Tuple<int, int> shot in shots)
                        {
                            if (row == shot.Item1 && col == shot.Item2)
                            {
                                isOk = false;
                            }
                        }
                        if (isOk)
                        {
                            return Tuple.Create(row, col);
                        }
                        else
                        {
                            new Display().Message("You have already tried this one!", ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        new Display().Message("Not valid option!", ConsoleColor.Red);
                    }
                }
            }
        }
    }
}
