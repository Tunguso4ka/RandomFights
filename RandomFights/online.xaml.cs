using System.Windows;
using System.Windows.Controls;

namespace RandomFights
{
    public partial class online : Page
    {
        string AppLanguage, Name0, Name1;
        bool saveIsReal, enableSave, isBetaOn;
        int ScreenMode;
        public online(string appLanguage, bool SaveIsReal, bool EnableSave, bool IsBetaOn, int screenMode)
        {
            InitializeComponent();
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            AppLanguage = appLanguage;
            isBetaOn = IsBetaOn;
            ScreenMode = screenMode;
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn, ScreenMode);
        }
    }
}
