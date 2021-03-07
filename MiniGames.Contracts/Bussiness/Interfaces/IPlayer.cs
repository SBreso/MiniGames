using MiniGames.Contracts.Bussiness;
using System.ComponentModel;
using System.Drawing;

namespace MiniGames.Contracts
{
    public enum AvatarEnum
    {
        C3PO = 0,
        CHEWACCA = 1,
        DARK_BAIDER = 2,
        DARK_SIRIUS = 3,
        HAN_SOLO = 4,
        JODA = 5,
        LEIA = 6,
        LUKE = 7,
        MANDALORIAN = 8,
        OBI_WAN = 9,
        R2D2 = 10,
        START_TROPPER = 11
    }

    public interface IPlayer
    {
        AvatarEnum Avatar { get; set; }
        bool IsAI { get; set; }
    }
}