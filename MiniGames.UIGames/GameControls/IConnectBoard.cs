using MiniGames.UIGames.Bussiness;

namespace MiniGames.UIGames.GameControls
{
    public interface IConnectBoard : IBaseBoard
    {
        ConnectCore GameCore { get; }
    }
}