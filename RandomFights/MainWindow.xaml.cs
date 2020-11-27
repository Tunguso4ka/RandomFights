﻿using System;
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
        string AppLanguage;
        bool saveIsReal, enableSave, isBetaOn;
        string gameSavePath = Environment.CurrentDirectory + "/gameSave.dat", settPath = Environment.CurrentDirectory + "/settings.dat";
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                searchSettings();
            }
            catch
            {
                AppLanguage = "eng";
                enableSave = false;
                saveIsReal = false;
            }
            frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn);
        }
        void searchSettings()
        {
            if(File.Exists(settPath))
            {
                BinaryReader BinaryReader = new BinaryReader(File.OpenRead(settPath));
                AppLanguage = BinaryReader.ReadString();
                enableSave = BinaryReader.ReadBoolean();
                isBetaOn = BinaryReader.ReadBoolean();
                BinaryReader.Dispose();
            }
            else
            {
                AppLanguage = "eng";
                enableSave = false;
            }

            if (File.Exists(gameSavePath))
            {
                saveIsReal = true;
            }
            else
            {
                saveIsReal = false;
            }
        }
    }
}
