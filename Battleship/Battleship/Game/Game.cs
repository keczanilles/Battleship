using Battleship.Game;
using Battleship.Util;

namespace Battleship.Gameplay
{
    public class Game : Program.Battleship
    {
        private Board _board;
        private Player _playerOne;
        private Player _playerTwo;
        private List<ShipType> _ships;

        public Game(int boardSize, int gameMode)
        {
            _boardSize = boardSize;
            _gameMode = gameMode;
            _board = new Board(_boardSize, _gameMode);
            _ships = new List<ShipType>()
            {
                ShipType.Carrier,
                ShipType.Battleship,
                ShipType.Cruiser,
                ShipType.Submarine,
                ShipType.Destroyer
            };

            Play();
        }

        public void Play()
        {
            var boardFactory = new BoardFactory();
            
            string playerOneName = GetName("Player 1");
            string playerTwoName = GetName("Player 2");

            _playerOne = new Player(playerOneName);
            _playerTwo = new Player(playerTwoName);

            _display.Board(_boardSize, _board);

            PlayerPlacement(boardFactory, _playerOne, _playerTwo);
        }

        public string GetName(string player)
        {
            _display.Message($"{player} please enter your name! ");
            return _input.Select();
        }

        public void PlayerPlacement(BoardFactory boardFactory, Player playerOne, Player playerTwo)
        {
            for (int counter = 0; counter < 5; counter++)
            {
                _display.PlacementTurn(counter, playerOne, _ships);
                boardFactory.ManualPlacement(playerOne, _board, _ships[counter]);
                _display.PlacementTurn(counter, playerTwo, _ships);
                boardFactory.ManualPlacement(playerTwo, _board, _ships[counter]);
            }
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
