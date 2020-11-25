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
    public partial class singlesett : Page
    {
        string Language, Name0, Name1;
        int rb0Result, rb1Result;
        bool saveIsReal, enableSave, rb0Checked = false, rb1Checked = false;

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            rbsChecking();
            if (Name0TB.Text != "" && Name1TB.Text != "" && rb0Checked == true && rb1Checked == true)
            {
                Name0 = Name0TB.Text;
                Name1 = Name1TB.Text;
                ((MainWindow)Window.GetWindow(this)).frame0.Content = new single(Language, GameData, Name0, Name1, saveIsReal, enableSave, rb0Result, rb1Result);
            }
        }

        int[] GameData;
        public singlesett(string language, int[] gameData, string name0, string name1, bool SaveIsReal, bool EnableSave)
        {
            InitializeComponent();
            GameData = gameData;
            Name0 = name0;
            Name1 = name1;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            Language = language;
            translation();
        }
        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(Language, GameData, Name0, Name1, saveIsReal, enableSave);
        }

        void translation()
        {
            if (Language == "ru")
            {
                homeBtn.Content = "Домой.";
                nextBtn.Content = "Следущее.";
                nameText.Text = "Имена игроков:";
                loadSaveGameText.Text = "Начать с заранее сохраненной игры?";
                spellText.Text = "Способности:";
                rb00.Content = "Граната.";
                rb01.Content = "Зелье отравления.";
                rb02.Content = "Доп. регенерация здоровья.";
                rb03.Content = "Дополнительный урон.";
                rb04.Content = "Щит.";
                rb05.Content = "Дополнительный опыт.";
                rb10.Content = "Граната.";
                rb11.Content = "Зелье отравления.";
                rb12.Content = "Доп. регенерация здоровья.";
                rb13.Content = "Дополнительный урон.";
                rb14.Content = "Щит.";
                rb15.Content = "Дополнительный опыт.";
            }
            else if (Language == "eng")
            {
                homeBtn.Content = "Home.";
                nextBtn.Content = "Next.";
                nameText.Text = "Player names:";
                loadSaveGameText.Text = "Start from save?";
                spellText.Text = "Spells:";
                rb00.Content = "Grenade.";
                rb01.Content = "Poison potion";
                rb02.Content = "Addit. HP regen.";
                rb03.Content = "Addit. damage.";
                rb04.Content = "Shield";
                rb05.Content = "Addit. XP.";
                rb10.Content = "Grenade.";
                rb11.Content = "Poison potion";
                rb12.Content = "Addit. HP regen.";
                rb13.Content = "Addit. damage.";
                rb14.Content = "Shield.";
                rb15.Content = "Addit. XP.";
            }
        }

        void rbsChecking()
        {
            if(rb00.IsChecked == true)
            {
                rb0Result = 0;
                rb0Checked = true;
            }
            else if (rb01.IsChecked == true)
            {
                rb0Result = 1;
                rb0Checked = true;
            }
            else if (rb02.IsChecked == true)
            {
                rb0Result = 2;
                rb0Checked = true;
            }
            else if (rb03.IsChecked == true)
            {
                rb0Result = 3;
                rb0Checked = true;
            }
            else if (rb04.IsChecked == true)
            {
                rb0Result = 4;
                rb0Checked = true;
            }
            else if (rb05.IsChecked == true)
            {
                rb0Result = 5;
                rb0Checked = true;
            }

            if (rb10.IsChecked == true)
            {
                rb1Result = 0;
                rb1Checked = true;
            }
            else if (rb11.IsChecked == true)
            {
                rb1Result = 1;
                rb1Checked = true;
            }
            else if (rb12.IsChecked == true)
            {
                rb1Result = 2;
                rb1Checked = true;
            }
            else if (rb13.IsChecked == true)
            {
                rb1Result = 3;
                rb1Checked = true;
            }
            else if (rb14.IsChecked == true)
            {
                rb1Result = 4;
                rb1Checked = true;
            }
            else if (rb15.IsChecked == true)
            {
                rb1Result = 5;
                rb1Checked = true;
            }
        }
    }
}
