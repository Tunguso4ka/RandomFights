using System;
using System.Windows;
using System.IO;

namespace RandomFights
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string AppLanguage, UserLogin;
        bool saveIsReal, isBetaOn, RFUIsConected, RFUIsLoged;
        int ScreenMode;
        string gameSavePath = Environment.CurrentDirectory + "/gameSave.dat", settPath = Environment.CurrentDirectory + "/settings.dat";
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                searchSettings();
            }
            catch
            {
                AppLanguage = "eng";
                saveIsReal = false;
                ScreenMode = 2;
            }
            ScreenChange();
            frame0.Content = new mainmenu(AppLanguage, saveIsReal, isBetaOn, ScreenMode);
        }
        void searchSettings()
        {
            if(File.Exists(settPath))
            {
                BinaryReader BinaryReader = new BinaryReader(File.OpenRead(settPath));
                AppLanguage = BinaryReader.ReadString();
                isBetaOn = BinaryReader.ReadBoolean();
                ScreenMode = BinaryReader.ReadInt32();
                BinaryReader.Dispose();
            }
            else
            {
                AppLanguage = "eng";
            }

            if (File.Exists(gameSavePath))
            {
                saveIsReal = true;
            }
            else
            {
                saveIsReal = false;
            }
        }

        void ScreenChange()
        {
            if (ScreenMode == 0)
            {
                Visibility = Visibility.Collapsed;
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                Topmost = true;
                Visibility = Visibility.Visible;
            }
            else if (ScreenMode == 1)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
                Topmost = false;
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
                Topmost = false;
            }
        }
    }
}
