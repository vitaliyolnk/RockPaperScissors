
using RPS.Shared;

namespace RPS.Core
{
    public abstract class RPSPlayer
    {
        public Selection PlaySelection { get; private set; }

        public virtual void SetSelection(Selection selection)
        {
            PlaySelection = selection;
        }
    }
}
