using MiniGames.UIGames.Bussiness;
using MiniGames.UIGames.Extensions;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MiniGames
{
    public class ConfigGameViewModel
    {
        public ConfigGameViewModel(IGameCore game)
        {
            this.Name = game.Name;
            this.UseTimeLimit = game.UseTimeLimit;
            this.MinPlayers = game.MinPlayers;
            this.MaxPlayers = game.MaxPlayers;
            this.MaxTimeLimit = game.MaxTimeLimit;
            this.CanUseTimeLimit = game.CanUseTimeLimit;
            this.Image = new Image() { Source = game.Image.ToImageSource() };
            this.FillMaxPlayersItems();
            this.FillMaxTimeLimitItems();
        }

        public string Name { get; set; }

        public int MaxPlayers { get; set; }

        public int MinPlayers { get; set; }

        public int PlayersCount { get; set; }

        public List<int> MaxPlayersItems { get; set; }

        public bool UseTimeLimit { get; set; }

        public int MaxTimeLimit { get; set; }

        private double timeLimit;
        public double TimeLimit
        {
            get => this.timeLimit;
            set
            {
                timeLimit = value;
                MaxTimeLimit = (int)TimeSpan.FromMinutes(value).TotalMilliseconds;
            }
        }

        public List<double> MaxTimeLimitItems { get; set; }

        public bool CanUseTimeLimit { get; set; }

        public Image Image { get; set; }

        private void FillMaxPlayersItems()
        {
            this.MaxPlayersItems = new List<int>();
            for (int i = this.MinPlayers; i <= this.MaxPlayers; i++)
            {
                this.MaxPlayersItems.Add(i);
            }
        }

        private void FillMaxTimeLimitItems()
        {
            var minTimeInMilliseconds = 30000;
            var maxTimeInMinutes = TimeSpan.FromMilliseconds(this.MaxTimeLimit).TotalMinutes;
            this.MaxTimeLimitItems = new List<double>();
            for (int i = minTimeInMilliseconds; i <= this.MaxTimeLimit; i += minTimeInMilliseconds)
            {
                var minutes = TimeSpan.FromMilliseconds(i).TotalMinutes;
                this.MaxTimeLimitItems.Add(minutes);
            }
        }
    }
}
