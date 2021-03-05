using MiniGames.Contracts;

namespace MiniGames.UIGames.ViewModel
{
    public interface IConfigPlayersViewModel
    {
        IPlayer Player { get; }
        int TotalPlayers { get; }
    }
}