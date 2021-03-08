using MiniGames.UIGames.ViewModel;
using System.Windows.Controls;

namespace MiniGames.UIGames
{
    /// <summary>
    /// Lógica de interacción para ConfigPlayerControl.xaml
    /// </summary>
    public partial class SelectAvatarControl : UserControl
    {
        private readonly int _defaultSelectedIndex;

        public delegate void AvatarSelectedHandler();
        public event AvatarSelectedHandler AvatarSelectedEvent;
        
        public SelectAvatarControl(int defaultSelectedIndex)
        {
            this._defaultSelectedIndex = defaultSelectedIndex;
            InitializeComponent();            
        }

        private void ConfigPlayerControl_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("AvatarSelected"))
            {
                this.AvatarSelectedEvent();
            }
            
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ((ISelectAvatarControlViewModel)this.DataContext).PropertyChanged += ConfigPlayerControl_PropertyChanged;
            this.avatarComboBox.SelectedIndex = this._defaultSelectedIndex;
        }
    }
}
