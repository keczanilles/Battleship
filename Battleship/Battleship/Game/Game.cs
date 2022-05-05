using Battleship.Game;
using Battleship.Enum;
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
            
            PlacementPhase(boardFactory, _playerOne, _playerTwo);
            ShootingPhase(_playerOne, _playerTwo, _boardSize, _shootingBoard);
        }

        public string GetName(string player)
        {
            _display.Message($"{player} please enter your name!");
            return _input.Select();
        }

        public void PlacementPhase(BoardFactory boardFactory, Player playerOne, Player playerTwo)
        {
            for (int index = 0; index < 1; index++)
            {
                Display.Clear(2);
                _display.Board(playerOne, playerTwo, _boardSize, _placementBoard);
                _display.PlacementTurn(playerOne, (Enum.ShipType)index);
                boardFactory.ManualPlacement(playerOne, _placementBoard, (ShipType)index);
                Display.Clear(0);
                _display.Board(playerOne, playerTwo, _boardSize, _placementBoard);

                Display.Clear(2);
                _display.Board(playerTwo, playerOne, _boardSize, _placementBoard);
                _display.PlacementTurn(playerTwo, (Enum.ShipType)index);
                boardFactory.ManualPlacement(playerTwo, _placementBoard, (ShipType)index);
                Display.Clear(0);
                _display.Board(playerTwo, playerOne, _boardSize, _placementBoard);
            }
        }

        public void ShootingPhase(Player playerOne, Player playerTwo, int boardSize, Board shootingBoard)
        {
            while (true)
            {
                Display.Clear(2);
                _display.Board(playerOne, playerTwo, boardSize, shootingBoard);
                playerOne.Attack(playerTwo, boardSize);
                Display.Clear(0);
                _display.Board(playerOne, playerTwo, boardSize, shootingBoard);

                if (!IsGameOver(playerTwo))
                {
                    new Score(playerOne.Turn, playerOne.Name);
                    _display.Message($"{playerOne.Name} wins!");
                    break;
                }

                Display.Clear(2);
                _display.Board(playerTwo, playerOne, boardSize, shootingBoard);
                playerTwo.Attack(playerOne, boardSize);
                Display.Clear(0);
                _display.Board(playerTwo, playerOne, boardSize, shootingBoard);

                if (!IsGameOver(playerOne))
                {
                    new Score(playerTwo.Turn, playerTwo.Name);
                    _display.Message($"{playerTwo.Name} wins!");
                    break;
                }
            }
        }

        public bool IsGameOver(Player player)
        {
            player.IsOver();
            return player.IsAlive;
        }
    }
}
