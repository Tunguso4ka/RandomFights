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
        string AppLanguage;
        bool saveIsReal, enableSave, isBetaOn;
        public mainmenu(string appLanguage, bool SaveIsReal, bool EnableSave, bool IsBetaOn)
        {
            InitializeComponent();
            AppLanguage = appLanguage;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            isBetaOn = IsBetaOn;
            if(IsBetaOn == true)
            {
                onlinebtn.Visibility = Visibility.Visible;
            }
            else
            {
                onlinebtn.Visibility = Visibility.Hidden;
            }
            translate();
        }

        private void singlebtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new singlesett(AppLanguage, saveIsReal, enableSave, isBetaOn);
        }

        private void onlinebtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new onlinesett(AppLanguage, saveIsReal, enableSave, isBetaOn);
        }

        private void settingsbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new settings(AppLanguage, saveIsReal, enableSave, isBetaOn);
        }

        private void helpbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new help(AppLanguage, saveIsReal, enableSave, isBetaOn);
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).Close();
        }

        void translate()
        {
            if(AppLanguage == "eng")
            {
                singlebtn.Content = "Single";
                onlinebtn.Content = "Online";
                settingsbtn.Content = "Settings";
                helpbtn.Content = "Help";
                exitbtn.Content = "Exit";
            }
            else if(AppLanguage == "ru")
            {
                singlebtn.Content = "Одиночная";
                onlinebtn.Content = "Онлайн";
                settingsbtn.Content = "Настройки";
                helpbtn.Content = "Помощь";
                exitbtn.Content = "Выход";
            }

            if(isBetaOn == true)
            {
                VersionTB.Text = VersionTB.Text + " BETA";
                VersionTB.Foreground = Brushes.DarkRed;
            }
        }
    }
}
