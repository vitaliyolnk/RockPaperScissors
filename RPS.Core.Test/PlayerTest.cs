using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPS.Core.Players;
using RPS.RandomValueGenerator.Abstract;
using RPS.Shared;
using System;

namespace RPS.Core.Test
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayerHumanCanSelectRock()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<RPSPlayer>().Setup(p => p.SetSelection(Selection.Rock));
                var sut = mock.Create<Human>();

                sut.SetSelection(Selection.Rock);
                
                Assert.AreEqual(Selection.Rock, sut.PlaySelection);
            }
        }

        [TestMethod]
        public void PlayerHumanCanSelectPaper()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<RPSPlayer>().Setup(p => p.SetSelection(Selection.Paper));
                var sut = mock.Create<Human>();

                sut.SetSelection(Selection.Paper);

                Assert.AreEqual(Selection.Paper, sut.PlaySelection);
            }
        }

        [TestMethod]
        public void PlayerHumanCanSelectScissors()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<RPSPlayer>().Setup(p => p.SetSelection(Selection.Scissors));
                var sut = mock.Create<Human>();

                sut.SetSelection(Selection.Scissors);

                Assert.AreEqual(Selection.Scissors, sut.PlaySelection);
            }
        }


        [TestMethod]
        public void PlayerComputerSetsASelection()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRandomSelection>().Setup(x => x.Select());
                var sut = mock.Create<Computer>();

                sut.SetRandomValue();

                mock.Mock<IRandomSelection>().Verify(x => x.Select());
                Assert.IsTrue(Enum.IsDefined(typeof(Selection), sut.PlaySelection));
            }
        }

        [TestMethod]
        public void PlayerComputerSetsPaper()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRandomSelection>().Setup(x => x.Select()).Returns(Selection.Paper);
                var sut = mock.Create<Computer>();

                sut.SetRandomValue();

                mock.Mock<IRandomSelection>().Verify(x => x.Select());
                Assert.AreEqual(Selection.Paper, sut.PlaySelection);
            }
        }
    }
}
