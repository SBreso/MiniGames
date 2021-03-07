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
        List<SelectAvatarControlViewModel> selectPlayerControls;

        public ConfigPlayersViewModel ViewModel { get; private set; }

        public ConfigPlayers()
        {
            this.selectPlayerControls = new List<SelectAvatarControlViewModel>();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = (ConfigPlayersViewModel)this.DataContext;
            this.LoadSelectPlayers();
        }

        private void LoadSelectPlayers()
        {
            this.mainWrapPanel.Children.Clear();
            this.selectPlayerControls.Clear();
            for (int i = 0; i < this.ViewModel.TotalPlayers; i++)
            {
                var selectPlayerControlViewModel = new SelectAvatarControlViewModel();
                var configPlayerControl = new SelectAvatarControl(i) { DataContext = selectPlayerControlViewModel };
                configPlayerControl.AvatarSelectedEvent += ConfigPlayerControl_AvatarSelectedEvent;
                configPlayerControl.Margin = new Thickness(5);
                this.Height += configPlayerControl.Height;
                this.selectPlayerControls.Add(selectPlayerControlViewModel);
                this.mainWrapPanel.Children.Add(configPlayerControl);
            }
        }

        private void ConfigPlayerControl_AvatarSelectedEvent()
        {
            var avatarsSelected = new List<Avatar>();
            foreach (var selectPlayerControlDataContext in this.selectPlayerControls)
            {
                var avatarSelected = ((ISelectAvatarControlViewModel)selectPlayerControlDataContext).AvatarSelected;
                if (avatarSelected != null) avatarsSelected.Add(avatarSelected);
            }
            foreach (var selectPlayerControlDataContext in this.selectPlayerControls)
            {
                selectPlayerControlDataContext.DisableAvatar(avatarsSelected.Distinct().ToList());
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.FillPlayers(this.selectPlayerControls);
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
