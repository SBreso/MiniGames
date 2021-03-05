using MiniGames.Contracts;
using MiniGames.Contracts.Bussiness;
using System.Linq;
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

            var mainWindowViewModel = new MainWindowViewModel(this.unityContainer.ResolveAll<IGameCore>().ToList());
            var mainWindow = new MainWindow() { DataContext = mainWindowViewModel };
            mainWindow.Show();
        }

        private void RegisterOnContainer()
        {
            unityContainer = new UnityContainer();
            this.RegisterGameCore();
        }

        private void RegisterGameCore()
        {
            unityContainer.RegisterSingleton<IGameCore, ConnectCore>("Connect");
        }
    }
}
