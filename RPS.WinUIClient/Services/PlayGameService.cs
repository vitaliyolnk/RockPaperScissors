using Autofac;
using RPS.Core;
using RPS.Core.Players;
using RPS.RandomValueGenerator;
using RPS.RandomValueGenerator.Abstract;
using RPS.Shared;
using RPS.WinUIClient.ServiceContracts;
using RPS.WinUIClient.ViewModels;
using System.Linq;

namespace RPS.WinUIClient.Services
{
    public class PlayGameService : IPlayGame
    {
        static IContainer container { get; set; }
        int result;
        Play currentPlay;
        IRandomSelection _randomSelector;
        IPlayRPSGame _rpsGame;

        public PlayGameService()
        {
            ConfigureIoCContainer();
        }

        public void PlayRPSHumanVsComputer(GameViewModel viewModel, Selection playerSelection)
        {
            currentPlay = new Play();
            if (viewModel.PlayerOne == PlayerType.Human)
            {
                var player1 = new Human();
                player1.SetSelection(playerSelection);
                currentPlay.Player1Selection = playerSelection;
                var player2 = new Computer(_randomSelector);
                player2.SetRandomValue();
                currentPlay.Player2Selection = player2.PlaySelection;
                result = (int)_rpsGame.Throw(player1, player2);
            }
            else if (viewModel.PlayerTwo == PlayerType.Human)
            {
                var player1 = new Computer(_randomSelector);
                player1.SetRandomValue();
                currentPlay.Player1Selection = player1.PlaySelection;
                var player2 = new Human();
                player2.SetSelection(playerSelection);
                currentPlay.Player2Selection = playerSelection;
                result = (int)_rpsGame.Throw(player1, player2);
            }

            SetResultView(viewModel);
        }

        public void PlayRPSComputerVsComputer(GameViewModel viewModel)
        {
            currentPlay = new Play();
            var player1 = new Computer(_randomSelector);
            player1.SetRandomValue();
            currentPlay.Player1Selection = player1.PlaySelection;
            var player2 = new Computer(_randomSelector);
            player2.SetRandomValue();
            currentPlay.Player2Selection = player2.PlaySelection;
            result = (int)_rpsGame.Throw(player1, player2);

            SetResultView(viewModel);
        }

        private void SetResultView(GameViewModel viewModel)
        {
            Result res = (Result)result;

            switch (res)
            {
                case Result.PlayerOneWon:
                    viewModel.PlayerOneScore++;
                    currentPlay.Result = Resource.PlayerOneWon;
                    break;
                case Result.PlayerTwoWon:
                    viewModel.PlayerTwoScore++;
                    currentPlay.Result = Resource.PlayerTwoWon;
                    break;
                case Result.Draw:
                default:
                    currentPlay.Result = Resource.Draw;
                    break;
            }

            int playsCount = viewModel.Plays.Count;
            currentPlay.PlayNo = ++playsCount;
            viewModel.Plays.Add(currentPlay);
            viewModel.Plays.OrderBy(p => p.PlayNo);

            viewModel.GameScore = string.Format("{0} : {1}", viewModel.PlayerOneScore, viewModel.PlayerTwoScore);
        }

        private void ConfigureIoCContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RPSRandomSelection>().As<IRandomSelection>();
            builder.RegisterType<RPSGamePlayer>().As<IPlayRPSGame>();
            container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                _randomSelector = scope.Resolve<IRandomSelection>();
                _rpsGame = scope.Resolve<IPlayRPSGame>();
            }
        }
    }
}
