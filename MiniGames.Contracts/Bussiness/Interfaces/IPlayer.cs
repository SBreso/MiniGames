using MiniGames.Contracts.Bussiness;
using System.ComponentModel;
using System.Drawing;

namespace MiniGames.Contracts
{
    public enum AvatarEnum
    {
        C3PO,
        CHEWACCA,
        DARK_BAIDER,
        DARK_SIRIUS,
        HAN_SOLO,
        JODA,
        LEIA,
        LUKE,
        MANDALORIAN,
        OBI_WAN,
        R2D2,
        START_TROPPER
    }

    public interface IPlayer
    {
        AvatarEnum Avatar { get; set; }
        bool IsAI { get; set; }
    }
}