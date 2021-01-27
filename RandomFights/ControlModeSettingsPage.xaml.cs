﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace RandomFights
{
    /// <summary>
    /// Interaction logic for ControlModeSettingsPage.xaml
    /// </summary>
    public partial class ControlModeSettingsPage : Page
    {
        bool StartFromSave, SaveIsReal, IsBetaOn, InputIsChecked;
        string Name0, Name1;
        int SpellNum0, SpellNum1;
        string[] Names = { "Sergey", "Kira", "Christina", "Elena", "Eva", "Katya", "Maria", "Maggie", "Penny", "Saya", "Princess", "Abby", "Laila", "Sadie", "Olivia", "Starlight", "Talla" };
        Random Rand = new Random();
        ControlModeProcessPage AControlModeProcessPage;

        public ControlModeSettingsPage(bool saveIsReal, bool isBetaOn)
        {
            InitializeComponent();
            SaveIsReal = saveIsReal;
            IsBetaOn = isBetaOn;
        }

        void InputCheck()
        {
            if(NameTxtBx0.Text != "" && NameTxtBx1.Text != "")
            {
                Name0 = NameTxtBx0.Text;
                Name1 = NameTxtBx1.Text;
                InputIsChecked = true;
            }
            else
            {
                InputIsChecked = false;
            }
            if(InputIsChecked == true)
            {
                if (SpellRdBtn00.IsChecked == true)
                {
                    SpellNum0 = 0;
                }
                else if (SpellRdBtn01.IsChecked == true)
                {
                    SpellNum0 = 1;
                }
                else if (SpellRdBtn02.IsChecked == true)
                {
                    SpellNum0 = 2;
                }
                else if (SpellRdBtn03.IsChecked == true)
                {
                    SpellNum0 = 3;
                }
                else if (SpellRdBtn04.IsChecked == true)
                {
                    SpellNum0 = 4;
                }
                else if (SpellRdBtn05.IsChecked == true)
                {
                    SpellNum0 = 5;
                }
                else
                {
                    InputIsChecked = false;
                }
            }

            if (InputIsChecked == true)
            {
                if (SpellRdBtn10.IsChecked == true)
                {
                    SpellNum1 = 0;
                }
                else if (SpellRdBtn11.IsChecked == true)
                {
                    SpellNum1 = 1;
                }
                else if (SpellRdBtn12.IsChecked == true)
                {
                    SpellNum1 = 2;
                }
                else if (SpellRdBtn13.IsChecked == true)
                {
                    SpellNum1 = 3;
                }
                else if (SpellRdBtn14.IsChecked == true)
                {
                    SpellNum1 = 4;
                }
                else if (SpellRdBtn15.IsChecked == true)
                {
                    SpellNum1 = 5;
                }
                else
                {
                    InputIsChecked = false;
                }
            }

            if(InputIsChecked == true)
            {
                AControlModeProcessPage = new ControlModeProcessPage(StartFromSave, IsBetaOn, Name0, Name1, SpellNum0, SpellNum1);
                ((MainWindow)Window.GetWindow(this)).frame0.Content = AControlModeProcessPage;
            }
        }

        private void StartFromSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(SaveIsReal == true)
            {
                StartFromSave = true;
                AControlModeProcessPage = new ControlModeProcessPage(StartFromSave, IsBetaOn, Name0, Name1, SpellNum0, SpellNum1);
                ((MainWindow)Window.GetWindow(this)).frame0.Content = AControlModeProcessPage;
            }
        }

        private void RandomNameBtn0_Click(object sender, RoutedEventArgs e)
        {
            NameTxtBx0.Text = Names[Rand.Next(Names.Length)];
        }

        private void RandomNameBtn1_Click(object sender, RoutedEventArgs e)
        {
            NameTxtBx1.Text = Names[Rand.Next(Names.Length)];
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            InputCheck();
        }
    }
}
