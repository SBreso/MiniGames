using MiniGames.Contracts;
using MiniGames.UIGames.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MiniGames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGameCore selectedGame;
        private bool existGameRunning => this.selectedGame?.GameCoreMode == GameCoreModeEnum.On;

        public IMainWindowViewModel ViewModel { get; private set; }

        private IList<CommandBinding> playGameCommands = new List<CommandBinding>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel = (IMainWindowViewModel)this.DataContext;
            FillMenuNew();
        }

        private void FillMenuNew()
        {
            this.menuNew.Items.Clear();
            this.playGameCommands.Clear();
            var games = this.ViewModel.Games;
            var index = 0;
            foreach (var game in games)
            {
                var command = Commands.GetRoutedUIConfigGameCommand(game, index++);
                this.playGameCommands.Add(new CommandBinding(command, ExecutedConfigGameCommand, CanExecuteConfigGameCommand));
                MenuItem gameMenuItem = new MenuItem()
                {
                    Header = game.Name,
                    Command = command,
                    CommandParameter = game,
                    Icon = CommonUtils.GetIconGame(game)
                };
                this.menuNew.Items.Add(gameMenuItem);
            }
            this.CommandBindings.AddRange((System.Collections.ICollection)this.playGameCommands);
        }

        private void CanExecuteConfigGameCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !this.existGameRunning;
        }

        private void ExecutedConfigGameCommand(object sender, ExecutedRoutedEventArgs e)
        {
            this.selectedGame = (IGameCore)e.Parameter;
            this.ShowConfigGame();
        }

        private void ShowConfigGame()
        {
            var configGameViewModel = new ConfigGameViewModel(this.selectedGame);
            var configGame = new ConfigGame() { Game = this.selectedGame, DataContext = configGameViewModel };
            configGame.Owner = this;
            configGame.ShowDialog();
            if (configGame.DialogResult ?? true)
            {
                this.selectedGame = configGame.Game;
                FillPlayers();
            }
        }

        private void FillPlayers()
        {
            var configPlayersViewModel = new ConfigPlayersViewModel(this.selectedGame.PlayersCount);
            var configPlayers = new ConfigPlayers() { DataContext = configPlayersViewModel };
            configPlayers.ShowDialog();
            if (configPlayers.DialogResult ?? true)
            {
                this.selectedGame.Players = configPlayers.Players;
                this.LoadSelectedGame();
            }
        }

        private void LoadSelectedGame()
        {
            MessageBox.Show("Loading...");
        }
    }
}
