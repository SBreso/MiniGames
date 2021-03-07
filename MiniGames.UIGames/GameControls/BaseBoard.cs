using System.Windows.Controls;

namespace MiniGames.UIGames.GameControls
{
    public abstract class BaseBoard : UserControl, IBaseBoard
    {
        public BaseBoard()
        {
            this.Loaded += BaseBoard_Loaded;
        }

        private void BaseBoard_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.OnBoardLoaded();
        }

        public abstract void OnBoardLoaded();

        public abstract void OnContainerSizeChanged(double newHeight, double newWidth);
    }
}
