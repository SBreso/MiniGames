using MiniGames.Contracts;
using System.Collections.Generic;

namespace MiniGames
{
    public interface IMainWindowViewModel
    {
        IList<IGameCore> Games { get; }

    }
}