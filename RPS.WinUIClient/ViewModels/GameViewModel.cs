using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RPS.WinUIClient.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private PlayerType _playerTwo;
        private PlayerType _playerOne;
        private int _playerOneScore;
        private int _playerTwoScore;
        private ObservableCollection<Play> _palys = new ObservableCollection<Play>();
        private bool _computerVsComputer = true;
        private string _gameScore;

        public PlayerType PlayerOne
        {
            get
            {
                return _playerOne;
            }
            set
            {
                if (value != _playerOne)
                {
                    _playerOne = value;

                    if (_playerOne == PlayerType.Human && _playerTwo == PlayerType.Human)
                    {
                        throw new InvalidOperationException("One of the players must be Human or both Computers.");
                    }

                    NotifyPropertyChanged();
                }
            }
        }

        public PlayerType PlayerTwo
        {
            get
            {
                return _playerTwo;
            }
            set
            {
                if (value != _playerTwo)
                {
                    _playerTwo = value;

                    if (_playerTwo == PlayerType.Human && _playerOne == PlayerType.Human)
                    {
                        throw new InvalidOperationException("One of the players must be Human or both Computers.");
                    }

                    NotifyPropertyChanged();
                }
            }
        }

        public int PlayerOneScore
        {
            get { return _playerOneScore; }
            set
            {
                if (value != _playerOneScore)
                {
                    _playerOneScore = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int PlayerTwoScore
        {
            get { return _playerTwoScore; }
            set
            {
                if (value != _playerTwoScore)
                {
                    _playerTwoScore = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string GameScore
        {
            get { return _gameScore; }
            set
            {
                if (value != _gameScore)
                {
                    _gameScore = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<Play> Plays
        {
            get { return _palys; }
            set
            {
                if (value != _palys)
                {
                    _palys = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool ComputerVsComputer
        {
            get { return _computerVsComputer; }
            set
            {
                if (value != _computerVsComputer)
                {
                    _computerVsComputer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
