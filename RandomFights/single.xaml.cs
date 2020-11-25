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
    /// <summary>
    /// Логика взаимодействия для single.xaml
    /// </summary>
    public partial class single : Page
    {
        bool gameIsPaused = false, gameIsSkiped = false, saveIsReal, enableSave, playerIsDead = false, player0IsPoisoned, player1IsPoisoned;
        string Language, Name0, Name1, time;
        int timeSpeed = 1000;
        string savePath = Environment.CurrentDirectory + "/gameSave.dat";
        int[] GameData;
        int maxhp0 , maxhp1, hp0, hp1, ahp0, ahp1, shield0, shield1, dam0, dam1, ddam0, ddam1, lvl0, lvl1, xp0, xp1, spell0, spell1, poison0, poison1, minute, second, ssecond;

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
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new singlesett(Language, GameData, Name0, Name1, saveIsReal, enableSave);
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(Language, GameData, Name0, Name1, saveIsReal, enableSave);
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

        public single(string language, int[] gameData, string name0, string name1, bool SaveIsReal, bool EnableSave, int rb0Result, int rb1Result)
        {
            InitializeComponent();
            GameData = gameData;
            Name0 = name0;
            Name1 = name1;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            Language = language;
            spell0 = rb0Result;
            spell1 = rb1Result;
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
            maxhp0 = GameData[0];
            maxhp1 = GameData[1];
            hp0 = GameData[2];
            hp1 = GameData[3];
            ahp0 = GameData[4];
            ahp1 = GameData[5];
            shield0 = GameData[6];
            shield1 = GameData[7];
            dam0 = GameData[8];
            dam1 = GameData[9];
            ddam0 = GameData[10];
            ddam1 = GameData[11];
            lvl0 = GameData[12];
            lvl1 = GameData[13];
            xp0 = GameData[14];
            xp1 = GameData[15];
            spell0 = GameData[16];
            spell1 = GameData[17];
            poison0 = GameData[18];
            poison1 = GameData[19];
            minute = GameData[20];
            second = GameData[21];
            ssecond = GameData[22];
            gameProcess();
        }

        void standartInt()
        {
            maxhp0 = 100;
            maxhp1 = 100;
            hp0 = 100;
            hp1 = 100;
            ahp0 = 10;
            ahp1 = 10;
            shield0 = 0;
            shield1 = 0;
            dam0 = 10;
            dam1 = 10;
            ddam0 = 0;
            ddam1 = 0;
            lvl0 = 1;
            lvl1 = 1;
            xp0 = 0;
            xp1 = 0;
            poison0 = 0;
            poison1 = 0;
            minute = 0;
            second = 0;
            ssecond = 0;
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
                    second++;
                    if(second == 60)
                    {
                        minute++;
                        second = 0;
                    }
                    MinuteTB.Text = Convert.ToString(minute) + ":";
                    SecondsTB.Text = Convert.ToString(second);
                    ssecond++;
                    if (ssecond == 11)
                    {
                        gameSave();
                        ssecond = 0;
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
            if(second < 10)
            {
                time = " " + Convert.ToString(minute) + ":0" + Convert.ToString(second) + " ";
            }
            else
            {
                time = " " +  Convert.ToString(minute) + ":" + Convert.ToString(second) + " ";
            }
            if (Rand.Next(0,2) == 0)
            {
                //игрок 0
                int result = Rand.Next(0, 3);
                if (result == 0)
                {
                    if((dam0 + ddam0) - shield1 >= 0)
                    {
                        hp1 -= dam0 + ddam0;
                    }
                    xp0 += 10;
                    TB0.Text = Name0 + " бьет " + Name1 + time + "\n" + TB0.Text;
                    TB1.Text = "\n" + TB1.Text;
                }
                else if (result == 1)
                {
                    TB0.Text = Name0 + " лечит себя." + time + "\n" + TB0.Text;
                    hp0 += ahp0;
                    xp0 += 10;
                    TB1.Text = "\n" + TB1.Text;
                }
                else
                {
                    if(spell0 == 0)
                    {
                        //граната
                        if(Rand.Next(0,2) == 0)
                        {
                            grenadeText2 = "и попадает.";
                            hp1 -= dam0 * 2;
                            xp0 += 10;
                        }
                        else
                        {
                            grenadeText2 = ", но промахивается.";
                            if(xp0 > 10)
                            {
                                xp0 -= 10;
                            }
                        }
                        TB0.Text = Name0 + " кидает в " + Name1 + " гранату " + grenadeText2 + time + "\n" + TB0.Text;
                        TB1.Text = "\n" + TB1.Text;
                    }
                    else if (spell0 == 1)
                    {
                        //отравление
                        TB0.Text = Name0 + " использует отравление на 3 секунды." + time + "\n" + TB0.Text;
                        poison1 += 3;
                        xp0 += 10;
                        TB1.Text = "\n" + TB1.Text;
                        player1IsPoisoned = true;
                    }
                    else if (spell0 == 2)
                    {
                        //реген хп
                        TB0.Text = Name0 + " использует усиленную регенерацию здоровья на себе." + time + "\n" + TB0.Text;
                        hp0 += ahp0 * 2;
                        xp0 += 10;
                        TB1.Text = "\n" + TB1.Text;
                    }
                    else if (spell0 == 3)
                    {
                        //усилка урона
                        TB0.Text = Name0 + " использует усиленние урона." + time + "\n" + TB0.Text;
                        ddam0 += dam0;
                        xp0 += 10;
                        TB1.Text = "\n" + TB1.Text;
                    }
                    else if (spell0 == 4)
                    {
                        //щит
                        TB0.Text = Name0 + " использует усиленние щита." + time + "\n" + TB0.Text;
                        shield0 += dam0;
                        xp0 += 10;
                        TB1.Text = "\n" + TB1.Text;
                    }
                    else if (spell0 == 5)
                    {
                        //увеличение опыта
                        TB0.Text = Name0 + " использует увеличенние опыта." + time + "\n" + TB0.Text;
                        xp0 += 100;
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
                    if ((dam1 + ddam1) - shield0 >= 0)
                    {
                        hp0 -= dam1 + ddam1;
                    }
                    xp1 += 10;
                    TB1.Text = time + Name1 + " бьет " + Name0 + "\n" + TB1.Text;
                    TB0.Text = "\n" + TB0.Text;
                }
                else if (result == 1)
                {
                    TB1.Text = time + Name1 + " лечит себя." + "\n" + TB1.Text;
                    hp1 += ahp1;
                    xp1 += 10;
                    TB0.Text = "\n" + TB0.Text;
                }
                else
                {
                    if (spell1 == 0)
                    {
                        //граната
                        if (Rand.Next(0, 2) == 0)
                        {
                            if (Language == "eng")
                            {
                                grenadeText2 = "and hits.";
                            }
                            else if (Language == "ru")
                            {
                                grenadeText2 = "и попадает.";
                            }
                            xp1 += 10;
                            hp0 -= dam1 * 2;
                        }
                        else
                        {
                            if (Language == "eng")
                            {
                                grenadeText2 = ", but misses.";
                            }
                            else if (Language == "ru")
                            {
                                grenadeText2 = ", но промахивается.";
                            }
                            if(xp1 > 10)
                            {
                                xp1 -= 10;
                            }
                        }
                        TB1.Text = time + Name1 + " кидает в " + Name0 + " гранату " + grenadeText2 + "\n" + TB1.Text;
                        TB0.Text = "\n" + TB0.Text;
                    }
                    else if (spell1 == 1)
                    {
                        //отравление
                        TB1.Text = time + Name1 + " использует отравление на 3 секунды." + "\n" + TB1.Text;
                        poison0 += 3;
                        xp1 += 10;
                        TB0.Text = "\n" + TB0.Text;
                        player0IsPoisoned = true;
                    }
                    else if (spell1 == 2)
                    {
                        //реген хп
                        TB1.Text = time + Name1 + " использует усиленную регенерацию здоровья на себе." + "\n" + TB1.Text;
                        hp1 += ahp1 * 2;
                        xp1 += 10;
                        TB0.Text = "\n" + TB0.Text;
                    }
                    else if (spell1 == 3)
                    {
                        //усилка урона
                        TB1.Text = time + Name1 + " использует усиленние урона." + "\n" + TB1.Text;
                        ddam1 += dam1;
                        xp1 += 10;
                        TB0.Text = "\n" + TB0.Text;
                    }
                    else if (spell1 == 4)
                    {
                        //щит
                        TB1.Text = time + Name1 + " использует усиленние щита." + "\n" + TB1.Text;
                        shield1 += dam1;
                        xp1 += 10;
                        TB0.Text = "\n" + TB0.Text;
                    }
                    else if (spell1 == 5)
                    {
                        //увеличение опыта
                        TB1.Text = time + Name1 + " использует увеличенние опыта." + "\n" + TB1.Text;
                        xp1 += 100;
                        TB0.Text = "\n" + TB0.Text;
                    }
                }
            }
        }

        void deathCheck()
        {
            if(hp0 > maxhp0)
            {
                hp0 = maxhp0;
            }
            if (hp1 > maxhp1)
            {
                hp1 = maxhp1;
            }

            if (xp0 >= 100)
            {
                xp0 -= 100;
                lvl0++;
                dam0 += 5;
                maxhp0 += 50;
                hp0 += 50;
                ahp0 += 5;
            }
            if (xp1 >= 100)
            {
                xp1 -= 100;
                lvl1++;
                dam1 += 5;
                maxhp1 += 50;
                hp1 += 50;
                ahp1 += 5;
            }

            if (player0IsPoisoned == true)
            {
                hp0 -= dam1;
                poison0 -= 1;
                xp1 += 10;
                if(poison0 == 0)
                {
                    player0IsPoisoned = false;
                }
            }
            if (player1IsPoisoned == true)
            {
                hp1 -= dam0;
                poison1 -= 1;
                xp0 += 10;
                if (poison1 == 0)
                {
                    player1IsPoisoned = false;
                }
            }

            if (hp0 < 0)
            {
                playerIsDead = true;
                if(Language == "eng")
                {
                    TB0.Text = "Died." + time + "\n" + TB0.Text;
                    TB1.Text = time + "Win." + "\n" + TB1.Text;
                }
                else if(Language == "ru")
                {
                    TB0.Text = "Погиб." + time + "\n" + TB0.Text;
                    TB1.Text = time + "Победил." + "\n" + TB1.Text;
                }
            }
            if (hp1 < 0)
            {
                playerIsDead = true;
                if (Language == "eng")
                {
                    TB0.Text = "Win." + time + "\n" + TB0.Text;
                    TB1.Text = time + "Died." + "\n" + TB1.Text;
                }
                else if (Language == "ru")
                {
                    TB0.Text = "Победил." + time + "\n" + TB0.Text;
                    TB1.Text = time + "Погиб." + "\n" + TB1.Text;
                }
            }
        }

        void UISet()
        {
            HP0TB.Text = "HP " + hp0;
            HP1TB.Text = "HP " + hp1;
            Lvl0TB.Text = "Lvl " + lvl0;
            Lvl1TB.Text = "Lvl " + lvl1;
            if(spell0 == 0)
            {
                if (Language == "ru")
                {
                    Effect0TB.Text = "Граната";
                }
                else if (Language == "eng")
                {
                    Effect0TB.Text = "Grenade";
                }
            }
            else if (spell0 == 1)
            {
                if (Language == "ru")
                {
                    Effect0TB.Text = "Отравление: " + poison1;
                }
                else if (Language == "eng")
                {
                    Effect0TB.Text = "Poisoning: " + poison1;
                }
            }
            else if (spell0 == 2)
            {
                if (Language == "ru")
                {
                    Effect0TB.Text = "Реген. здоровья.";
                }
                else if (Language == "eng")
                {
                    Effect0TB.Text = "HP regeneration.";
                }
            }
            else if (spell0 == 3)
            {
                if (Language == "ru")
                {
                    Effect0TB.Text = "Доп. урон: " + ddam0;
                }
                else if (Language == "eng")
                {
                    Effect0TB.Text = "Addit. damage: " + ddam0;
                }
            }
            else if (spell0 == 4)
            {
                if (Language == "ru")
                {
                    Effect0TB.Text = "Щит: " + shield1;
                }
                else if (Language == "eng")
                {
                    Effect0TB.Text = "Shield: " + shield1;
                }
            }
            else if (spell0 == 5)
            {
                if (Language == "ru")
                {
                    Effect0TB.Text = "Доп. опыт.";
                }
                else if (Language == "eng")
                {
                    Effect0TB.Text = "Addit. XP.";
                }
            }

            if (spell1 == 0)
            {
                if (Language == "ru")
                {
                    Effect1TB.Text = "Граната";
                }
                else if (Language == "eng")
                {
                    Effect1TB.Text = "Grenade";
                }
            }
            else if (spell1 == 1)
            {
                if (Language == "ru")
                {
                    Effect1TB.Text = "Отравление: " + poison0;
                }
                else if (Language == "eng")
                {
                    Effect1TB.Text = "Poisoning: " + poison0;
                }
            }
            else if (spell1 == 2)
            {
                if (Language == "ru")
                {
                    Effect1TB.Text = "Реген. здоровья.";
                }
                else if (Language == "eng")
                {
                    Effect1TB.Text = "HP regeneration.";
                }
            }
            else if (spell1 == 3)
            {
                if (Language == "ru")
                {
                    Effect1TB.Text = "Доп. урон: " + ddam1;
                }
                else if (Language == "eng")
                {
                    Effect1TB.Text = "Addit. damage: " + ddam1;
                }
            }
            else if (spell1 == 4)
            {
                if (Language == "ru")
                {
                    Effect1TB.Text = "Щит: " + shield1;
                }
                else if (Language == "eng")
                {
                    Effect1TB.Text = "Shield: " + shield1;
                }
            }
            else if (spell1 == 5)
            {
                if (Language == "ru")
                {
                    Effect1TB.Text = "Доп. опыт.";
                }
                else if (Language == "eng")
                {
                    Effect1TB.Text = "Addit. XP.";
                }
            }
        }

        void gameSave()
        {
            File.Delete(savePath);
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(savePath, FileMode.Create));
            binaryWriter.Write(Name0);
            binaryWriter.Write(Name1);
            binaryWriter.Write(hp0);
            binaryWriter.Write(hp1);
            binaryWriter.Write(ahp0);
            binaryWriter.Write(ahp1);
            binaryWriter.Write(shield0);
            binaryWriter.Write(shield1);
            binaryWriter.Write(dam0);
            binaryWriter.Write(dam1);
            binaryWriter.Write(ddam0);
            binaryWriter.Write(ddam1);
            binaryWriter.Write(lvl0);
            binaryWriter.Write(lvl1);
            binaryWriter.Write(xp0);
            binaryWriter.Write(xp1);
            binaryWriter.Write(spell0);
            binaryWriter.Write(spell1);
            binaryWriter.Write(poison0);
            binaryWriter.Write(poison1);
            binaryWriter.Write(minute);
            binaryWriter.Write(second);
            binaryWriter.Write(ssecond);
            binaryWriter.Dispose();
        }
        void translation()
        {
            if(Language == "ru")
            {
                homeBtn.Content = "Домой";
                pauseBtn.Content = "Пауза";
                restartBtn.Content = "Перезапуск";
                skipBtn.Content = "Пропустить";
            }
            else if (Language == "eng")
            {
                homeBtn.Content = "Home";
                pauseBtn.Content = "Pause";
                restartBtn.Content = "Restart";
                skipBtn.Content = "Skip";
            }
        }
    }
}
