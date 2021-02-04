using System;
using System.Windows;
using System.Windows.Controls;

namespace RandomFights
{
    public partial class singlesett : Page
    {
        string AppLanguage, Name0, Name1;
        int rb0Result, rb1Result, ScreenMode, ThemeNum;
        int NameIndex;
        bool saveIsReal, rb0Checked = false, rb1Checked = false, isBetaOn, StartFromSave;
        string[] Names = { "Sergey", "Kira", "Christina", "Elena", "Eva", "Katya", "Maria", "Maggie", "Penny", "Saya", "Princess", "Abby", "Laila", "Sadie", "Olivia", "Starlight", "Talla"};
        Random Rand = new Random();

        single ASingleGameProcess;

        private void RandomName0Btn_Click(object sender, RoutedEventArgs e)
        {
            NameIndex = Rand.Next(Names.Length);
            Name0TB.Text = Names[NameIndex];
        }

        private void RandomName1Btn_Click(object sender, RoutedEventArgs e)
        {
            NameIndex = Rand.Next(Names.Length);
            Name1TB.Text = Names[NameIndex];
        }

        private void loadSaveGameBtn_Click(object sender, RoutedEventArgs e)
        {
            if (saveIsReal == true)
            {
                StartFromSave = true;
                ASingleGameProcess = new single(AppLanguage, Name0, Name1, saveIsReal, rb0Result, rb1Result, isBetaOn, ScreenMode, StartFromSave);
                ((MainWindow)Window.GetWindow(this)).frame0.Content = ASingleGameProcess;
            }
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            rbsChecking();
            if (Name0TB.Text != "" && Name1TB.Text != "" && rb0Checked == true && rb1Checked == true)
            {
                Name0 = Name0TB.Text;
                Name1 = Name1TB.Text;
                StartFromSave = false;
                ASingleGameProcess = new single(AppLanguage, Name0, Name1, saveIsReal, rb0Result, rb1Result, isBetaOn, ScreenMode, StartFromSave);
                ((MainWindow)Window.GetWindow(this)).frame0.Content = ASingleGameProcess;
            }
        }

        public singlesett(string appLanguage, bool SaveIsReal, bool IsBetaOn, int screenMode, int themeNum)
        {
            InitializeComponent();
            saveIsReal = SaveIsReal;
            isBetaOn = IsBetaOn;
            AppLanguage = appLanguage;
            ScreenMode = screenMode;
            ThemeNum = themeNum;
            translation();
            ThemeChange();
            if (saveIsReal == false)
            {
                loadSaveGameBtn.Visibility = Visibility.Hidden;
            }
        }

        void translation()
        {
            if (AppLanguage == "ru")
            {
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
            else if (AppLanguage == "eng")
            {
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

        void ThemeChange()
        {
            if (ThemeNum == 1)
            {
                //.Style = (Style)FindResource("ButtonLightTheme");
                nextBtn.Style = (Style)FindResource("ButtonLightTheme");
                loadSaveGameBtn.Style = (Style)FindResource("ButtonLightTheme");
                RandomNameBtn0.Style = (Style)FindResource("ButtonLightTheme");
                RandomNameBtn1.Style = (Style)FindResource("ButtonLightTheme");

                nameText.Style = (Style)FindResource("TextLightTheme");
                spellText.Style = (Style)FindResource("TextLightTheme");
                loadSaveGameText.Style = (Style)FindResource("TextLightTheme");

                rb00.Style = (Style)FindResource("RdBtnLightTheme");
                rb01.Style = (Style)FindResource("RdBtnLightTheme");
                rb02.Style = (Style)FindResource("RdBtnLightTheme");
                rb03.Style = (Style)FindResource("RdBtnLightTheme");
                rb04.Style = (Style)FindResource("RdBtnLightTheme");
                rb05.Style = (Style)FindResource("RdBtnLightTheme");

                rb10.Style = (Style)FindResource("RdBtnLightTheme");
                rb11.Style = (Style)FindResource("RdBtnLightTheme");
                rb12.Style = (Style)FindResource("RdBtnLightTheme");
                rb13.Style = (Style)FindResource("RdBtnLightTheme");
                rb14.Style = (Style)FindResource("RdBtnLightTheme");
                rb15.Style = (Style)FindResource("RdBtnLightTheme");
            }
        }
    }
}
