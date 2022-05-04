using Battleship.Game;
using Battleship.Util;

namespace Battleship.Gameplay
{
    public class Game : Program.Battleship
    {
        private Board _placementBoard;
        private Board _shootingBoard;
        private Player _playerOne;
        private Player _playerTwo;

        public Game(int boardSize, int gameMode)
        {
            _boardSize = boardSize;
            _gameMode = gameMode;
            _placementBoard = new Board(_boardSize, _gameMode, true);
            _shootingBoard = new Board(_boardSize, _gameMode, false);

            Play();
        }

        public void Play()
        {
            var boardFactory = new BoardFactory();

            string playerOneName = GetName("Player 1");
            _display.NewLine();
            string playerTwoName = GetName("Player 2");
            Display.Clear(1);

            _playerOne = new Player(playerOneName);
            _playerTwo = new Player(playerTwoName);
            
            PlayerPlacement(boardFactory, _playerOne, _playerTwo);
            _playerOne.Attack(_playerTwo);
            _playerOne.Attack(_playerTwo);
            _display.Board(_playerOne, _playerTwo, _boardSize, _placementBoard);
            _display.Board(_playerTwo, _playerOne, _boardSize, _placementBoard);
            Console.ReadLine();

        }

        public string GetName(string player)
        {
            _display.Message($"{player} please enter your name! ");
            return _input.Select();
        }

        public void PlayerPlacement(BoardFactory boardFactory, Player playerOne, Player playerTwo)
        {
            for (int index = 0; index < 1; index++)
            {
                Display.Clear(1);
                _display.Board(playerOne, playerTwo, _boardSize, _placementBoard);
                _display.PlacementTurn(playerOne, (ShipType)index);
                boardFactory.ManualPlacement(playerOne, _placementBoard, (ShipType)index);
                Display.Clear(1);
                _display.Board(playerOne, playerTwo, _boardSize, _placementBoard);

                Display.Clear(1);
                _display.Board(playerTwo, playerOne, _boardSize, _placementBoard);
                _display.PlacementTurn(playerTwo, (ShipType)index);
                boardFactory.ManualPlacement(playerTwo, _placementBoard, (ShipType)index);
                Display.Clear(1);
                _display.Board(playerTwo, playerOne, _boardSize, _placementBoard);
            }
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
