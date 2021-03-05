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
        private readonly int _defaultSelectedAvatarIndex;

        public delegate void AvatarSelectedHandler();
        public event AvatarSelectedHandler AvatarSelectedEvent;
        public ConfigPlayerControl(int defaultSelectedAvatarIndex)
        {
            this._defaultSelectedAvatarIndex = defaultSelectedAvatarIndex;
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

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.avatarComboBox.SelectedIndex = this._defaultSelectedAvatarIndex;
        }
    }
}
