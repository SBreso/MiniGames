using System.Collections.Generic;
using System.ComponentModel;

namespace MiniGames.Contracts.Bussiness
{
    public abstract class GameCore : IGameCore
    {
        private IPlayer playerOnTurn;
        private GameCoreModeEnum gameCoreMode;

        public abstract int MinPlayers { get; }

        public abstract int MaxPlayers { get; }

        public abstract string Name { get; }

        public abstract bool CanUseTimeLimit { get; }

        public abstract byte[] Image { get; }

        public int PlayersCount { get; set; }

        public bool UseTimeLimit { get; set; }

        public abstract int MaxTimeLimit { get; }

        public int TimeLimit { get; set; }

        public IList<IPlayer> Players { get; set; }

        public GameCoreModeEnum GameCoreMode
        {
            get => this.gameCoreMode;
            set
            {
                this.gameCoreMode = value;
                RaisePropertyChangedEvent("GameCoreMode");
            }
        }

        public IPlayer PlayerOnTurn
        {
            get => this.playerOnTurn;
            set
            {
                this.playerOnTurn = value;
                RaisePropertyChangedEvent("PlayerOnTurn");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void Run();
    }
}
