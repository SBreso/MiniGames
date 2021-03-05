using MiniGames.Contracts;
using MiniGames.Contracts.Bussiness;
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
    public class ConfigPlayersViewModel : IConfigPlayersViewModel
    {
        /// <summary>
        /// Event fired whenever a child property changes its value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
                OnPropertyChanged();
            }
        }

        public int TotalPlayers { get; protected set; }
        public IPlayer Player { get; private set; }

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
                this.UpdatePlayer();
                OnPropertyChanged();
            }
        }

        public bool isAI;
        public bool IsAI
        {
            get => this.isAI;
            set
            {
                this.IsAI = value;
                this.UpdatePlayer();
                OnPropertyChanged();
            }
        }

        public ConfigPlayersViewModel(int totalPlayers)
        {
            this.TotalPlayers = totalPlayers;
        }

        public ConfigPlayersViewModel()
        {
        }

        private void FillAvatars()
        {
            this.Avatars = new ObservableCollection<Avatar>();
            foreach (var player in Avatar.AvatarCast)
            {
                this.Avatars.Add(new Avatar() { AvatarEnum = player.Key, NickName = player.Key.ToString(), Image = player.Value.Item1, Color = player.Value.Item2, Enabled = true });
            }
        }

        internal void DisableAvatar(IList<Avatar> avatarsSelected)
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

        private void UpdatePlayer()
        {
            this.Player = new Player()
            {
                Avatar = this.avatarSelected.AvatarEnum,
                IsAI = this.IsAI
            };
        }
    }


}
