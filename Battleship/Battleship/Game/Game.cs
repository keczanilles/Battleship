using Battleship.Util;

namespace Battleship.Game
{
    public class Game
    {
        private bool _isOver;
        private int _boardSize;
        private int _gameMode;
        private Board _board;
        public Game(int boardSize, int gameMode)
        {
            _isOver = false;
            _boardSize = boardSize;
            _gameMode = gameMode;
            _board = new Board(boardSize);
        }


        public void Play()
        {
            new Display().PrintBoard(_boardSize, _board);
        }
        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

    }
}
