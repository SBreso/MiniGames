using MiniGames.Contracts;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MiniGames
{
    internal static class CommonUtils
    {
        public static Image GetIconGame(IGameCore game)
        {
            using (var ms = new System.IO.MemoryStream(game.Image))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return new System.Windows.Controls.Image
                {
                    Source = image
                };
            }
        }
    }
}
