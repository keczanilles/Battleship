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
            
            PlacementPhase(boardFactory, _playerOne, _playerTwo);
            ShootingPhase(_playerOne, _playerTwo, _boardSize, _shootingBoard);
        }

        public string GetName(string player)
        {
            _display.Message($"{player} please enter your name! ");
            return _input.Select();
        }

        public void PlacementPhase(BoardFactory boardFactory, Player playerOne, Player playerTwo)
        {
            for (int index = 0; index < 5; index++)
            {
                Display.Clear(1);
                _display.Board(playerOne, playerTwo, _boardSize, _placementBoard, this);
                _display.PlacementTurn(playerOne, (ShipType)index);
                boardFactory.ManualPlacement(playerOne, _placementBoard, (ShipType)index);
                Display.Clear(1);
                _display.Board(playerOne, playerTwo, _boardSize, _placementBoard, this);

                Display.Clear(1);
                _display.Board(playerTwo, playerOne, _boardSize, _placementBoard, this);
                _display.PlacementTurn(playerTwo, (ShipType)index);
                boardFactory.ManualPlacement(playerTwo, _placementBoard, (ShipType)index);
                Display.Clear(1);
                _display.Board(playerTwo, playerOne, _boardSize, _placementBoard, this);
            }
        }

        public void ShootingPhase(Player _playerOne, Player _playerTwo, int _boardSize, Board _shootingBoard)
        {
            while (true)
            {
                Display.Clear(1);
                _display.Board(_playerOne, _playerTwo, _boardSize, _shootingBoard, this);
                _playerOne.Attack(_playerTwo);
                hasSunked(_playerOne);
                Display.Clear(1);
                _display.Board(_playerOne, _playerTwo, _boardSize, _shootingBoard, this);

                Display.Clear(1);
                _display.Board(_playerTwo, _playerOne, _boardSize, _shootingBoard, this);
                _playerTwo.Attack(_playerOne);
                hasSunked(_playerTwo);
                Display.Clear(1);
                _display.Board(_playerTwo, _playerOne, _boardSize, _shootingBoard, this);
            }
        }

        public bool hasSunked(Player player)
        {
            foreach (Ship ship in player.GetShips())
            {
                var hashSet = new HashSet<SquareStatus>();
                foreach (Square square in ship.GetSquares())
                {
                    hashSet.Add(square.GetSquareStatus());
                }
                if (hashSet.Count == 1 && hashSet.Contains(SquareStatus.Hit))
                {
                    foreach (Square square in ship.GetSquares())
                    {
                        square.ChangeStatus(SquareStatus.Sunk);
                    }
                    return true;
                }
            }
            return false;
        }

        public bool IsGameOver(Player player)
        {
            //var hashSet = new HashSet<SquareStatus>();
            //foreach (Ship ship in player.GetShips())
            //{
            //    foreach (Square square in ship.GetSquares())
            //    {
            //        hashSet.Add(square.GetSquareStatus());
            //    }
            //}
            //if (hashSet.Count == 1 && hashSet.Contains(SquareStatus.Sunk))
            //{
            //    return true;
            //}
            //return false;
            throw new NotImplementedException();
        }
    }
}
