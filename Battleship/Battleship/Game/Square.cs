namespace Battleship.Gameplay
{
    public class Square
    {
        public (int,int) Position { get; set; }
        public SquareStatus _squareStatus;

        public Square((int,int) position, SquareStatus status)
        {
            _squareStatus = status;
            Position = position;
        }

        public static string GetCharacter(SquareStatus status)
        {
            string empty = ".  ";
            string ship = "B  ";
            string hit = "H  ";
            string sunk = "S  ";
            string missed = "X  ";
            switch (status)
            {
                case SquareStatus.Empty:
                    return empty;
                case SquareStatus.Ship:
                    return ship;
                case SquareStatus.Hit:
                    return hit;
                case SquareStatus.Sunk:
                    return sunk;
                case SquareStatus.Missed:
                    return missed;
            }
            return empty;
        }
    }
}