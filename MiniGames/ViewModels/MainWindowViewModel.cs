using MiniGames.UIGames.Bussiness;
using MiniGames.UIGames.GameControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Unity;

namespace MiniGames
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IUnityContainer _unityContainer;

        public IList<IGameCore> Games { get; private set; }

        public MainWindowViewModel(IUnityContainer unityContainer)
        {
            this._unityContainer = unityContainer;
            this.Games = this._unityContainer.ResolveAll<IGameCore>().ToList();
        }

        private Dictionary<Type, Type> uiGameCast = new Dictionary<Type, Type>()
        {
            {typeof(ConnectCore),typeof(IConnectBoard) }
        };

        public UserControl GetUIGame(Type gameType)
        {
            Type uiGameType;
            uiGameCast.TryGetValue(gameType, out uiGameType);
            return (UserControl)this._unityContainer.Resolve(uiGameType);
        }
    }
}
