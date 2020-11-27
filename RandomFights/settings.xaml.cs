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
        string AppLanguage;
        bool saveIsReal, deleteSave = false, enableSave = false, isBetaOn;
        string settPath = Environment.CurrentDirectory + "/settings.dat", savePath = Environment.CurrentDirectory + "/gameSave.dat";
        public settings(string appLanguage, bool SaveIsReal, bool EnableSave, bool IsBetaOn)
        {
            InitializeComponent();
            AppLanguage = appLanguage;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            isBetaOn = IsBetaOn;
            translate();
        }

        private void EnableBetaCB_Checked(object sender, RoutedEventArgs e)
        {
            if (isBetaOn == false)
            {
                isBetaOn = true;
            }
            else if (isBetaOn == true)
            {
                isBetaOn = false;
            }
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
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn);
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
                AppLanguage = "ru"; 
            }
            else if (RB1.IsChecked == true) 
            {
                AppLanguage = "eng"; 
            }
            else 
            {
                AppLanguage = "eng"; 
            }
            binaryWriter.Write(AppLanguage);
            binaryWriter.Write(enableSave);
            binaryWriter.Write(isBetaOn);
            binaryWriter.Dispose();

            if(deleteSave == true)
            {
                File.Delete(savePath);
            }
        }
        void translate()
        {
            if (AppLanguage == "eng")
            {
                homeBtn.Content = "Home.";
                saveBtn.Content = "Save.";
                LangTB.Text = "Language: ";
                DsTb.Text = "Delete saves: ";
                EsTb.Text = "Enable saves: ";
                EbTb.Text = "Enable BETA:";
            }
            else if (AppLanguage == "ru")
            {
                homeBtn.Content = "Назад.";
                saveBtn.Content = "Сохранить.";
                LangTB.Text = "Язык: ";
                DsTb.Text = "Удалить сохранение: ";
                EsTb.Text = "Активировать сохранения: ";
                EbTb.Text = "Активировать БЕТА:";
            }
        }
    }
}
