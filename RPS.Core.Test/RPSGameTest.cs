using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPS.Core.Players;
using RPS.RandomValueGenerator.Abstract;
using RPS.Shared;
using System;

namespace RPS.Core.Test
{
    [TestClass]
    public class RPSGameTest
    {
        [TestMethod]
        public void PlayerOneHumanScissorsPlayerTwoComputer()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock
                mock.Mock<RPSPlayer>().Setup(h => h.SetSelection(Selection.Paper));
                var hum = mock.Create<Human>();

                mock.Mock<IRandomSelection>().Setup(x => x.Select()).Returns(Selection.Rock);
                var comp = mock.Create<Computer>();

                mock.Mock<IPlayRPSGame>().Setup(p => p.Throw(hum, comp)).Returns(Result.PlayerOneWon);
                var play = mock.Create<RPSGamePlayer>();

                // Act
                hum.SetSelection(Selection.Paper);
                comp.SetRandomValue();
                play.Throw(hum, comp);

                // Assert - assert on the mock
                Assert.IsTrue(Enum.IsDefined(typeof(Result), play.Throw(hum, comp)));
            }
        }

        [TestMethod]
        public void PlayerOneHumanPaperPlayerTwoComputerRock()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock
                mock.Mock<RPSPlayer>().Setup(h=>h.SetSelection(Selection.Paper));
                var hum = mock.Create<Human>();
                
                mock.Mock<IRandomSelection>().Setup(x => x.Select()).Returns(Selection.Rock);
                var comp = mock.Create<Computer>();

                mock.Mock<IPlayRPSGame>().Setup(p => p.Throw(hum, comp)).Returns(Result.PlayerOneWon);
                var play = mock.Create<RPSGamePlayer>();

                // Act
                hum.SetSelection(Selection.Paper);
                comp.SetRandomValue();
                play.Throw(hum, comp);

                // Assert - assert on the mock
                Assert.IsTrue(Result.PlayerOneWon == play.Throw(hum, comp));
                Assert.IsFalse(Result.PlayerTwoWon == play.Throw(hum, comp));
                Assert.IsFalse(Result.Draw == play.Throw(hum, comp));
            }
        }

        [TestMethod]
        public void PlayerOneHumanRockPlayerTwoComputerRock()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock
                mock.Mock<RPSPlayer>().Setup(h => h.SetSelection(Selection.Rock));
                var hum = mock.Create<Human>();

                mock.Mock<IRandomSelection>().Setup(x => x.Select()).Returns(Selection.Rock);
                var comp = mock.Create<Computer>();

                mock.Mock<IPlayRPSGame>().Setup(p => p.Throw(hum, comp)).Returns(Result.Draw);
                var play = mock.Create<RPSGamePlayer>();

                // Act
                hum.SetSelection(Selection.Rock);
                comp.SetRandomValue();
                play.Throw(hum, comp);

                // Assert - assert on the mock
                Assert.IsTrue(Result.Draw == play.Throw(hum, comp));
                Assert.IsFalse(Result.PlayerTwoWon == play.Throw(hum, comp));
                Assert.IsFalse(Result.PlayerOneWon == play.Throw(hum, comp));
            }
        }

        [TestMethod]
        public void PlayerOneHumanScissorsPlayerTwoComputerRock()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock
                mock.Mock<RPSPlayer>().Setup(h => h.SetSelection(Selection.Scissors));
                var hum = mock.Create<Human>();

                mock.Mock<IRandomSelection>().Setup(x => x.Select()).Returns(Selection.Rock);
                var comp = mock.Create<Computer>();

                mock.Mock<IPlayRPSGame>().Setup(p => p.Throw(hum, comp)).Returns(Result.PlayerTwoWon);
                var play = mock.Create<RPSGamePlayer>();

                // Act
                hum.SetSelection(Selection.Scissors);
                comp.SetRandomValue();
                play.Throw(hum, comp);

                // Assert - assert on the mock
                Assert.IsTrue(Result.PlayerTwoWon == play.Throw(hum, comp));
                Assert.IsFalse(Result.Draw == play.Throw(hum, comp));
                Assert.IsFalse(Result.PlayerOneWon == play.Throw(hum, comp));
            }
        }

        [TestMethod]
        public void PlayerOneComputerScissorsPlayerTwoComputerRock()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRandomSelection>().Setup(c => c.Select()).Returns(Selection.Scissors);
                var comp1 = mock.Create<Computer>();
                comp1.SetRandomValue();

                mock.Mock<IRandomSelection>().Setup(c => c.Select()).Returns(Selection.Rock);
                var comp2 = mock.Create<Computer>();
                comp2.SetRandomValue();

                mock.Mock<IPlayRPSGame>().Setup(p => p.Throw(comp1, comp2)).Returns(Result.PlayerOneWon);
                var play = mock.Create<RPSGamePlayer>();

                play.Throw(comp1, comp2);

                Assert.IsTrue(Result.PlayerTwoWon == play.Throw(comp1, comp2));
                Assert.IsFalse(Result.Draw == play.Throw(comp1, comp2));
                Assert.IsFalse(Result.PlayerOneWon == play.Throw(comp1, comp2));
            }
        }

        [TestMethod]
        public void PlayerOneComputerScissorsPlayerTwoComputerPaper()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRandomSelection>().Setup(c => c.Select()).Returns(Selection.Scissors);
                var comp1 = mock.Create<Computer>();
                comp1.SetRandomValue();

                mock.Mock<IRandomSelection>().Setup(c => c.Select()).Returns(Selection.Paper);
                var comp2 = mock.Create<Computer>();
                comp2.SetRandomValue();

                mock.Mock<IPlayRPSGame>().Setup(p => p.Throw(comp1, comp2)).Returns(Result.PlayerOneWon);
                var play = mock.Create<RPSGamePlayer>();

                play.Throw(comp1, comp2);

                Assert.IsTrue(Result.PlayerOneWon == play.Throw(comp1, comp2));
                Assert.IsFalse(Result.Draw == play.Throw(comp1, comp2));
                Assert.IsFalse(Result.PlayerTwoWon == play.Throw(comp1, comp2));
            }
        }
    }
}
