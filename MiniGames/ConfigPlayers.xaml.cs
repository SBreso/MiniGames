using MiniGames.Contracts;
using MiniGames.UIGames;
using MiniGames.UIGames.Models;
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
        public ConfigPlayers()
        {
            this.configPlayerControls = new List<UIGames.ConfigPlayerControl>();
            this.Players = new List<IPlayer>();
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
            for (int i = 0; i < this.ViewModel.TotalPlayers; i++)
            {
                var configPlayerControl = new ConfigPlayerControl(i);
                configPlayerControl.AvatarSelectedEvent += ConfigPlayerControl_AvatarSelectedEvent;
                configPlayerControl.Margin = new Thickness(5);
                this.Height += configPlayerControl.Height;
                this.configPlayerControls.Add(configPlayerControl);
                this.mainWrapPanel.Children.Add(configPlayerControl);
            }
        }

        private void ConfigPlayerControl_AvatarSelectedEvent()
        {
            var avatarsSelected = new List<Avatar>();
            foreach (var configPlayerControl in this.configPlayerControls)
            {
                var avatarSelected = ((ConfigPlayersViewModel)configPlayerControl.DataContext).AvatarSelected;
                if (avatarSelected != null) avatarsSelected.Add(avatarSelected);
            }
            foreach (var configPlayerControl in this.configPlayerControls)
            {
                configPlayerControl.DisableAvatar(avatarsSelected.Distinct().ToList());
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Players.Clear();
            foreach (var configPlayerControl in this.configPlayerControls)
            {
                var player = ((ConfigPlayersViewModel)configPlayerControl.DataContext).Player;
                if (player != null) this.Players.Add(player);
            }
            this.DialogResult = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
