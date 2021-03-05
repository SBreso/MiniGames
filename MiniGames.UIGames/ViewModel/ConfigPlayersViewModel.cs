using MiniGames.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MiniGames.UIGames.ViewModel
{
    public enum AvatarEnum
    {
        C3PO,
        CHEWACCA,
        DARK_BAIDER,
        DARK_SIRIUS,
        HAN_SOLO,
        JODA,
        LEIA,
        LUKE,
        MANDALORIAN,
        OBI_WAN,
        R2D2,
        START_TROPPER
    }

    public class ConfigPlayersViewModel: IConfigPlayersViewModel
    {
        private Dictionary<AvatarEnum, Tuple<string, Color>> playerCast = new Dictionary<AvatarEnum, Tuple<string, Color>>()
        {
            {AvatarEnum.C3PO,new Tuple<string,Color>(GetPackAddress("c3po.png"),Colors.Violet) },
            {AvatarEnum.CHEWACCA,new Tuple<string,Color>(GetPackAddress("chewacca.png"),Colors.Green) },
            {AvatarEnum.DARK_BAIDER,new Tuple<string,Color>(GetPackAddress("darkBaider.png"),Colors.Red) },
            {AvatarEnum.DARK_SIRIUS,new Tuple<string,Color>(GetPackAddress("darkSirius.png") ,Colors.DarkViolet) },
            {AvatarEnum.HAN_SOLO,new Tuple<string,Color>(GetPackAddress("hanSolo.png"),Colors.DarkBlue) },
            {AvatarEnum.JODA,new Tuple<string,Color>(GetPackAddress("joda.png"),Colors.Beige) },
            {AvatarEnum.LEIA,new Tuple<string,Color>(GetPackAddress("leia.png"),Colors.Yellow) },
            {AvatarEnum.LUKE,new Tuple<string,Color>(GetPackAddress("luke.png"),Colors.Blue) },
            {AvatarEnum.MANDALORIAN,new Tuple<string,Color>(GetPackAddress("mandalorian.png"),Colors.Gray) },
            {AvatarEnum.OBI_WAN,new Tuple<string,Color>(GetPackAddress("obiWan.png"),Colors.Silver) },
            {AvatarEnum.R2D2,new Tuple<string,Color>(GetPackAddress("r2d2.png"),Colors.Orange) },
            {AvatarEnum.START_TROPPER,new Tuple<string,Color>(GetPackAddress("startTropper.png"),Colors.LightGray) },
        };

       
        private static string GetPackAddress(string fileName)
        {
            return @$"{Directory.GetCurrentDirectory()}\Resources\{fileName}";
        }

        public List<IPlayer> Players { get; private set; }

        public ConfigPlayersViewModel(int totalPlayers)
        {
            this.PlayersCount = totalPlayers;
            this.FillAvatars();
        }

        public ConfigPlayersViewModel()
        {
            this.FillAvatars();
        }

        private void FillAvatars()
        {
            this.Avatars = new ObservableCollection<Avatar>();
            foreach (var player in playerCast)
            {
                this.Avatars.Add(new Avatar() { AvatarEnum = player.Key, NickName = player.Key.ToString(), Image = player.Value.Item1, Color = player.Value.Item2, Enabled = true });
            }
        }

        internal void DisableAvatar(IList<Avatar> avatars)
        {
            foreach (var avatar in this.avatars)
            {
                avatar.Enabled = !avatars.Any(av => av.AvatarEnum == avatar.AvatarEnum);
            }
        }

        /// <summary>
        /// Event fired whenever a child property changes its value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method called to fire a <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName"> The property name. </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Avatar avatarSelected;
        public Avatar AvatarSelected
        {
            get
            {
                return avatarSelected;
            }
            set
            {
                avatarSelected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Avatar> avatars;
        public ObservableCollection<Avatar> Avatars
        {
            get => this.avatars;
            set
            {
                this.avatars = value;
                OnPropertyChanged();
            }
        }

        public int PlayersCount { get; protected set; }
    }

    public class Avatar
    {
        public AvatarEnum AvatarEnum { get; set; }
        public string NickName { get; set; }
        public Color Color { get; set; }
        public string Image { get; set; }
        public bool Enabled { get; set; }
    }
}
