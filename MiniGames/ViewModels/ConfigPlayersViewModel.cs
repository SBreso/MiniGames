using MiniGames.Contracts;
using MiniGames.Contracts.Bussiness;
using MiniGames.UIGames.ViewModel;
using System.Collections.Generic;

namespace MiniGames
{
    public class ConfigPlayersViewModel
    {
        public int TotalPlayers { get; set; }
        public List<IPlayer> Players { get; set; }

        internal void FillPlayers(List<SelectAvatarControlViewModel> selectPlayerControls)
        {
            this.Players = new List<IPlayer>();
            foreach (var selectAvatarControlViewModel in selectPlayerControls)
            {
                this.Players.Add(new Player()
                {
                    Avatar = selectAvatarControlViewModel.AvatarSelected.AvatarEnum,
                    IsAI = selectAvatarControlViewModel.IsAI
                });
            }
        }
    }
}
