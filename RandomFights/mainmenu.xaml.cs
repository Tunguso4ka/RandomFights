﻿using System;
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
        bool saveIsReal, isBetaOn, SingleListVisible, OnlineListVisible, ControlSaveIsReal;
        int ScreenMode, ThemeNum;

        singlesett SingleGameSettings;
        OnlineCreateRoomPage AOnlineCreateRoomPage;
        OnlineFindRoomPage AOnlineFindRoomPage;
        settings SettingsPage;
        help HelpPage;
        ControlModeSettingsPage AControlModeSettingsPage;
        public mainmenu(string appLanguage, bool SaveIsReal, bool IsBetaOn, int screenMode, bool controlSaveIsReal, int themeNum)
        {
            InitializeComponent();
            AppLanguage = appLanguage;
            saveIsReal = SaveIsReal;
            isBetaOn = IsBetaOn;
            ScreenMode = screenMode;
            ControlSaveIsReal = controlSaveIsReal;
            ThemeNum = themeNum;
            if (IsBetaOn == true)
            {
                OnlineListBtn.Visibility = Visibility.Visible;
            }
            else
            {
                OnlineListBtn.Visibility = Visibility.Collapsed;
            }
            onlinebtn.Visibility = Visibility.Collapsed;
            onlinebtn1.Visibility = Visibility.Collapsed;
            singlebtn.Visibility = Visibility.Hidden;
            singlebtn1.Visibility = Visibility.Hidden;

            WhatsNewNewTB.Text = "-New control mode\n-New UI";

            translate();
            ThemeGhange();
            Pages();
        }

        void Pages()
        {
            SingleGameSettings = new singlesett(AppLanguage, saveIsReal, isBetaOn, ScreenMode, ThemeNum);
            //AOnlineCreateRoomPage = new OnlineCreateRoomPage(AppLanguage, saveIsReal, isBetaOn, ScreenMode, ThemeNum);
            //AOnlineFindRoomPage = new OnlineFindRoomPage(AppLanguage, saveIsReal, isBetaOn, ScreenMode, ThemeNum);
            SettingsPage = new settings(AppLanguage, saveIsReal, isBetaOn, ScreenMode, ThemeNum);
            HelpPage = new help(AppLanguage, ThemeNum);
            AControlModeSettingsPage = new ControlModeSettingsPage(ControlSaveIsReal, isBetaOn, ThemeNum);
        }

        private void singlebtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = SingleGameSettings;
        }

        private void onlinebtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = AOnlineCreateRoomPage;
        }
        private void onlinebtn1_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = AOnlineFindRoomPage;
        }

        private void settingsbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = SettingsPage;
        }

        private void helpbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = HelpPage;
        }

        private void singlebtn1_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = AControlModeSettingsPage;
        }

        private void SingleListBtn_Click(object sender, RoutedEventArgs e)
        {
            if(SingleListVisible == true)
            {
                singlebtn.Visibility = Visibility.Hidden;
                singlebtn1.Visibility = Visibility.Hidden;
                SingleListVisible = false;
            }
            else
            {
                singlebtn.Visibility = Visibility.Visible;
                singlebtn1.Visibility = Visibility.Visible;
                if (OnlineListVisible == true)
                {
                    onlinebtn.Visibility = Visibility.Hidden;
                    onlinebtn1.Visibility = Visibility.Hidden;
                }
                else
                {
                    onlinebtn.Visibility = Visibility.Collapsed;
                    onlinebtn1.Visibility = Visibility.Collapsed;
                }
                SingleListVisible = true;
                OnlineListVisible = false;
            }
        }

        private void OnlineListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OnlineListVisible == true)
            {
                onlinebtn.Visibility = Visibility.Hidden;
                onlinebtn1.Visibility = Visibility.Hidden;
                OnlineListVisible = false;
            }
            else
            {
                onlinebtn.Visibility = Visibility.Visible;
                onlinebtn1.Visibility = Visibility.Visible;
                singlebtn.Visibility = Visibility.Hidden;
                singlebtn1.Visibility = Visibility.Hidden;
                OnlineListVisible = true;
                SingleListVisible = false;
            }
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).Close();
        }

        void translate()
        {
            if(AppLanguage == "eng")
            {
                SingleListBtn.Content = "Single";
                singlebtn.Content = "Full Random";
                singlebtn1.Content = "Control";
                OnlineListBtn.Content = "Online";
                onlinebtn.Content = "Create room";
                onlinebtn1.Content = "Find room";
                settingsbtn.Content = "Settings";
                helpbtn.Content = "Help";
                exitbtn.Content = "Exit";
            }
            else if(AppLanguage == "ru")
            {
                SingleListBtn.Content = "Одиночная";
                singlebtn.Content = "Полный рандом";
                singlebtn1.Content = "Контроль";
                OnlineListBtn.Content = "Онлайн";
                onlinebtn.Content = "Создать комнату";
                onlinebtn1.Content = "Найти комнату";
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

        void ThemeGhange()
        {
            if(ThemeNum == 1)
            {
                FirstGrid.Background = new SolidColorBrush(Color.FromRgb(218, 221, 255));
                SingleListBtn.Style = (Style)FindResource("ButtonLightTheme");
                OnlineListBtn.Style = (Style)FindResource("ButtonLightTheme");
                settingsbtn.Style = (Style)FindResource("ButtonLightTheme");
                helpbtn.Style = (Style)FindResource("ButtonLightTheme");
                exitbtn.Style = (Style)FindResource("ButtonLightTheme");
                singlebtn.Style = (Style)FindResource("ButtonLightTheme");
                singlebtn1.Style = (Style)FindResource("ButtonLightTheme");
                onlinebtn.Style = (Style)FindResource("ButtonLightTheme");
                onlinebtn1.Style = (Style)FindResource("ButtonLightTheme");
                RFText.Foreground = Brushes.Black;
                if(isBetaOn == false)
                {
                    VersionTB.Foreground = Brushes.Black;
                }
                WhatsNewNewTB.Style = (Style)FindResource("TextLightTheme");
            }
        }
    }
}
