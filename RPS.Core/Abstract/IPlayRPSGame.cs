
using RPS.Shared;

namespace RPS.Core
{
    public interface IPlayRPSGame
    {
        Result Throw(RPSPlayer playerOne, RPSPlayer playerTwo);
    }
}
