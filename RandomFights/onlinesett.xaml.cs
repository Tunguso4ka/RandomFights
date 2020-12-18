using System.Windows;
using System.Windows.Controls;

namespace RandomFights
{
    /// <summary>
    /// Interaction logic for onlinesett.xaml
    /// </summary>
    public partial class onlinesett : Page
    {
        string AppLanguage, Name0, Name1;
        bool saveIsReal, enableSave, isBetaOn;
        public onlinesett(string appLanguage, bool SaveIsReal, bool EnableSave, bool IsBetaOn)
        {
            InitializeComponent();
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            AppLanguage = appLanguage;
            isBetaOn = IsBetaOn;
        }
        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn);
        }
    }
}
