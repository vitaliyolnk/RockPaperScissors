using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPS.WinUIClient.ViewModels;
using System.ComponentModel;
using Autofac.Extras.Moq;
using RPS.WinUIClient.ServiceContracts;
using RPS.WinUIClient.Services;
using RPS.Shared;
using RPS.WinUIClient;
using RPS.Core;
using RPS.RandomValueGenerator.Abstract;
using RPS.Core.Players;
using Moq;

namespace RPS.Client.Test
{
    [TestClass]
    public class PlayGameServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetPlayerOneHumanAndPlayerTwoHumanThrowsInvalidOperationException()
        {
            GameViewModel model = new GameViewModel();
            model.PlayerOne = PlayerType.Human;
            model.PlayerTwo = PlayerType.Human;
        }

        [TestMethod]
        public void ComputerVsComputer()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var gvmMock = new Mock<GameViewModel>();
                gvmMock.SetupAllProperties();
                var vm = gvmMock.Object;

                mock.Mock<IPlayGame>().Setup(x => x.PlayRPSComputerVsComputer(vm));
                var playGame = mock.Create<PlayGameService>();
                playGame.PlayRPSComputerVsComputer(vm);

                Assert.AreEqual(vm.Plays.Count, 1);
                Assert.AreEqual(vm.Plays[0].PlayNo, 1);
                Assert.IsTrue(Enum.IsDefined(typeof(Selection), vm.Plays[0].Player1Selection));
                Assert.IsTrue(Enum.IsDefined(typeof(Selection), vm.Plays[0].Player2Selection));
                Assert.AreEqual(vm.PlayerOne, PlayerType.Computer);
                Assert.AreEqual(vm.PlayerTwo, PlayerType.Computer);
            }
        }

        [TestMethod]
        public void HumanVsComputer()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var gvmMock = new Mock<GameViewModel>();
                gvmMock.SetupAllProperties();
                var vm = gvmMock.Object;
                vm.PlayerOne = PlayerType.Human;
                vm.PlayerTwo = PlayerType.Computer;

                mock.Mock<IPlayGame>().Setup(x => x.PlayRPSHumanVsComputer(vm, Selection.Paper));
                var playGame = mock.Create<PlayGameService>();
                playGame.PlayRPSHumanVsComputer(vm, Selection.Paper);

                Assert.AreEqual(vm.Plays.Count, 1);
                Assert.AreEqual(vm.Plays[0].PlayNo, 1);
                Assert.AreEqual(vm.Plays[0].Player1Selection, Selection.Paper);
                Assert.IsTrue(Enum.IsDefined(typeof(Selection), vm.Plays[0].Player2Selection));
                Assert.AreEqual(vm.PlayerOne, PlayerType.Human);
                Assert.AreEqual(vm.PlayerTwo, PlayerType.Computer);
            }
        }

        [TestMethod]
        public void ComputerVsHuman()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var gvmMock = new Mock<GameViewModel>();
                gvmMock.SetupAllProperties();
                var vm = gvmMock.Object;
                vm.PlayerOne = PlayerType.Computer;
                vm.PlayerTwo = PlayerType.Human;

                mock.Mock<IPlayGame>().Setup(x => x.PlayRPSHumanVsComputer(vm, Selection.Rock));
                var playGame = mock.Create<PlayGameService>();
                playGame.PlayRPSHumanVsComputer(vm, Selection.Rock);

                Assert.AreEqual(vm.Plays.Count, 1);
                Assert.AreEqual(vm.Plays[0].PlayNo, 1);
                Assert.IsTrue(Enum.IsDefined(typeof(Selection), vm.Plays[0].Player1Selection));
                Assert.AreEqual(vm.Plays[0].Player2Selection, Selection.Rock);
                Assert.AreEqual(vm.PlayerOne, PlayerType.Computer);
                Assert.AreEqual(vm.PlayerTwo, PlayerType.Human);
            }
        }
    }
}
