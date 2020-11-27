using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
    public partial class single : Page
    {
        bool gameIsPaused = false, gameIsSkiped = false, saveIsReal, enableSave, isBetaOn, playerIsDead = false, player0IsPoisoned, player1IsPoisoned;
        string AppLanguage, Name0, Name1, time;
        int timeSpeed = 1000;
        string SavePath = Environment.CurrentDirectory + "/gameSave.dat";
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
        int Minute, Second, AdditSecond;

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
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new singlesett(AppLanguage, saveIsReal, enableSave, isBetaOn);
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn);
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

        public single(string appLanguage, string name0, string name1, bool SaveIsReal, bool EnableSave, int rb0Result, int rb1Result, bool IsBetaOn)
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
            translation();
            if (saveIsReal == true)
            {
                ArrIntoInt();
            }
            else
            {
                standartInt();
                setData();
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
                AdditSecond = BinaryReader.ReadInt32();
                BinaryReader.Dispose();
            }
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
            AdditSecond = 0;
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
                    AdditSecond++;
                    if (AdditSecond == 11)
                    {
                        gameSave();
                        AdditSecond = 0;
                    }
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
            binaryWriter.Write(AdditSecond);
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
