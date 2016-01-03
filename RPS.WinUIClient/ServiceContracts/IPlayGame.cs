using RPS.Shared;
using RPS.WinUIClient.ViewModels;

namespace RPS.WinUIClient.ServiceContracts
{
    public interface IPlayGame
    {
        void PlayRPSHumanVsComputer(GameViewModel viewModel, Selection playerSelection);
        void PlayRPSComputerVsComputer(GameViewModel viewModel);
    }
}
