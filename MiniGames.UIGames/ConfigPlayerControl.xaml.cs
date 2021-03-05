using MiniGames.UIGames.Models;
using MiniGames.UIGames.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MiniGames.UIGames
{
    /// <summary>
    /// Lógica de interacción para ConfigPlayerControl.xaml
    /// </summary>
    public partial class ConfigPlayerControl : UserControl
    {
        public delegate void AvatarSelectedHandler();
        public event AvatarSelectedHandler AvatarSelectedEvent;
        public ConfigPlayerControl()
        {
            InitializeComponent();
            ((ConfigPlayersViewModel)this.DataContext).PropertyChanged += ConfigPlayerControl_PropertyChanged;
        }

        private void ConfigPlayerControl_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("AvatarSelected"))
            {
                this.AvatarSelectedEvent();
            }
        }

        public void DisableAvatar(IList<Avatar> avatars)
        {
            ((ConfigPlayersViewModel)this.DataContext).DisableAvatar(avatars);
        }
    }
}
