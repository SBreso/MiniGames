using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MiniGames.Contracts.Bussiness
{
    public abstract class GameCore : IGameCore
    {
        public const int ROW_COUNT = 7;
        public const int COLUMN_COUNT = 6;
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
                OnPropertyChanged("GameCoreMode");
            }
        }

        public IPlayer PlayerOnTurn
        {
            get => this.playerOnTurn;
            set
            {
                this.playerOnTurn = value;
                OnPropertyChanged("PlayerOnTurn");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void Run();
    }
}
