using RPS.RandomValueGenerator.Abstract;
using RPS.Shared;

namespace RPS.Core.Players
{
    public class Computer : RPSPlayer
    {
        private IRandomSelection _randomeSelection;

        public Computer(IRandomSelection randomeSelection)
        {
            _randomeSelection = randomeSelection;
        }

        public void SetRandomValue()
        {
           base.SetSelection((Selection)_randomeSelection.Select());
        }
    }
}
