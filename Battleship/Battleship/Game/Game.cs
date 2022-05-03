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

            _display.Board(_boardSize, _board);

            _display.Message("Player 1 please enter your name! ");
            string player1Name = _input.Select();

            _display.Message("Player 2 please enter your name! ");
            string player2Name = _input.Select();

            player1 = new Player(player1Name);
            player2 = new Player(player2Name);

            for (int counter = 0; counter < 5; counter++)
            {
                _display.Ships(counter, player1);
                boardFactory.ManualPlacement(player1, _board, counter);
                _display.Ships(counter, player2);
                boardFactory.ManualPlacement(player2, _board, counter);
                
            }
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
