using Unity;

namespace MiniGames.Contracts.Models
{
    public class BaseModel : IBaseModel
    {
        public IUnityContainer UnityContainer { get; protected set; }

        public BaseModel(IUnityContainer unityContainer)
        {
            this.UnityContainer = unityContainer;
        }
    }
}
