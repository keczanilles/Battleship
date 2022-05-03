using Battleship.Game;
using Battleship.Util;

namespace Battleship.Gameplay
{
    public class Game : Program.Battleship
    {
        private Board _board;
        private Player player1;
        private Player player2;

        public Game(int boardSize, int gameMode)
        {
            _boardSize = boardSize;
            _gameMode = gameMode;
            _board = new Board(_boardSize, _gameMode);
            Play();
        }

        public void Play()
        {
            var boardFactory = new BoardFactory();

            player1 = new Player();
            player2 = new Player();

            boardFactory.ManualPlacement(player1, _board);
            boardFactory.ManualPlacement(player2, _board);

            _display.Board(_boardSize, _board);
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
