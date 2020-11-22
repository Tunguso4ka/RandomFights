using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace RandomFights
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Language, Name0, Name1;
        bool saveIsReal, enableSave;
        int[] GameData;
        int maxhp0, maxhp1, hp0, hp1, ahp0, ahp1, shield0, shield1, dam0, dam1, ddam0, ddam1, lvl0, lvl1, xp0, xp1, spell0, spell1, poison0, poison1, minute, second, ssecond;
        string gameSavePath = Environment.CurrentDirectory + "/gameSave.dat", settPath = Environment.CurrentDirectory + "/settings.dat";
        public MainWindow()
        {
            InitializeComponent();
            searchSettings();
            frame0.Content = new mainmenu(Language, GameData, Name0, Name1, saveIsReal, enableSave);
        }
        void searchSettings()
        {
            if(File.Exists(settPath))
            {
                BinaryReader BinaryReader = new BinaryReader(File.OpenRead(settPath));
                while (BinaryReader.PeekChar() > -1)
                {
                    Language = BinaryReader.ReadString();
                    enableSave = BinaryReader.ReadBoolean();
                }
                BinaryReader.Dispose();
            }
            else
            {
                Language = "eng";
                enableSave = false;
            }

            if (File.Exists(gameSavePath))
            {
                BinaryReader BinaryReader = new BinaryReader(File.OpenRead(gameSavePath));
                while (BinaryReader.PeekChar() > -1)
                {
                    Name0 = BinaryReader.ReadString();
                    Name1 = BinaryReader.ReadString();
                    maxhp0 = BinaryReader.ReadInt32();
                    maxhp1 = BinaryReader.ReadInt32();
                    hp0 = BinaryReader.ReadInt32();
                    hp1 = BinaryReader.ReadInt32();
                    ahp0 = BinaryReader.ReadInt32();
                    ahp1 = BinaryReader.ReadInt32();
                    shield0 = BinaryReader.ReadInt32();
                    shield1 = BinaryReader.ReadInt32();
                    dam0 = BinaryReader.ReadInt32();
                    dam1 = BinaryReader.ReadInt32();
                    ddam0 = BinaryReader.ReadInt32();
                    ddam1 = BinaryReader.ReadInt32();
                    lvl0 = BinaryReader.ReadInt32();
                    lvl1 = BinaryReader.ReadInt32();
                    xp0 = BinaryReader.ReadInt32();
                    xp1 = BinaryReader.ReadInt32();
                    spell0 = BinaryReader.ReadInt32();
                    spell1 = BinaryReader.ReadInt32();
                    poison0 = BinaryReader.ReadInt32();
                    poison1 = BinaryReader.ReadInt32();
                    minute = BinaryReader.ReadInt32();
                    second = BinaryReader.ReadInt32();
                    ssecond = BinaryReader.ReadInt32();
                }
                GameData = new int[23] { maxhp0, maxhp1, hp0, hp1, ahp0, ahp1, shield0, shield1, dam0, dam1, ddam0, ddam1, lvl0, lvl1, xp0, xp1, spell0, spell1, poison0, poison1, minute, second, ssecond };
                BinaryReader.Dispose();
                saveIsReal = true;
            }
            else
            {
                saveIsReal = false;
            }
        }
    }
}
