using Battleship.Util;

namespace Battleship.Gameplay
{
    public class Game : Program.Battleship
    {
        private Board _board;

        public Game(int boardSize, int gameMode)
        {
            _boardSize = boardSize;
            _gameMode = gameMode;
            _board = new Board(_boardSize, _gameMode);
            Play();
        }

        public void Play()
        {
            _display.Board(_boardSize, _board);
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public void PlacementPhase(Player player)
        {

        }



    }
}
