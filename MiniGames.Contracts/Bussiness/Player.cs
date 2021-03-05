using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MiniGames.Contracts.Bussiness
{

    public class Player : INotifyPropertyChanged, IPlayer
    {
        public AvatarEnum Avatar { get; set; }
        public bool IsAI { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
