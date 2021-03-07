using MiniGames.Contracts.Bussiness;

namespace MiniGames.UIGames.GameControls
{
    public interface IConnectBoard : IBaseBoard
    {
        ConnectCore GameCore { get; }
    }
}