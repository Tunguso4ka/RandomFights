using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace RandomFights
{
    /// <summary>
    /// Логика взаимодействия для settings.xaml
    /// </summary>
    public partial class settings : Page
    {
        string AppLanguage;
        bool saveIsReal, deleteSave = false, enableSave = false, isBetaOn;
        int ScreenMode;
        string settPath = Environment.CurrentDirectory + "/settings.dat", savePath = Environment.CurrentDirectory + "/gameSave.dat";
        public settings(string appLanguage, bool SaveIsReal, bool EnableSave, bool IsBetaOn, int screenMode)
        {
            InitializeComponent();
            AppLanguage = appLanguage;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            isBetaOn = IsBetaOn;
            ScreenMode = screenMode;
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

                if (enableSave == true)
                {
                    EnableSavesCB.IsChecked = true;
                }
                else
                {
                    EnableSavesCB.IsChecked = false;
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
            }
            catch
            {

            }
            translate();
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
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn, ScreenMode);
        }

        void ScreenChange()
        {
            if (ScreenMode == 0)
            {
                ((MainWindow)Window.GetWindow(this)).Visibility = Visibility.Collapsed;
                ((MainWindow)Window.GetWindow(this)).WindowStyle = WindowStyle.None;
                ((MainWindow)Window.GetWindow(this)).ResizeMode = ResizeMode.NoResize;
                ((MainWindow)Window.GetWindow(this)).WindowState = WindowState.Maximized;
                ((MainWindow)Window.GetWindow(this)).Topmost = true;
                ((MainWindow)Window.GetWindow(this)).Visibility = Visibility.Visible;
            }
            else if (ScreenMode == 1)
            {
                ((MainWindow)Window.GetWindow(this)).WindowStyle = WindowStyle.SingleBorderWindow;
                ((MainWindow)Window.GetWindow(this)).ResizeMode = ResizeMode.CanResize;
                ((MainWindow)Window.GetWindow(this)).Topmost = false;
                ((MainWindow)Window.GetWindow(this)).WindowStyle = WindowStyle.None;
                ((MainWindow)Window.GetWindow(this)).WindowState = WindowState.Maximized;
            }
            else
            {
                ((MainWindow)Window.GetWindow(this)).WindowStyle = WindowStyle.SingleBorderWindow;
                ((MainWindow)Window.GetWindow(this)).ResizeMode = ResizeMode.CanResize;
                ((MainWindow)Window.GetWindow(this)).Topmost = false;
            }
        }

        void settSave()
        {
            if(File.Exists(settPath))
            {
                File.Delete(settPath);
            }
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(settPath, FileMode.Create));

            if (EnableSavesCB.IsChecked == true)
            {
                enableSave = true;
            }
            else
            {
                enableSave = false;
            }

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

            ScreenChange();

            binaryWriter.Write(AppLanguage);
            binaryWriter.Write(enableSave);
            binaryWriter.Write(isBetaOn);
            binaryWriter.Write(ScreenMode);
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
                SmTb.Text = "Screen mode:";
                RB2.Content = "Fullscreen";
                RB3.Content = "Borderless";
                RB4.Content = "Window";
            }
            else if (AppLanguage == "ru")
            {
                homeBtn.Content = "Назад.";
                saveBtn.Content = "Сохранить.";
                LangTB.Text = "Язык: ";
                DsTb.Text = "Удалить сохранение: ";
                EsTb.Text = "Активировать сохранения: ";
                EbTb.Text = "Активировать БЕТА:";
                SmTb.Text = "Режим экрана:";
                RB2.Content = "Полноэкранный";
                RB3.Content = "Безграничный";
                RB4.Content = "Оконный";
            }
        }
    }
}
