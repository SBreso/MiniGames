using MiniGames.UIGames.Bussiness;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MiniGames
{
    public interface IMainWindowViewModel
    {
        IList<IGameCore> Games { get; }

        UserControl GetUIGame(Type gameType);
    }
}