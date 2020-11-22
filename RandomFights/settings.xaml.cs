using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для settings.xaml
    /// </summary>
    public partial class settings : Page
    {
        string Language, Name0, Name1;
        bool saveIsReal, deleteSave = false, enableSave = false;
        string settPath = Environment.CurrentDirectory + "/settings.dat", savePath = Environment.CurrentDirectory + "/gameSave.dat";
        int[] GameData;
        public settings(string language, int[] gameData, string name0, string name1, bool SaveIsReal, bool EnableSave)
        {
            InitializeComponent();
            GameData = gameData;
            Language = language;
            Name0 = name0;
            Name1 = name1;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            translate();
        }

        private void EnableSavesCB_Checked(object sender, RoutedEventArgs e)
        {
            if(enableSave == false)
            {
                enableSave = true;
            }
            else if (enableSave == true)
            {
                enableSave = false;
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            settSave();
        }

        private void DeleteSavesCB_Checked(object sender, RoutedEventArgs e)
        {
            deleteSave = true;
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(Language, GameData, Name0, Name1, saveIsReal, enableSave);
        }

        void settSave()
        {
            if(File.Exists(settPath))
            {
                File.Delete(settPath);
            }
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(settPath, FileMode.Create));
            if(RB0.IsChecked == true) 
            {
                Language = "ru"; 
            }
            else if (RB1.IsChecked == true) 
            {
                Language = "eng"; 
            }
            else 
            {
                Language = "eng"; 
            }
            binaryWriter.Write(Language);
            binaryWriter.Write(enableSave);
            binaryWriter.Dispose();

            if(deleteSave == true)
            {
                File.Delete(savePath);
            }
        }
        void translate()
        {
            if (Language == "eng")
            {
                homeBtn.Content = "Home.";
                saveBtn.Content = "Save.";
                LangTB.Text = "Language: ";
                DsTb.Text = "Delete saves: ";
                EsTb.Text = "Enable saves: ";
            }
            else if (Language == "ru")
            {
                homeBtn.Content = "Назад.";
                saveBtn.Content = "Сохранить.";
                LangTB.Text = "Язык: ";
                DsTb.Text = "Удалить сохранение: ";
                EsTb.Text = "Активировать сохранения: ";
            }
        }
    }
}
