using MiniGames.UIGames.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace MiniGames.UIGames.ViewModel
{
    public class SelectAvatarControlViewModel : ISelectAvatarControlViewModel
    {
        /// <summary>
        /// Event fired whenever a child property changes its value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsAI { get; set; }

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
            get
            {
                if (this.avatars == null)
                {
                    this.FillAvatars();
                }
                return this.avatars;
            }
            set
            {
                this.avatars = value;
            }
        }

        private Dictionary<AvatarEnum, Tuple<string, Color>> _avatarCast = new Dictionary<AvatarEnum, Tuple<string, Color>>()
        {
            {AvatarEnum.C3PO,new Tuple<string,Color>(GetPackAddress("c3po.png"),Color.FromRgb(213,37,127))},
            {AvatarEnum.CHEWACCA,new Tuple<string,Color>(GetPackAddress("chewacca.png"),Color.FromRgb(0,163,77)) },
            {AvatarEnum.DARK_BAIDER,new Tuple<string,Color>(GetPackAddress("darkBaider.png"),Color.FromRgb(162,34,53)) },
            {AvatarEnum.DARK_SIRIUS,new Tuple<string,Color>(GetPackAddress("darkSirius.png") ,Color.FromRgb(255,93,22)) },
            {AvatarEnum.HAN_SOLO,new Tuple<string,Color>(GetPackAddress("hanSolo.png"),Color.FromRgb(2,35,79)) },
            {AvatarEnum.JODA,new Tuple<string,Color>(GetPackAddress("joda.png"),Color.FromRgb(253, 247, 211)) },
            {AvatarEnum.LEIA,new Tuple<string,Color>(GetPackAddress("leia.png"),Color.FromRgb(220,189, 64)) },
            {AvatarEnum.LUKE,new Tuple<string,Color>(GetPackAddress("luke.png"),Color.FromRgb(8,83,157)) },
            {AvatarEnum.MANDALORIAN,new Tuple<string,Color>(GetPackAddress("mandalorian.png"),Color.FromRgb(121, 120, 116)) },
            {AvatarEnum.OBI_WAN,new Tuple<string,Color>(GetPackAddress("obiWan.png"),Color.FromRgb(190, 176,168)) },
            {AvatarEnum.R2D2,new Tuple<string,Color>(GetPackAddress("r2d2.png"),Color.FromRgb(240,96,63)) },
            {AvatarEnum.START_TROPPER,new Tuple<string,Color>(GetPackAddress("startTropper.png"),Color.FromRgb(117,129,142)) },
        };

        private static string GetPackAddress(string fileName)
        {
            return @$"{Directory.GetCurrentDirectory()}\Resources\Avatar\{fileName}";
        }

        public SelectAvatarControlViewModel()
        {
        }

        private void FillAvatars()
        {
            this.Avatars = new ObservableCollection<Avatar>();
            foreach (var player in this._avatarCast)
            {
                this.Avatars.Add(new Avatar()
                {
                    AvatarEnum = player.Key,
                    NickName = player.Key.ToString(),
                    ImagePath = player.Value.Item1,
                    Color = player.Value.Item2,
                    Enabled = true
                });
            }
        }

        public void DisableAvatar(IList<Avatar> avatarsSelected)
        {
            foreach (var avatar in this.avatars)
            {
                avatar.Enabled = !avatarsSelected.Any(av => av.AvatarEnum == avatar.AvatarEnum);
            }
        }

        /// <summary>
        /// Method called to fire a <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName"> The property name. </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
