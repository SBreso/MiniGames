using MiniGames.UIGames.Bussiness;
using MiniGames.UIGames.GameControls;
using System.Windows;
using Unity;

namespace MiniGames
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IUnityContainer unityContainer;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.RegisterOnContainer();

            var mainWindowViewModel = new MainWindowViewModel(this.unityContainer);
            var mainWindow = new MainWindow() { DataContext = mainWindowViewModel };
            mainWindow.Show();
        }

        private void RegisterOnContainer()
        {
            unityContainer = new UnityContainer();
            this.RegisterGameCore();
            this.RegisterUIGame();
        }


        private void RegisterGameCore()
        {
            unityContainer.RegisterSingleton<IGameCore, ConnectCore>("Connect");
        }

        private void RegisterUIGame()
        {
            unityContainer.RegisterSingleton<IConnectBoard, ConnectBoard>();
        }

    }
}
