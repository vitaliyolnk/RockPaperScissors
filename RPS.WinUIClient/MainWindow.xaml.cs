using Autofac;
using RPS.RandomValueGenerator;
using RPS.RandomValueGenerator.Abstract;
using RPS.Shared;
using RPS.WinUIClient.ServiceContracts;
using RPS.WinUIClient.Services;
using RPS.WinUIClient.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace RPS.WinUIClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameViewModel game;
        BindingList<GameViewModel> playersList;
        IPlayGame playGame;

        public MainWindow()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void btnHuman1_Click(object sender, RoutedEventArgs e)
        {
            InitializeControls();
            game.PlayerOne = PlayerType.Human;
            game.PlayerTwo = PlayerType.Computer;
            game.ComputerVsComputer = false;
        }

        private void btnComputer1_Click(object sender, RoutedEventArgs e)
        {
            InitializeControls();
            game.PlayerOne = PlayerType.Computer;
            if (game.PlayerTwo == PlayerType.Computer) game.ComputerVsComputer = true;
            else game.ComputerVsComputer = false;
        }

        private void btnHuman2_Click(object sender, RoutedEventArgs e)
        {
            InitializeControls();
            game.PlayerOne = PlayerType.Computer;
            game.PlayerTwo = PlayerType.Human;
            game.ComputerVsComputer = false;
        }

        private void btnComputer2_Click(object sender, RoutedEventArgs e)
        {
            InitializeControls();
            game.PlayerTwo = PlayerType.Computer;
            if (game.PlayerOne == PlayerType.Computer) game.ComputerVsComputer = true;
            else game.ComputerVsComputer = false;

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            InitializeControls();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (game.ComputerVsComputer)
            {
                playGame.PlayRPSComputerVsComputer(game);
            }
        }

        private void btnRock1_Click(object sender, RoutedEventArgs e)
        {
            if (game.PlayerOne != PlayerType.Computer)
            {
                playGame.PlayRPSHumanVsComputer(game, Selection.Rock);
            }
        }

        private void btnPaper1_Click(object sender, RoutedEventArgs e)
        {
            if (game.PlayerOne != PlayerType.Computer)
            {
                playGame.PlayRPSHumanVsComputer(game, Selection.Paper);
            }
        }

        private void btnScissors1_Click(object sender, RoutedEventArgs e)
        {
            if (game.PlayerOne != PlayerType.Computer)
            {
                playGame.PlayRPSHumanVsComputer(game, Selection.Scissors);
            }

        }

        private void btnRock2_Click(object sender, RoutedEventArgs e)
        {
            if (game.PlayerTwo != PlayerType.Computer)
            {
                playGame.PlayRPSHumanVsComputer(game, Selection.Rock);
            }
        }

        private void btnPaper2_Click(object sender, RoutedEventArgs e)
        {
            if (game.PlayerTwo != PlayerType.Computer)
            {
                playGame.PlayRPSHumanVsComputer(game, Selection.Paper);
            }
        }

        private void btnScissors2_Click(object sender, RoutedEventArgs e)
        {
            if (game.PlayerTwo != PlayerType.Computer)
            {
                playGame.PlayRPSHumanVsComputer(game, Selection.Scissors);
            }
        }

        private void InitializeControls()
        {
            game = new GameViewModel();
            playersList = new BindingList<GameViewModel>();
            playGame = new PlayGameService();
            playersList.Add(game);
            DataContext = playersList;
        }
    }
}
