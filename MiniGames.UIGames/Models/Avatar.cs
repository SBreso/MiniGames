using System.ComponentModel;
using System.Runtime.CompilerServices;
using Color = System.Windows.Media.Color;

namespace MiniGames.UIGames.Models
{
    public enum AvatarEnum
    {
        C3PO = 0,
        CHEWACCA = 1,
        DARK_BAIDER = 2,
        DARK_SIRIUS = 3,
        HAN_SOLO = 4,
        JODA = 5,
        LEIA = 6,
        LUKE = 7,
        MANDALORIAN = 8,
        OBI_WAN = 9,
        R2D2 = 10,
        START_TROPPER = 11
    }

    public class Avatar :  IAvatar
    {
        public AvatarEnum AvatarEnum { get; set; }
        public string NickName { get; set; }
        public Color Color { get; set; }

        public bool IsAI { get; set; }

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
