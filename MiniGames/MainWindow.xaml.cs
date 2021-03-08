using MiniGames.UIGames.Bussiness;
using MiniGames.UIGames.CustomControls;
using MiniGames.UIGames.Extensions;
using MiniGames.UIGames.GameControls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private UserControl _baseBoard;

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
                    Icon = new Image() { Source = game.Image.ToImageSource() }
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
            var configPlayerViewModel = new ConfigPlayersViewModel()
            {
                TotalPlayers = this.selectedGame.PlayersCount
            };
            var configPlayers = new ConfigPlayers() { DataContext = configPlayerViewModel };
            configPlayers.ShowDialog();
            if (configPlayers.DialogResult ?? true)
            {
                this.selectedGame.Players = ((ConfigPlayersViewModel)configPlayers.DataContext).Players;
                this.LoadAvatarPanel();
                this.LoadSelectedGame();
            }
            else
            {
                this.ShowConfigGame();
            }
        }

        private void LoadAvatarPanel()
        {
            var playersPanel = (DockPanel)Application.Current.MainWindow.FindName("players");
            var avatarListControl = new AvatarListControl() { DataContext = this.selectedGame };
            avatarListControl.Loaded += AvatarListControl_Loaded;
            playersPanel.Children.Clear();
            playersPanel.Children.Add(avatarListControl);
        }

        private void AvatarListControl_Loaded(object sender, RoutedEventArgs e)
        {
            var table = (Grid)Application.Current.MainWindow.FindName("table");
            var playersPanel = (DockPanel)Application.Current.MainWindow.FindName("players");
            table.Height = playersPanel.Height;
        }

        private void LoadSelectedGame()
        {
            var table = (Grid)Application.Current.MainWindow.FindName("table");
            this._baseBoard = this.ViewModel.GetUIGame(this.selectedGame.GetType());
            this._baseBoard.DataContext = this.selectedGame;
            table.Children.Clear();
            table.Children.Add(this._baseBoard);
        }

        private void table_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this._baseBoard != null)
            {
                ((IBaseBoard)this._baseBoard).OnContainerSizeChanged(e.NewSize.Height, e.NewSize.Width);
            }

        }

        private void players_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
