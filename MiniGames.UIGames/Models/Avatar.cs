using MiniGames.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace MiniGames.UIGames.Models
{
    public class Avatar : INotifyPropertyChanged
    {
        public AvatarEnum AvatarEnum { get; set; }
        public string NickName { get; set; }
        public Color Color { get; set; }
        public string ImagePath { get; set; }
        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                OnPropertyChanged("Enabled");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
