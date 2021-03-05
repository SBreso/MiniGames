using MiniGames.Contracts;
using System.Collections.Generic;

namespace MiniGames.UIGames.ViewModel
{
    public interface IConfigPlayersViewModel
    {
        List<IPlayer> Players { get; }
        int PlayersCount { get; }
    }
}