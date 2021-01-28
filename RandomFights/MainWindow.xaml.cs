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
        bool saveIsReal, isBetaOn, RFUIsConected, RFUIsLoged, ControlSaveIsReal;
        int ScreenMode;
        string gameSavePath = Environment.CurrentDirectory + "/gameSave.dat", settPath = Environment.CurrentDirectory + "/settings.dat",  ControlSavePath = Environment.CurrentDirectory + @"\controlsave.dat";
        mainmenu MainMenu;

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
            MainMenu = new mainmenu(AppLanguage, saveIsReal, isBetaOn, ScreenMode, ControlSaveIsReal);
            frame0.Content = MainMenu;
        }
        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            frame0.Content = MainMenu;
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

            if (File.Exists(ControlSavePath))
            {
                ControlSaveIsReal = true;
            }
            else
            {
                ControlSaveIsReal = false;
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
