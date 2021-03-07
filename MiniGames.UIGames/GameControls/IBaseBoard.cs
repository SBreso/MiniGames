namespace MiniGames.UIGames.GameControls
{
    public interface IBaseBoard
    {
        void OnBoardLoaded();
        void OnContainerSizeChanged(double newHeight, double newWidth);
    }
}