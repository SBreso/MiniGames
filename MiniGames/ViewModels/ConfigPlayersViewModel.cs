using MiniGames.UIGames.Models;
using MiniGames.UIGames.ViewModel;
using System.Collections.Generic;

namespace MiniGames
{
    public class ConfigPlayersViewModel
    {
        public int TotalPlayers { get; set; }
        public List<IAvatar> Players { get; set; }

        internal void FillPlayers(List<SelectAvatarControlViewModel> selectPlayerControls)
        {
            this.Players = new List<IAvatar>();
            foreach (var selectAvatarControlViewModel in selectPlayerControls)
            {
                this.Players.Add(selectAvatarControlViewModel.AvatarSelected);
            }
        }
    }
}
