namespace Battleship.Game
{
    public class Square
    {
        public (int,int) Position { get; set; }
        public SquareStatus _squareStatus;

        public Square((int,int) position)
        {
            _squareStatus = SquareStatus.Empty;
            Position = position;
        }
        public static string GetCharacter(SquareStatus status)
        {
            string empty = "🟦";
            string ship = "🚢";
            string hit = "🔥";
            string sunk = "⚓";
            string missed = "❌";
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