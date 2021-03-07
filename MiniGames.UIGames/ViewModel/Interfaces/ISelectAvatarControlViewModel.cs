using MiniGames.UIGames.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace MiniGames.UIGames.ViewModel
{
    public interface ISelectAvatarControlViewModel : INotifyPropertyChanged
    {
        Avatar AvatarSelected { get; }

        void DisableAvatar(IList<Avatar> selectedAvatars);
    }
}