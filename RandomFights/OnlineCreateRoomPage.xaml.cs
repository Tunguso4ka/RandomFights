using System.Windows;
using System.Windows.Controls;

namespace RandomFights
{
    /// <summary>
    /// Interaction logic for OnlineCreateRoomPage.xaml
    /// </summary>
    public partial class OnlineCreateRoomPage : Page
    {
        string AppLanguage;
        bool SaveIsReal, isBetaOn;
        int ScreenMode;

        public OnlineCreateRoomPage(string appLanguage, bool saveIsReal, bool IsBetaOn, int screenMode)
        {
            InitializeComponent();
            AppLanguage = appLanguage;
            SaveIsReal = saveIsReal;
            isBetaOn = IsBetaOn;
            ScreenMode = screenMode;
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, SaveIsReal, isBetaOn, ScreenMode);
        }
    }
}
