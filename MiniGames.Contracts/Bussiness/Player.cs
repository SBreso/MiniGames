using System.ComponentModel;
using System.Drawing;

namespace MiniGames.Contracts.Bussiness
{
    public class Player : INotifyPropertyChanged, IPlayer
    {

        public string Nickname { get; set; }

        public byte[] Avatar { get; set; }

        public Color Color { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
