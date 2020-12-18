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
        bool saveIsReal, enableSave, isBetaOn, RFUIsConected, RFUIsLoged;
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
                enableSave = false;
                saveIsReal = false;
            }
            frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn);
        }
        void searchSettings()
        {
            if(File.Exists(settPath))
            {
                BinaryReader BinaryReader = new BinaryReader(File.OpenRead(settPath));
                AppLanguage = BinaryReader.ReadString();
                enableSave = BinaryReader.ReadBoolean();
                isBetaOn = BinaryReader.ReadBoolean();
                BinaryReader.Dispose();
            }
            else
            {
                AppLanguage = "eng";
                enableSave = false;
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
    }
}
