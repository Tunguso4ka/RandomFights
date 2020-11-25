using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomFights
{
    public partial class online : Page
    {
        string language, Name0, Name1;
        bool saveIsReal, enableSave;
        int[] GameData;
        public online(string language, int[] gameData, string name0, string name1, bool SaveIsReal, bool EnableSave)
        {
            InitializeComponent();
            GameData = gameData;
            Name0 = name0;
            Name1 = name1;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(language, GameData, Name0, Name1, saveIsReal, enableSave);
        }
    }
}
