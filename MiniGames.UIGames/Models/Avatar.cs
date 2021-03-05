using MiniGames.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace MiniGames.UIGames.Models
{
    public class Avatar : INotifyPropertyChanged
    {
        public AvatarEnum AvatarEnum { get; set; }
        public string NickName { get; set; }
        public Color Color { get; set; }
        public string Image { get; set; }
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

        public static Dictionary<AvatarEnum, Tuple<string, Color>> AvatarCast = new Dictionary<AvatarEnum, Tuple<string, Color>>()
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

        public static Avatar GetAvatar(AvatarEnum avatarEnum)
        {
            Tuple<string, Color> tuple;
            AvatarCast.TryGetValue(avatarEnum, out tuple);
            return new Avatar()
            {
                AvatarEnum = avatarEnum,
                Color = tuple.Item2,
                Image = tuple.Item1,
                NickName = avatarEnum.ToString()
            };
        }
    }
}
