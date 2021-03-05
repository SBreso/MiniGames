using MiniGames.Contracts;
using MiniGames.UIGames;
using MiniGames.UIGames.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MiniGames
{
    /// <summary>
    /// Lógica de interacción para NewPlayer.xaml
    /// </summary>
    public partial class ConfigPlayers : Window
    {
        IConfigPlayersViewModel ViewModel;
        List<ConfigPlayerControl> configPlayerControls;
        public IList<IPlayer> Players { get; internal set; }
        private IList<Avatar> avatarsSelected;
        public ConfigPlayers()
        {
            this.configPlayerControls = new List<UIGames.ConfigPlayerControl>();
            this.avatarsSelected = new List<Avatar>();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = (IConfigPlayersViewModel)this.DataContext;
            this.LoadCombos();
        }

        private void LoadCombos()
        {
            this.configPlayerControls.Clear();
            for (int i = 0; i < this.ViewModel.PlayersCount; i++)
            {
                var configPlayerControl = new ConfigPlayerControl();
                configPlayerControl.AvatarSelectedEvent += ConfigPlayerControl_AvatarSelectedEvent;
                configPlayerControl.Margin = new Thickness(5);
                this.Height += configPlayerControl.Height;
                this.configPlayerControls.Add(configPlayerControl);
                this.mainWrapPanel.Children.Add(configPlayerControl);
            }
        }

        private void ConfigPlayerControl_AvatarSelectedEvent(Avatar avatar)
        {
            this.avatarsSelected.Clear();
            foreach (var configPlayerControl in this.configPlayerControls)
            {
                var avatarSelected = ((ConfigPlayersViewModel)configPlayerControl.DataContext).AvatarSelected;
                if (avatarSelected != null) this.avatarsSelected.Add(avatarSelected);
            }
            foreach (var configPlayerControl in this.configPlayerControls)
            {
                configPlayerControl.DisableAvatar(this.avatarsSelected.Distinct().ToList());
            }
        }
    }
}
