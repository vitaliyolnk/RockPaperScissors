
using RPS.Shared;

namespace RPS.Core
{
    public class RPSGamePlayer : IPlayRPSGame
    {
        public Result Throw(RPSPlayer playerOne, RPSPlayer playerTwo)
        {
            if (playerOne.PlaySelection == playerTwo.PlaySelection) return Result.Draw;
            return ((int)playerTwo.PlaySelection + 1) % 3 == (int)playerOne.PlaySelection
                ? Result.PlayerOneWon
                : Result.PlayerTwoWon;
        }
    }
}
