using MiniGames.Contracts;
using MiniGames.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiniGames
{
    /// <summary>
    /// Lógica de interacción para ConfigGame.xaml
    /// </summary>
    public partial class ConfigGame : Window
    {
        public IGameCore Game { get; set; }
        public ConfigGame()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            var configGameViewModel = (ConfigGameViewModel)this.DataContext;
            Game.PlayersCount = configGameViewModel.PlayersCount;
            Game.UseTimeLimit = configGameViewModel.UseTimeLimit;
            Game.TimeLimit = configGameViewModel.MaxTimeLimit;
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
