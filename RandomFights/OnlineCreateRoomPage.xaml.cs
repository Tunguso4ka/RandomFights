using System.Windows;
using System.Net;
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

        private void AprSpellsCheckBoxAll_Checked(object sender, RoutedEventArgs e)
        {
            if(AprSpellsCheckBoxAll.IsChecked == true)
            {
                AprSpellsCheckBoxGrenade.IsChecked = true;
                AprSpellsCheckBoxPoison.IsChecked = true;
                AprSpellsCheckBoxSuperHPRegeneration.IsChecked = true;
                AprSpellsCheckBoxSuperStrengh.IsChecked = true;
                AprSpellsCheckBoxShield.IsChecked = true;
                AprSpellsCheckBoxXPIncreaser.IsChecked = true;
            }
            else
            {
                AprSpellsCheckBoxGrenade.IsChecked = false;
                AprSpellsCheckBoxPoison.IsChecked = false;
                AprSpellsCheckBoxSuperHPRegeneration.IsChecked = false;
                AprSpellsCheckBoxSuperStrengh.IsChecked = false;
                AprSpellsCheckBoxShield.IsChecked = false;
                AprSpellsCheckBoxXPIncreaser.IsChecked = false;
            }
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, SaveIsReal, isBetaOn, ScreenMode);
        }
    }
}
