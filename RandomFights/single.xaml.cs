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
        string language, Name0, Name1;
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
            playerIsDead = true;
            if(File.Exists(savePath))
            {
                File.Delete(savePath);
            }
            standartInt();
            playerIsDead = false;
            setData();
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(language, GameData, Name0, Name1, saveIsReal, enableSave);
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

        public single(string language, int[] gameData, string name0, string name1, bool SaveIsReal, bool EnableSave)
        {
            InitializeComponent();
            GameData = gameData;
            Name0 = name0;
            Name1 = name1;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
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
            spell0 = 0;
            spell1 = 0;
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

        async void setData()
        {
            second = 30;
            TB0.Text = "Введите ник:";
            TB1.Text = "Введите ник:";
            Input0.Text = "";
            Input1.Text = "";
            Input0.Visibility = Visibility.Visible;
            Input1.Visibility = Visibility.Visible;
            while (playerIsDead == false)
            {
                if (gameIsPaused == false)
                {
                    second--;
                    if(second == 0)
                    {
                        if(Input0.Text != "" && Input1.Text != "")
                        {
                            Name0 = Input0.Text;
                            Name1 = Input1.Text;
                            Input0.Text = "";
                            Input1.Text = "";
                        }
                        else if ((Input0.Text == "") || (Input1.Text == ""))
                        {
                            Name0 = "Player0";
                            Name1 = "Player1";
                            Input0.Text = "";
                            Input1.Text = "";
                        }
                        break;
                    }
                    SecondsTB.Text = Convert.ToString(second);
                    await Task.Delay(timeSpeed);
                }
                if (gameIsPaused == true)
                {
                    await Task.Delay(100);
                }
                if (gameIsSkiped == true)
                {
                    second = 1;
                    gameIsSkiped = false;
                }
                if (playerIsDead == true)
                {
                    break;
                }
            }
            Name0TB.Text = Name0;
            Name1TB.Text = Name1;
            second = 30;
            TB0.Text = "0. Граната, 1. Отравление, 2. Доп. реген хп, 3. Усиление урона, 4 Щит , 5. Повышение опыта. \nВведите способность:";
            TB1.Text = "0. Граната, 1. Отравление, 2. Доп. реген хп, 3. Усиление урона, 4 Щит , 5. Повышение опыта. \nВведите способность:";
            while (playerIsDead == false)
            {
                if (gameIsPaused == false)
                {
                    second--;
                    if (second == 0)
                    {
                        if (Input0.Text != "" && Input1.Text != "")
                        {
                            spell0 = Convert.ToInt32(Input0.Text);
                            spell1 = Convert.ToInt32(Input1.Text);
                            Input0.Text = "";
                            Input1.Text = "";
                        }
                        else if (Input0.Text == "" || Input1.Text == "")
                        {
                            spell0 = Rand.Next(0, 6);
                            spell1 = Rand.Next(0, 6);
                            Input0.Text = "";
                            Input1.Text = "";
                        }
                        break;
                    }
                    SecondsTB.Text = Convert.ToString(second);
                    await Task.Delay(timeSpeed);
                }
                if (gameIsPaused == true)
                {
                    await Task.Delay(100);
                }
                if (gameIsSkiped == true)
                {
                    second = 1;
                    gameIsSkiped = false;
                }
                if (playerIsDead == true)
                {
                    break;
                }
            }
            TB0.Text = "";
            TB1.Text = "";
            Input0.Text = "";
            Input1.Text = "";
            Input0.Visibility = Visibility.Hidden;
            Input1.Visibility = Visibility.Hidden;
            second = 0;
            gameProcess();
        }

        void battleProcess()
        {
            if(Rand.Next(0,2) == 0)
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
                    TB0.Text = Name0 + " бьет " + Name1;
                    TB1.Text = "";
                }
                else if (result == 1)
                {
                    TB0.Text = Name0 + " лечит себя.";
                    hp0 += ahp0;
                    xp0 += 10;
                    TB1.Text = "";
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
                        TB0.Text = Name0 + " кидает в " + Name1 + " гранату " + grenadeText2;
                        TB1.Text = "";
                    }
                    else if (spell0 == 1)
                    {
                        //отравление
                        TB0.Text = Name0 + " использует отравление на 3 секунды.";
                        poison1 += 3;
                        xp0 += 10;
                        TB1.Text = "";
                        player1IsPoisoned = true;
                    }
                    else if (spell0 == 2)
                    {
                        //реген хп
                        TB0.Text = Name0 + " использует усиленную регенерацию здоровья на себе.";
                        hp0 += ahp0 * 2;
                        xp0 += 10;
                        TB1.Text = "";
                    }
                    else if (spell0 == 3)
                    {
                        //усилка урона
                        TB0.Text = Name0 + " использует усиленние урона.";
                        ddam0 += dam0;
                        xp0 += 10;
                        TB1.Text = "";
                    }
                    else if (spell0 == 4)
                    {
                        //щит
                        TB0.Text = Name0 + " использует усиленние щита.";
                        shield0 += dam0;
                        xp0 += 10;
                        TB1.Text = "";
                    }
                    else if (spell0 == 5)
                    {
                        //увеличение опыта
                        TB0.Text = Name0 + " использует увеличенние опыта.";
                        xp0 += 100;
                        TB1.Text = "";
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
                    TB1.Text = Name1 + " бьет " + Name0;
                    TB0.Text = "";
                }
                else if (result == 1)
                {
                    TB1.Text = Name1 + " лечит себя.";
                    hp1 += ahp1;
                    xp1 += 10;
                    TB0.Text = "";
                }
                else
                {
                    if (spell1 == 0)
                    {
                        //граната
                        if (Rand.Next(0, 2) == 0)
                        {
                            if (language == "eng")
                            {
                                grenadeText2 = "and hits.";
                            }
                            else if (language == "ru")
                            {
                                grenadeText2 = "и попадает.";
                            }
                            xp1 += 10;
                            hp0 -= dam1 * 2;
                        }
                        else
                        {
                            if (language == "eng")
                            {
                                grenadeText2 = ", but misses.";
                            }
                            else if (language == "ru")
                            {
                                grenadeText2 = ", но промахивается.";
                            }
                            if(xp1 > 10)
                            {
                                xp1 -= 10;
                            }
                        }
                        TB1.Text = Name1 + " кидает в " + Name0 + " гранату " + grenadeText2;
                        TB0.Text = "";
                    }
                    else if (spell1 == 1)
                    {
                        //отравление
                        TB1.Text = Name1 + " использует отравление на 3 секунды.";
                        poison0 += 3;
                        xp1 += 10;
                        TB0.Text = "";
                        player0IsPoisoned = true;
                    }
                    else if (spell1 == 2)
                    {
                        //реген хп
                        TB1.Text = Name1 + " использует усиленную регенерацию здоровья на себе.";
                        hp1 += ahp1 * 2;
                        xp1 += 10;
                        TB0.Text = "";
                    }
                    else if (spell1 == 3)
                    {
                        //усилка урона
                        TB1.Text = Name1 + " использует усиленние урона.";
                        ddam1 += dam1;
                        xp1 += 10;
                        TB0.Text = "";
                    }
                    else if (spell1 == 4)
                    {
                        //щит
                        TB1.Text = Name1 + " использует усиленние щита.";
                        shield1 += dam1;
                        xp1 += 10;
                        TB0.Text = "";
                    }
                    else if (spell1 == 5)
                    {
                        //увеличение опыта
                        TB1.Text = Name1 + " использует увеличенние опыта.";
                        xp1 += 100;
                        TB0.Text = "";
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
                if(language == "eng")
                {
                    TB0.Text = "Died.";
                    TB1.Text = "Win.";
                }
                else if(language == "ru")
                {
                    TB0.Text = "Погиб.";
                    TB1.Text = "Победил.";
                }
            }
            if (hp1 < 0)
            {
                playerIsDead = true;
                if (language == "eng")
                {
                    TB0.Text = "Win.";
                    TB1.Text = "Died.";
                }
                else if (language == "ru")
                {
                    TB0.Text = "Победил.";
                    TB1.Text = "Погиб.";
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
                Effect0TB.Text = "Граната";
            }
            else if (spell0 == 1)
            {
                Effect0TB.Text = "Отравление: " + poison1;
            }
            else if (spell0 == 2)
            {
                Effect0TB.Text = "Реген. здоровья.";
            }
            else if (spell0 == 3)
            {
                Effect0TB.Text = "Доп. урон: " + ddam0;
            }
            else if (spell0 == 4)
            {
                Effect0TB.Text = "Щит: " + shield1;
            }
            else if (spell0 == 5)
            {
                Effect0TB.Text = "Доп. опыт.";
            }

            if (spell1 == 0)
            {
                Effect1TB.Text = "Граната";
            }
            else if (spell1 == 1)
            {
                Effect1TB.Text = "Отравление: " + poison0;
            }
            else if (spell1 == 2)
            {
                Effect1TB.Text = "Реген. здоровья.";
            }
            else if (spell1 == 3)
            {
                Effect1TB.Text = "Доп. урон: " + ddam1;
            }
            else if (spell1 == 4)
            {
                Effect1TB.Text = "Щит: " + shield1;
            }
            else if (spell1 == 5)
            {
                Effect1TB.Text = "Доп. опыт.";
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
    }
}
