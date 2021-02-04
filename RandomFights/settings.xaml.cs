using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RandomFights
{
    /// <summary>
    /// Логика взаимодействия для settings.xaml
    /// </summary>
    public partial class settings : Page
    {
        string AppLanguage;
        bool saveIsReal, deleteSave = false, isBetaOn;
        int ScreenMode, ThemeNum;
        string settPath = Environment.CurrentDirectory + "/settings.dat", savePath = Environment.CurrentDirectory + "/gameSave.dat";
        public settings(string appLanguage, bool SaveIsReal, bool IsBetaOn, int screenMode, int themeNum)
        {
            InitializeComponent();
            AppLanguage = appLanguage;
            saveIsReal = SaveIsReal;
            isBetaOn = IsBetaOn;
            ScreenMode = screenMode;
            ThemeNum = themeNum;
            try
            {
                if(AppLanguage == "ru")
                {
                    RB0.IsChecked = true;
                }
                else
                {
                    RB1.IsChecked = true;
                }

                if (isBetaOn == true)
                {
                    EnableBetaCB.IsChecked = true;
                }
                else
                {
                    EnableBetaCB.IsChecked = false;
                }

                if (ScreenMode == 0)
                {
                    RB2.IsChecked = true;
                }
                else if (ScreenMode == 1)
                {
                    RB3.IsChecked = true;
                }
                else
                {
                    RB4.IsChecked = true;
                }
                if (ThemeNum == 0)
                {
                    RB5.IsChecked = true;
                }
                else
                {
                    RB6.IsChecked = true;
                }
            }
            catch
            {

            }
            translate();
            ThemeChange();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            settSave();
        }

        private void DeleteSavesCB_Checked(object sender, RoutedEventArgs e)
        {
            deleteSave = true;
        }

        private void SaveAndRestartBtn_Click(object sender, RoutedEventArgs e)
        {
            settSave();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            ((MainWindow)Window.GetWindow(this)).Close();
        }

        void settSave()
        {
            if(File.Exists(settPath))
            {
                File.Delete(settPath);
            }
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(settPath, FileMode.Create));

            if (EnableBetaCB.IsChecked == true)
            {
                isBetaOn = true;
            }
            else
            {
                isBetaOn = false;
            }

            if (RB0.IsChecked == true) 
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

            if (RB2.IsChecked == true)
            {
                ScreenMode = 0;
            }
            else if (RB3.IsChecked == true)
            {
                ScreenMode = 1;
            }
            else if (RB4.IsChecked == true)
            {
                ScreenMode = 2;
            }
            else
            {
                ScreenMode = 2;
            }
            if (RB6.IsChecked == true)
            {
                ThemeNum = 1;
            }
            else
            {
                ThemeNum = 0;
            }

            binaryWriter.Write(AppLanguage);
            binaryWriter.Write(isBetaOn);
            binaryWriter.Write(ScreenMode);
            binaryWriter.Write(ThemeNum);
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
                SaveBtn.Content = "Save.";
                SaveAndRestartBtn.Content = "Save and restart.";
                LangTB.Text = "Language: ";
                DsTb.Text = "Delete saves: ";
                EbTb.Text = "Enable BETA:";
                SmTb.Text = "Screen mode:";
                RB2.Content = "Fullscreen";
                RB3.Content = "Borderless";
                RB4.Content = "Window";
            }
            else if (AppLanguage == "ru")
            {
                SaveBtn.Content = "Сохранить.";
                SaveAndRestartBtn.Content = "Сохранить и перезагрузить.";
                LangTB.Text = "Язык: ";
                DsTb.Text = "Удалить сохранение: ";
                EbTb.Text = "Активировать БЕТА:";
                SmTb.Text = "Режим экрана:";
                RB2.Content = "Полноэкранный";
                RB3.Content = "Безграничный";
                RB4.Content = "Оконный";
            }
        }

        void ThemeChange()
        {
            if(ThemeNum == 1)
            {
                SaveBtn.Style = (Style)FindResource("ButtonLightTheme");
                SaveAndRestartBtn.Style = (Style)FindResource("ButtonLightTheme");
                ThisGrid.Background = new SolidColorBrush(Color.FromRgb(211, 215, 255));
            }
        }
    }
}
