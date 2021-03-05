using Unity;

namespace MiniGames.Contracts.Models
{
    public interface IBaseModel
    {
        IUnityContainer UnityContainer { get; }
    }
}