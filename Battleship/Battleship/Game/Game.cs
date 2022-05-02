namespace Battleship.Game
{
    public class Game
    {
        private bool _isOver;
        private int _boardSize;
        private int _gameMode;
        public Game(int boardSize, int gameMode)
        {
            _isOver = false;
            _boardSize = boardSize;
            _gameMode = gameMode;
            Board board = new Board(boardsize);
        }


        public void Play()
        {

        }
        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

    }
}
