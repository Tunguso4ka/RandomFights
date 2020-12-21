using System.Net;
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
        int ScreenMode;
        public onlinesett(string appLanguage, bool SaveIsReal, bool EnableSave, bool IsBetaOn, int screenMode)
        {
            InitializeComponent();
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            AppLanguage = appLanguage;
            isBetaOn = IsBetaOn;
            ScreenMode = screenMode;
            SetThisIP();
        }
        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn, ScreenMode);
        }

        void SetThisIP()
        {
            IPHostEntry ip = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress IPAddress in ip.AddressList)
            {
                if (IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    YIPTextBox1.Text = IPAddress.ToString();
                }
            }
        }

        private void FIPTB1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(FIPTB1.Text.Length > 12)
            {
                int RemoveCount = FIPTB1.Text.Length - 12;
                FIPTB1.Text = FIPTB1.Text.Remove(FIPTB1.Text.Length - RemoveCount);
            }
        }
    }
}
