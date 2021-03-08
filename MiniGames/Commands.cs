using MiniGames.UIGames.Bussiness;
using System.Windows.Input;

namespace MiniGames
{
    public static class Commands
    {
        public static RoutedUICommand GetRoutedUIConfigGameCommand(IGameCore gameCore, int index)
        {
            return new RoutedUICommand(
            $"Config {gameCore.Name}",//descripcion
            "Config",//accion
            typeof(Commands),
            new InputGestureCollection()
            {
                new KeyGesture((Key)(90+index),ModifierKeys.Control)
            }
            );
        }

    }
}
