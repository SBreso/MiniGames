using System.ComponentModel;
using System.Drawing;

namespace MiniGames.Contracts
{
    public interface IPlayer
    {
        byte[] Avatar { get; set; }
        Color Color { get; set; }
        string Nickname { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}