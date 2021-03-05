using MiniGames.Contracts;
using System.Collections.Generic;

namespace MiniGames
{
    public class MainWindowViewModel: IMainWindowViewModel
    {
        public IList<IGameCore> Games { get; private set; }

        public MainWindowViewModel(IList<IGameCore> games)
        {
            this.Games = games;
        }

       
    }
}
