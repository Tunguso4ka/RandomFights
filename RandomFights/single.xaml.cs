using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RandomFights
{
    public partial class single : Page
    {
        bool gameIsPaused = false, gameIsSkiped = false, saveIsReal, enableSave, isBetaOn, playerIsDead = false, player0IsPoisoned, player1IsPoisoned, ConsoleIsTapped;
        string AppLanguage, Name0, Name1, time;
        int timeSpeed = 1000, ScreenMode;
        string SavePath = Environment.CurrentDirectory + @"\gameSave.dat";
        //
        string[] CCSM;
        //
        int MaxHP0; //максимально возможное колво здоровья
        int HP0; //само здоровье
        int AddHP0; //колво здоровья для добавления
        int Shield0; //Щит
        int Damage0; //Урон
        int AdditDamage0; //Дополнительный урон
        int Level0; //Уровень
        int XP0; //Опыт
        int Spell0; //Номер способности
        int Poisoning0; //Эффект отравления
        int MaxHP1; //максимально возможное колво здоровья
        int HP1; //само здоровье
        int AddHP1; //колво здоровья для добавления
        int Shield1; //Щит
        int Damage1; //Урон
        int AdditDamage1; //Дополнительный урон
        int Level1; //Уровень
        int XP1; //Опыт
        int Spell1; //Номер способности
        int Poisoning1; //Эффект отравления
        int Minute, Second;

        Random Rand = new Random();

        string grenadeText2;

        private void skipBtn_Click(object sender, RoutedEventArgs e)
        {
            if(gameIsSkiped == false)
            {
                gameIsSkiped = true;
            }
            else if(gameIsSkiped == true)
            {
                gameIsSkiped = false;
            }
        }

        private void restartBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new singlesett(AppLanguage, saveIsReal, enableSave, isBetaOn, ScreenMode);
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn, ScreenMode);
        }

        private void CheatCodeInput_TextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        async void CheatCodeLogic()
        {
            while(true)
            {
                if (gameIsPaused == false && playerIsDead == false )
                {
                    CheatCodeText.Text = "\n" + Minute + ":" + Second + "\n" + Name0 + " " + MaxHP0 + " " + HP0 + " " + AddHP0 + " " + Shield0 + " " + Damage0 + " " + AdditDamage0 + " " + Level0 + " " + XP0 + " " + Spell0 + " " + Poisoning0 + "     " + Name1 + " " + MaxHP1 + " " + HP1 + " " + AddHP1 + " " + Shield1 + " " + Damage1 + " " + AdditDamage1 + " " + Level1 + " " + XP1 + " " + Spell1 + " " + Poisoning1 + "\n" + CheatCodeText.Text;
                }
                await Task.Delay(1000);
            }
        }

        void CheatCodeEnterCheck()
        {
            if(CCSM[0] == "help")
            {
                CheatCodeText.Text = "\nHelp:\nMaxHP0, HP0, AddHP0, Shield0, Damage0, AdditDamage0, Level0, XP0, Spell0, Poisoning0, Console\n" + CheatCodeText.Text;
            }

            else if (CCSM[0] == "Console" || CCSM[0] == "console")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        if(CCSM[1] == "Clear" || CCSM[1] == "clear")
                        {
                            CheatCodeText.Text = "Console cleared.";
                        }
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //MaxHP
            else if (CCSM[0] == "MaxHP0" || CCSM[0] == "maxhp0")
            {
                if(CCSM[1] != "")
                {
                    try
                    {
                        MaxHP0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "MaxHP1" || CCSM[0] == "maxhp1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        MaxHP1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //HP
            else if (CCSM[0] == "HP0" || CCSM[0] == "hp0")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        HP0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "HP1" || CCSM[0] == "hp1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        HP1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //AddHP
            else if (CCSM[0] == "AddHP0" || CCSM[0] == "addhp0")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        AddHP0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "AddHP1" || CCSM[0] == "addhp1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        AddHP1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //Shield
            else if (CCSM[0] == "Shield0" || CCSM[0] == "shield0")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Shield0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "Shield1" || CCSM[0] == "shield1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Shield1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //Damage0
            else if (CCSM[0] == "Damage0" || CCSM[0] == "damage0")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Damage0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "Damage1" || CCSM[0] == "damage1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Damage1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //AdditDamage0
            else if (CCSM[0] == "AdditDamage0" || CCSM[0] == "additdamage0")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        AdditDamage0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "AdditDamage1" || CCSM[0] == "additdamage1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        AdditDamage1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //Level
            else if (CCSM[0] == "Level0" || CCSM[0] == "level0")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Level0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "Level1" || CCSM[0] == "level1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Level1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //XP
            else if (CCSM[0] == "XP0" || CCSM[0] == "xp0")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        XP0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "XP1" || CCSM[0] == "xp1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        XP1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //Spell 
            else if (CCSM[0] == "Spell0" || CCSM[0] == "spell0")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Spell0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "Spell1" || CCSM[0] == "spell1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Spell1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            //Poisoning 
            else if (CCSM[0] == "Poisoning0" || CCSM[0] == "poisoning0")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Poisoning0 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }
            else if (CCSM[0] == "Poisoning1" || CCSM[0] == "poisoning1")
            {
                if (CCSM[1] != "")
                {
                    try
                    {
                        Poisoning1 = Convert.ToInt32(CCSM[1]);
                        CheatCodeText.Text = CCSM[0] + " now " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                    catch
                    {
                        CheatCodeText.Text = "Error in " + CCSM[1] + "\n" + CheatCodeText.Text;
                    }
                }
            }

            else
            {
                CheatCodeText.Text = "Command " + CCSM[0] + " not found " + "\n" + CheatCodeText.Text;
            }
        }

        /*
        int Minute, Second; */

        private void ConsoleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ConsoleIsTapped == false)
            {
                ToggleConsoleOn();
                ConsoleIsTapped = true;
            }
            else
            {
                ToggleConsoleOff();
                ConsoleIsTapped = false;
            }
        }

        void ToggleConsoleOn()
        {
            CheatCodeConsoleGrid.Visibility = Visibility.Visible;
            CheatCodeInput.Visibility = Visibility.Visible;
            CheatCodeText.Visibility = Visibility.Visible;
            ConsoleEnterBtn.Visibility = Visibility.Visible;
        }

        private void ConsoleEnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CheatCodeInput.Text != "")
            {
                CCSM = CheatCodeInput.Text.Split(" ");
                CheatCodeInput.Text = "";
                CheatCodeEnterCheck();
            }
        }

        void ToggleConsoleOff()
        {
            CheatCodeConsoleGrid.Visibility = Visibility.Hidden;
            CheatCodeInput.Visibility = Visibility.Hidden;
            CheatCodeText.Visibility = Visibility.Hidden;
            ConsoleEnterBtn.Visibility = Visibility.Hidden;
        }

        private void pauseBtn_Click(object sender, RoutedEventArgs e)
        {
            if(gameIsPaused == false)
            {
                gameIsPaused = true;
                pauseBtn.Content = "Pause";
            }
            else if (gameIsPaused == true)
            {
                gameIsPaused = false;
                pauseBtn.Content = "Paused";
            }
        }

        public single(string appLanguage, string name0, string name1, bool SaveIsReal, bool EnableSave, int rb0Result, int rb1Result, bool IsBetaOn, int screenMode)
        {
            InitializeComponent();
            Name0 = name0;
            Name1 = name1;
            isBetaOn = IsBetaOn;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            AppLanguage = appLanguage;
            Spell0 = rb0Result;
            Spell1 = rb1Result;
            ScreenMode = screenMode;
            translation();
            if (saveIsReal == true && enableSave == true)
            {
                ArrIntoInt();
            }
            else
            {
                standartInt();
                setData();
            }
            if(isBetaOn == true)
            {
                CheatCodeLogic();
                ConsoleBtn.Visibility = Visibility.Visible;
            }
        }

        void ArrIntoInt()
        {
            if (File.Exists(SavePath))
            {
                BinaryReader BinaryReader = new BinaryReader(File.OpenRead(SavePath));
                Name0 = BinaryReader.ReadString();
                Name1 = BinaryReader.ReadString();
                MaxHP0 = BinaryReader.ReadInt32();
                MaxHP1 = BinaryReader.ReadInt32();
                HP0 = BinaryReader.ReadInt32();
                HP1 = BinaryReader.ReadInt32();
                AddHP0 = BinaryReader.ReadInt32();
                AddHP1 = BinaryReader.ReadInt32();
                Shield0 = BinaryReader.ReadInt32();
                Shield1 = BinaryReader.ReadInt32();
                Damage0 = BinaryReader.ReadInt32();
                Damage1 = BinaryReader.ReadInt32();
                AdditDamage0 = BinaryReader.ReadInt32();
                AdditDamage1 = BinaryReader.ReadInt32();
                Level0 = BinaryReader.ReadInt32();
                Level1 = BinaryReader.ReadInt32();
                XP0 = BinaryReader.ReadInt32();
                XP1 = BinaryReader.ReadInt32();
                Spell0 = BinaryReader.ReadInt32();
                Spell1 = BinaryReader.ReadInt32();
                Poisoning0 = BinaryReader.ReadInt32();
                Poisoning1 = BinaryReader.ReadInt32();
                Minute = BinaryReader.ReadInt32();
                Second = BinaryReader.ReadInt32();
                BinaryReader.Dispose();
            }
            Name0TB.Text = Name0;
            Name1TB.Text = Name1;
            MinuteTB.Text = Convert.ToString(Minute) + ":";
            SecondsTB.Text = Convert.ToString(Second);
            gameProcess();
        }

        void standartInt()
        {
            MaxHP0 = 100;
            MaxHP1 = 100;
            HP0 = 100;
            HP1 = 100;
            AddHP0 = 10;
            AddHP1 = 10;
            Shield0 = 0;
            Shield1 = 0;
            Damage0 = 10;
            Damage1 = 10;
            AdditDamage0 = 0;
            AdditDamage1 = 0;
            Level0 = 1;
            Level1 = 1;
            XP0 = 0;
            XP1 = 0;
            Poisoning0 = 0;
            Poisoning1 = 0;
            Minute = 0;
            Second = 0;
        }

        async void gameProcess()
        {
            while(playerIsDead == false)
            {
                if (gameIsPaused == false)
                {
                    battleProcess();
                    UISet();
                    deathCheck();
                    Second++;
                    if(Second == 60)
                    {
                        Minute++;
                        Second = 0;
                    }
                    MinuteTB.Text = Convert.ToString(Minute) + ":";
                    SecondsTB.Text = Convert.ToString(Second);
                    gameSave();
                    await Task.Delay(timeSpeed);
                }
                if(gameIsPaused == true)
                {
                    await Task.Delay(100);
                }
                if (gameIsSkiped == true)
                {
                    timeSpeed = 500;
                }
                if (gameIsSkiped == false)
                {
                    timeSpeed = 1000;
                }
                if(playerIsDead == true)
                {
                    UISet();
                    deathCheck();
                    break;
                }
            }
        }

        void setData()
        {
            Name0TB.Text = Name0;
            Name1TB.Text = Name1;
            gameProcess();
        }

        void battleProcess()
        {
            if(Second < 10)
            {
                time = " " + Convert.ToString(Minute) + ":0" + Convert.ToString(Second) + " ";
            }
            else
            {
                time = " " +  Convert.ToString(Minute) + ":" + Convert.ToString(Second) + " ";
            }
            if (Rand.Next(0,2) == 0)
            {
                //игрок 0
                int result = Rand.Next(0, 3);
                if (result == 0)
                {
                    if((Damage0 + AdditDamage0) - Shield1 >= 0)
                    {
                        HP1 -= Damage0 + AdditDamage0;
                        AdditDamage0 = 0;
                    }
                    XP0 += 10;
                    TB0.Text = Name0 + " бьет " + Name1 + time + "\n" + TB0.Text;
                    TB1.Text = "\n" + TB1.Text;
                }
                else if (result == 1)
                {
                    TB0.Text = Name0 + " лечит себя." + time + "\n" + TB0.Text;
                    HP0 += AddHP0;
                    XP0 += 10;
                    TB1.Text = "\n" + TB1.Text;
                }
                else
                {
                    if(Spell0 == 0)
                    {
                        //граната
                        if(Rand.Next(0,2) == 0)
                        {
                            grenadeText2 = "и попадает.";
                            HP1 -= Damage0 * 2;
                            XP0 += 10;
                        }
                        else
                        {
                            grenadeText2 = ", но промахивается.";
                            if(XP0 > 10)
                            {
                                XP0 -= 10;
                            }
                        }
                        TB0.Text = Name0 + " кидает в " + Name1 + " гранату " + grenadeText2 + time + "\n" + TB0.Text;
                        TB1.Text = "\n" + TB1.Text;
                    }
                    else if (Spell0 == 1)
                    {
                        //отравление
                        TB0.Text = Name0 + " использует отравление на 3 секунды." + time + "\n" + TB0.Text;
                        Poisoning1 += 3;
                        XP0 += 10;
                        TB1.Text = "\n" + TB1.Text;
                        player1IsPoisoned = true;
                    }
                    else if (Spell0 == 2)
                    {
                        //реген хп
                        TB0.Text = Name0 + " использует усиленную регенерацию здоровья на себе." + time + "\n" + TB0.Text;
                        HP0 += AddHP0 * 2;
                        XP0 += 10;
                        TB1.Text = "\n" + TB1.Text;
                    }
                    else if (Spell0 == 3)
                    {
                        //усилка урона
                        TB0.Text = Name0 + " использует усиленние урона." + time + "\n" + TB0.Text;
                        AdditDamage0 += Damage0;
                        XP0 += 10;
                        TB1.Text = "\n" + TB1.Text;
                    }
                    else if (Spell0 == 4)
                    {
                        //щит
                        TB0.Text = Name0 + " использует усиленние щита." + time + "\n" + TB0.Text;
                        Shield0 += Damage0;
                        XP0 += 10;
                        TB1.Text = "\n" + TB1.Text;
                    }
                    else if (Spell0 == 5)
                    {
                        //увеличение опыта
                        TB0.Text = Name0 + " использует увеличенние опыта." + time + "\n" + TB0.Text;
                        XP0 += 100;
                        TB1.Text = "\n" + TB1.Text;
                    }
                }
            }
            else
            {
                //игрок 1
                int result = Rand.Next(0, 3);
                if (result == 0)
                {
                    if ((Damage1 + AdditDamage1) - Shield0 >= 0)
                    {
                        HP0 -= Damage1 + AdditDamage1;
                        AdditDamage1 = 0;
                    }
                    XP1 += 10;
                    TB1.Text = time + Name1 + " бьет " + Name0 + "\n" + TB1.Text;
                    TB0.Text = "\n" + TB0.Text;
                }
                else if (result == 1)
                {
                    TB1.Text = time + Name1 + " лечит себя." + "\n" + TB1.Text;
                    HP1 += AddHP1;
                    XP1 += 10;
                    TB0.Text = "\n" + TB0.Text;
                }
                else
                {
                    if (Spell1 == 0)
                    {
                        //граната
                        if (Rand.Next(0, 2) == 0)
                        {
                            if (AppLanguage == "eng")
                            {
                                grenadeText2 = "and hits.";
                            }
                            else if (AppLanguage == "ru")
                            {
                                grenadeText2 = "и попадает.";
                            }
                            XP1 += 10;
                            HP0 -= Damage1 * 2;
                        }
                        else
                        {
                            if (AppLanguage == "eng")
                            {
                                grenadeText2 = ", but misses.";
                            }
                            else if (AppLanguage == "ru")
                            {
                                grenadeText2 = ", но промахивается.";
                            }
                            if(XP1 > 10)
                            {
                                XP1 -= 10;
                            }
                        }
                        TB1.Text = time + Name1 + " кидает в " + Name0 + " гранату " + grenadeText2 + "\n" + TB1.Text;
                        TB0.Text = "\n" + TB0.Text;
                    }
                    else if (Spell1 == 1)
                    {
                        //отравление
                        TB1.Text = time + Name1 + " использует отравление на 3 секунды." + "\n" + TB1.Text;
                        Poisoning0 += 3;
                        XP1 += 10;
                        TB0.Text = "\n" + TB0.Text;
                        player0IsPoisoned = true;
                    }
                    else if (Spell1 == 2)
                    {
                        //реген хп
                        TB1.Text = time + Name1 + " использует усиленную регенерацию здоровья на себе." + "\n" + TB1.Text;
                        HP1 += AddHP1 * 2;
                        XP1 += 10;
                        TB0.Text = "\n" + TB0.Text;
                    }
                    else if (Spell1 == 3)
                    {
                        //усилка урона
                        TB1.Text = time + Name1 + " использует усиленние урона." + "\n" + TB1.Text;
                        AdditDamage1 += Damage1;
                        XP1 += 10;
                        TB0.Text = "\n" + TB0.Text;
                    }
                    else if (Spell1 == 4)
                    {
                        //щит
                        TB1.Text = time + Name1 + " использует усиленние щита." + "\n" + TB1.Text;
                        Shield1 += Damage1;
                        XP1 += 10;
                        TB0.Text = "\n" + TB0.Text;
                    }
                    else if (Spell1 == 5)
                    {
                        //увеличение опыта
                        TB1.Text = time + Name1 + " использует увеличенние опыта." + "\n" + TB1.Text;
                        XP1 += 100;
                        TB0.Text = "\n" + TB0.Text;
                    }
                }
            }
        }

        void deathCheck()
        {
            if(HP0 > MaxHP0)
            {
                HP0 = MaxHP0;
            }
            if (HP1 > MaxHP1)
            {
                HP1 = MaxHP1;
            }

            if (XP0 >= 100)
            {
                XP0 -= 100;
                Level0++;
                Damage0 += 5;
                MaxHP0 += 50;
                HP0 += 50;
                AddHP0 += 5;
            }
            if (XP1 >= 100)
            {
                XP1 -= 100;
                Level1++;
                Damage1 += 5;
                MaxHP1 += 50;
                HP1 += 50;
                AddHP1 += 5;
            }

            if (player0IsPoisoned == true)
            {
                HP0 -= Damage1;
                Poisoning0 -= 1;
                XP1 += 10;
                if(Poisoning0 == 0)
                {
                    player0IsPoisoned = false;
                }
            }
            if (player1IsPoisoned == true)
            {
                HP1 -= Damage0;
                Poisoning1 -= 1;
                XP0 += 10;
                if (Poisoning1 == 0)
                {
                    player1IsPoisoned = false;
                }
            }

            if (HP0 < 0)
            {
                playerIsDead = true;
                if(AppLanguage == "eng")
                {
                    TB0.Text = "Died." + time + "\n" + TB0.Text;
                    TB1.Text = time + "Win." + "\n" + TB1.Text;
                }
                else if(AppLanguage == "ru")
                {
                    TB0.Text = "Погиб." + time + "\n" + TB0.Text;
                    TB1.Text = time + "Победил." + "\n" + TB1.Text;
                }
            }
            if (HP1 < 0)
            {
                playerIsDead = true;
                if (AppLanguage == "eng")
                {
                    TB0.Text = "Win." + time + "\n" + TB0.Text;
                    TB1.Text = time + "Died." + "\n" + TB1.Text;
                }
                else if (AppLanguage == "ru")
                {
                    TB0.Text = "Победил." + time + "\n" + TB0.Text;
                    TB1.Text = time + "Погиб." + "\n" + TB1.Text;
                }
            }
        }

        void UISet()
        {
            HP0TB.Text = "HP " + HP0 + "/" + MaxHP0;
            HP1TB.Text = "HP " + HP1 + "/" + MaxHP1;
            Lvl0TB.Text = "Lvl " + Level0;
            Lvl1TB.Text = "Lvl " + Level1;
            if(Spell0 == 0)
            {
                if (AppLanguage == "ru")
                {
                    Effect0TB.Text = "Граната";
                }
                else if (AppLanguage == "eng")
                {
                    Effect0TB.Text = "Grenade";
                }
            }
            else if (Spell0 == 1)
            {
                if (AppLanguage == "ru")
                {
                    Effect0TB.Text = "Отравление: " + Poisoning1;
                }
                else if (AppLanguage == "eng")
                {
                    Effect0TB.Text = "Poisoning: " + Poisoning1;
                }
            }
            else if (Spell0 == 2)
            {
                if (AppLanguage == "ru")
                {
                    Effect0TB.Text = "Реген. здоровья.";
                }
                else if (AppLanguage == "eng")
                {
                    Effect0TB.Text = "HP regeneration.";
                }
            }
            else if (Spell0 == 3)
            {
                if (AppLanguage == "ru")
                {
                    Effect0TB.Text = "Доп. урон: " + AdditDamage0;
                }
                else if (AppLanguage == "eng")
                {
                    Effect0TB.Text = "Addit. damage: " + AdditDamage0;
                }
            }
            else if (Spell0 == 4)
            {
                if (AppLanguage == "ru")
                {
                    Effect0TB.Text = "Щит: " + Shield1;
                }
                else if (AppLanguage == "eng")
                {
                    Effect0TB.Text = "Shield: " + Shield1;
                }
            }
            else if (Spell0 == 5)
            {
                if (AppLanguage == "ru")
                {
                    Effect0TB.Text = "Доп. опыт.";
                }
                else if (AppLanguage == "eng")
                {
                    Effect0TB.Text = "Addit. XP.";
                }
            }

            if (Spell1 == 0)
            {
                if (AppLanguage == "ru")
                {
                    Effect1TB.Text = "Граната";
                }
                else if (AppLanguage == "eng")
                {
                    Effect1TB.Text = "Grenade";
                }
            }
            else if (Spell1 == 1)
            {
                if (AppLanguage == "ru")
                {
                    Effect1TB.Text = "Отравление: " + Poisoning0;
                }
                else if (AppLanguage == "eng")
                {
                    Effect1TB.Text = "Poisoning: " + Poisoning0;
                }
            }
            else if (Spell1 == 2)
            {
                if (AppLanguage == "ru")
                {
                    Effect1TB.Text = "Реген. здоровья.";
                }
                else if (AppLanguage == "eng")
                {
                    Effect1TB.Text = "HP regeneration.";
                }
            }
            else if (Spell1 == 3)
            {
                if (AppLanguage == "ru")
                {
                    Effect1TB.Text = "Доп. урон: " + AdditDamage1;
                }
                else if (AppLanguage == "eng")
                {
                    Effect1TB.Text = "Addit. damage: " + AdditDamage1;
                }
            }
            else if (Spell1 == 4)
            {
                if (AppLanguage == "ru")
                {
                    Effect1TB.Text = "Щит: " + Shield1;
                }
                else if (AppLanguage == "eng")
                {
                    Effect1TB.Text = "Shield: " + Shield1;
                }
            }
            else if (Spell1 == 5)
            {
                if (AppLanguage == "ru")
                {
                    Effect1TB.Text = "Доп. опыт.";
                }
                else if (AppLanguage == "eng")
                {
                    Effect1TB.Text = "Addit. XP.";
                }
            }
        }

        void gameSave()
        {
            File.Delete(SavePath);
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(SavePath, FileMode.Create));
            binaryWriter.Write(Name0);
            binaryWriter.Write(Name1);
            binaryWriter.Write(MaxHP0);
            binaryWriter.Write(MaxHP1);
            binaryWriter.Write(HP0);
            binaryWriter.Write(HP1);
            binaryWriter.Write(AddHP0);
            binaryWriter.Write(AddHP1);
            binaryWriter.Write(Shield0);
            binaryWriter.Write(Shield1);
            binaryWriter.Write(Damage0);
            binaryWriter.Write(Damage1);
            binaryWriter.Write(AdditDamage0);
            binaryWriter.Write(AdditDamage1);
            binaryWriter.Write(Level0);
            binaryWriter.Write(Level1);
            binaryWriter.Write(XP0);
            binaryWriter.Write(XP1);
            binaryWriter.Write(Spell0);
            binaryWriter.Write(Spell1);
            binaryWriter.Write(Poisoning0);
            binaryWriter.Write(Poisoning1);
            binaryWriter.Write(Minute);
            binaryWriter.Write(Second);
            binaryWriter.Dispose();
        }
        void translation()
        {
            if(AppLanguage == "ru")
            {
                homeBtn.Content = "Домой";
                pauseBtn.Content = "Пауза";
                restartBtn.Content = "Перезапуск";
                skipBtn.Content = "Пропустить";
            }
            else if (AppLanguage == "eng")
            {
                homeBtn.Content = "Home";
                pauseBtn.Content = "Pause";
                restartBtn.Content = "Restart";
                skipBtn.Content = "Skip";
            }
        }
    }
}
