using System.Collections.Generic;
using System.ComponentModel;

namespace MiniGames.Contracts
{
    public enum GameCoreModeEnum
    {
        Off = 0,
        On = 1
    };

    public interface IGameCore : INotifyPropertyChanged
    {
        GameCoreModeEnum GameCoreMode { get; set; }

        byte[] Image { get; }

        int MinPlayers { get; }

        int MaxPlayers { get; }

        int PlayersCount { get; set; }

        string Name { get; }

        IList<IPlayer> Players { get; set; }

        IPlayer PlayerOnTurn { get; set; }

        bool CanUseTimeLimit { get; }

        bool UseTimeLimit { get; set; }

        int MaxTimeLimit { get; }

        int TimeLimit { get; set; }


        void Run();
    }
}
