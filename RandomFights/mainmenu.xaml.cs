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
    /// <summary>
    /// Логика взаимодействия для mainmenu.xaml
    /// </summary>
    public partial class mainmenu : Page
    {
        string language, name0, name1;
        bool saveIsReal, enableSave;
        int[] gameData;
        public mainmenu(string Language, int[] GameData, string Name0, string Name1, bool SaveIsReal, bool EnableSave)
        {
            InitializeComponent();
            language = Language;
            gameData = GameData;
            name0 = Name0;
            name1 = Name1;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            translate();
        }

        private void singlebtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new single(language, gameData, name0, name1, saveIsReal, enableSave);
        }

        private void onlinebtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new online(language, gameData, name0, name1, saveIsReal, enableSave);
        }

        private void settingsbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new settings(language, gameData, name0, name1, saveIsReal, enableSave);
        }

        private void helpbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new help(language, gameData, name0, name1, saveIsReal, enableSave);
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).Close();
        }

        void translate()
        {
            if(language == "eng")
            {
                singlebtn.Content = "Single";
                onlinebtn.Content = "Online";
                settingsbtn.Content = "Settings";
                helpbtn.Content = "Help";
                exitbtn.Content = "Exit";
            }
            else if(language == "ru")
            {
                singlebtn.Content = "Одиночная";
                onlinebtn.Content = "Онлайн";
                settingsbtn.Content = "Настройки";
                helpbtn.Content = "Помощь";
                exitbtn.Content = "Выход";
            }
        }
    }
}
