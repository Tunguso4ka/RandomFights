using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Interaction logic for ControlModeProcessPage.xaml
    /// </summary>
    public partial class ControlModeProcessPage : Page
    {
        bool StartFromSave, IsBetaOn, ConsoleIsOn, IsPaused, IsEnd, ResultFromPlayerRecieved, IsNextTurn = true;
        string Name0, Name1;
        int Spell0, Spell1;
        int HP0, HP1, MaxHP0, MaxHP1, AddHP0, AddHP1;
        int Lvl0, Lvl1, XP0, XP1;
        int Damage0, Damage1, AdditionalDamage0, AdditionalDamage1, Shield0, Shield1, RecievedDamage;
        int Poisoning0, Poisoning1;
        int TimeSpeed = 1000, Second, Minute, TimeForTurn;
        int RandomResult;
        string SavePath = Environment.CurrentDirectory + @"\controlsave.dat";

        Random Rndm = new Random();

        public ControlModeProcessPage(bool startFromSave, bool isBetaOn, string name0, string name1, int spell0, int spell1)
        {
            InitializeComponent();
            StartFromSave = startFromSave;
            IsBetaOn = isBetaOn;
            if (StartFromSave == true)
            {
                ReadSave();
            }
            else
            {
                Name0 = name0;
                Name1 = name1;
                Spell0 = spell0;
                Spell1 = spell1;
                SetStandartParameters();
            }
            SetParametersInUI();
            MainProcess();
        }

        //Game Process Logic
        async void MainProcess()
        {
            while (IsEnd != true)
            {
                if (IsPaused == false)
                {
                    if (IsNextTurn == true)
                    {
                        IsNextTurn = false;
                        if (Rndm.Next(0, 2) == 0)
                        {
                            BorderPlayer00.BorderBrush = Brushes.Red;
                            BorderPlayer01.BorderBrush = Brushes.Red;
                            BorderPlayer02.BorderBrush = Brushes.Red;
                            BorderPlayer10.BorderBrush = Brushes.Transparent;
                            BorderPlayer11.BorderBrush = Brushes.Transparent;
                            AwaitForPlayerTurn0();
                        }
                        else
                        {
                            BorderPlayer00.BorderBrush = Brushes.Transparent;
                            BorderPlayer01.BorderBrush = Brushes.Transparent;
                            BorderPlayer02.BorderBrush = Brushes.Transparent;
                            BorderPlayer10.BorderBrush = Brushes.Red;
                            BorderPlayer11.BorderBrush = Brushes.Red;
                            TurnOfPlayer1();
                        }

                        WriteSave();
                    }

                    //Time system
                    Second++;
                    if (Second == 60)
                    {
                        Second = 0;
                        Minute++;
                    }

                    SetParametersInUI();
                    //await for next turn
                    await Task.Delay(TimeSpeed);
                }
                else
                {
                    //await if game paused
                    await Task.Delay(TimeSpeed / 2);
                }
            }
        }

        async void AwaitForPlayerTurn0()
        {
            BtnsShow();
            TimeForTurn = 5;
            while (TimeForTurn != 0)
            {
                if (ResultFromPlayerRecieved == true)
                {
                    BtnsHide();
                    TurnOfPlayer0();
                    ResultFromPlayerRecieved = false;
                    break;
                }
                TimeForTurn--;
                TimeForTurnOutputTxtBx.Text = TimeForTurn + " secs";
                await Task.Delay(TimeSpeed);
            }
            if (TimeForTurn == 0)
            {
                BtnsHide();
                IsNextTurn = true;
            }
        }

        void TurnOfPlayer0()
        {
            if (RandomResult == 0)
            {
                RecievedDamage = ((Damage0 + AdditionalDamage0) - Shield1);
                if(RecievedDamage < 0)
                {
                    RecievedDamage = 0;
                }

                HP1 -= RecievedDamage;

                AdditionalDamage0 = 0;
                Shield1 = 0;

                OutputTxtBx0.Text = Name0 + " hit " + Name1 + " - " + MinuteTB.Text + ":" + SecondsTB.Text + ".\n" + OutputTxtBx0.Text;
                OutputTxtBx1.Text = "\n" + OutputTxtBx1.Text;
            }
            else if (RandomResult == 1)
            {
                //Heal
                HP0 += AddHP0;
                OutputTxtBx0.Text = Name0 + " heal himself" + " - " + MinuteTB.Text + ":" + SecondsTB.Text + ".\n" + OutputTxtBx0.Text;
                OutputTxtBx1.Text = "\n" + OutputTxtBx1.Text;
            }
            else
            {
                //Spell
                if (Spell0 == 0)
                {
                    //Grenade
                    HP1 -= 20;
                    OutputTxtBx0.Text = Name0 + " throw grenade in " + Name1 + " - " + MinuteTB.Text + ":" + SecondsTB.Text + ".\n" + OutputTxtBx0.Text;
                    OutputTxtBx1.Text = "\n" + OutputTxtBx1.Text;
                }
                else if (Spell0 == 1)
                {
                    //Poison
                    Poisoning1 += 5;
                    OutputTxtBx0.Text = Name0 + " poison" + " - " + MinuteTB.Text + ":" + SecondsTB.Text + ".\n" + OutputTxtBx0.Text;
                    OutputTxtBx1.Text = "\n" + OutputTxtBx1.Text;
                }
                else if (Spell0 == 2)
                {
                    //Super HP Regen
                    HP0 += (AddHP0 * 2);
                    OutputTxtBx0.Text = Name0 + " heal himself" + " - " + MinuteTB.Text + ":" + SecondsTB.Text + ".\n" + OutputTxtBx0.Text;
                    OutputTxtBx1.Text = "\n" + OutputTxtBx1.Text;
                }
                else if (Spell0 == 3)
                {
                    //Additional damage
                    AdditionalDamage0 += 5;
                    OutputTxtBx0.Text = Name0 + " improve additional damage" + " - " + MinuteTB.Text + ":" + SecondsTB.Text + ".\n" + OutputTxtBx0.Text;
                    OutputTxtBx1.Text = "\n" + OutputTxtBx1.Text;
                }
                else if (Spell0 == 4)
                {
                    //Shield
                    Shield0 += 5;
                    OutputTxtBx0.Text = Name0 + " improve shield HP" + " - " + MinuteTB.Text + ":" + SecondsTB.Text + ".\n" + OutputTxtBx0.Text;
                    OutputTxtBx1.Text = "\n" + OutputTxtBx1.Text;
                }
                else if (Spell0 == 5)
                {
                    //XP Power up
                    XP0 += 20;
                    OutputTxtBx0.Text = Name0 + " get 20 XP" + " - " + MinuteTB.Text + ":" + SecondsTB.Text + ".\n" + OutputTxtBx0.Text;
                    OutputTxtBx1.Text = "\n" + OutputTxtBx1.Text;
                }
            }
            IsNextTurn = true;
        }

        void TurnOfPlayer1()
        {
            RandomResult = Rndm.Next(0, 3);
            if (RandomResult == 0)
            {
                RecievedDamage = ((Damage1 + AdditionalDamage1) - Shield0);
                if (RecievedDamage < 0)
                {
                    RecievedDamage = 0;
                }

                HP0 -= RecievedDamage;

                AdditionalDamage1 = 0;
                Shield0 = 0;

                OutputTxtBx1.Text = MinuteTB.Text + ":" + SecondsTB.Text + " - " + Name1 + " hit " + Name0 + ".\n" + OutputTxtBx1.Text;
                OutputTxtBx0.Text = "\n" + OutputTxtBx0.Text;
            }
            else if (RandomResult == 1)
            {
                //Heal
                HP1 += AddHP1;
                OutputTxtBx1.Text = MinuteTB.Text + ":" + SecondsTB.Text + " - " + Name1 + " heal himself" + ".\n" + OutputTxtBx1.Text;
                OutputTxtBx0.Text = "\n" + OutputTxtBx0.Text;
            }
            else
            {
                //Spell
                if (Spell1 == 0)
                {
                    //Grenade
                    HP0 -= 20;
                    OutputTxtBx1.Text = MinuteTB.Text + ":" + SecondsTB.Text + " - " + Name1 + " throw grenade in " + Name0 + ".\n" + OutputTxtBx1.Text;
                    OutputTxtBx0.Text = "\n" + OutputTxtBx0.Text;
                }
                else if (Spell1 == 1)
                {
                    //Poison
                    Poisoning0 += 5;
                    OutputTxtBx1.Text = MinuteTB.Text + ":" + SecondsTB.Text + " - " + Name1 + " poison" + ".\n" + OutputTxtBx1.Text;
                    OutputTxtBx0.Text = "\n" + OutputTxtBx0.Text;
                }
                else if (Spell1 == 2)
                {
                    //Super HP Regen
                    HP1 += (AddHP1 * 2);
                    OutputTxtBx1.Text = MinuteTB.Text + ":" + SecondsTB.Text + " - " + Name1 + " heal himself" + ".\n" + OutputTxtBx1.Text;
                    OutputTxtBx0.Text = "\n" + OutputTxtBx0.Text;
                }
                else if (Spell1 == 3)
                {
                    //Additional damage
                    AdditionalDamage1 += 5;
                    OutputTxtBx1.Text = MinuteTB.Text + ":" + SecondsTB.Text + " - " + Name1 + " improve additional damage" + ".\n" + OutputTxtBx1.Text;
                    OutputTxtBx0.Text = "\n" + OutputTxtBx0.Text;
                }
                else if (Spell1 == 4)
                {
                    //Shield
                    Shield1 += 5;
                    OutputTxtBx1.Text = MinuteTB.Text + ":" + SecondsTB.Text + " - " + Name1 + " improve shield HP" + ".\n" + OutputTxtBx1.Text;
                    OutputTxtBx0.Text = "\n" + OutputTxtBx0.Text;
                }
                else if (Spell1 == 5)
                {
                    //XP Power up
                    XP1 += 20;
                    OutputTxtBx1.Text = MinuteTB.Text + ":" + SecondsTB.Text + " - " + Name1 + " get 20 XP" + ".\n" + OutputTxtBx1.Text;
                    OutputTxtBx0.Text = "\n" + OutputTxtBx0.Text;
                }
            }
            IsNextTurn = true;
        }

        //Btns visibility
        void BtnsShow()
        {
            HitBtn.Visibility = Visibility.Visible;
            HealBtn.Visibility = Visibility.Visible;
            SpellBtn.Visibility = Visibility.Visible;
            TimeForTurnOutputTxtBx.Visibility = Visibility.Visible;
        }

        void BtnsHide()
        {
            HitBtn.Visibility = Visibility.Collapsed;
            HealBtn.Visibility = Visibility.Collapsed;
            SpellBtn.Visibility = Visibility.Collapsed;
            TimeForTurnOutputTxtBx.Visibility = Visibility.Collapsed;
        }

        //Saves System
        void ReadSave()
        {
            BinaryReader SaveBinaryReader = new BinaryReader(File.OpenRead(SavePath));
            //Name
            Name0 = SaveBinaryReader.ReadString();
            Name1 = SaveBinaryReader.ReadString();

            //Spells
            Spell0 = SaveBinaryReader.ReadInt32();
            Spell1 = SaveBinaryReader.ReadInt32();

            //Health
            HP0 = SaveBinaryReader.ReadInt32();
            HP1 = SaveBinaryReader.ReadInt32();
            MaxHP0 = SaveBinaryReader.ReadInt32();
            MaxHP1 = SaveBinaryReader.ReadInt32();
            AddHP0 = SaveBinaryReader.ReadInt32();
            AddHP1 = SaveBinaryReader.ReadInt32();

            //Level
            Lvl0 = SaveBinaryReader.ReadInt32();
            Lvl1 = SaveBinaryReader.ReadInt32();
            XP0 = SaveBinaryReader.ReadInt32();
            XP1 = SaveBinaryReader.ReadInt32();

            //Damage
            Damage0 = SaveBinaryReader.ReadInt32();
            Damage1 = SaveBinaryReader.ReadInt32();
            AdditionalDamage0 = SaveBinaryReader.ReadInt32();
            AdditionalDamage1 = SaveBinaryReader.ReadInt32();
            Shield0 = SaveBinaryReader.ReadInt32();
            Shield1 = SaveBinaryReader.ReadInt32();

            //Special
            Poisoning0 = SaveBinaryReader.ReadInt32();
            Poisoning1 = SaveBinaryReader.ReadInt32();

            //Time
            Second = SaveBinaryReader.ReadInt32();
            Minute = SaveBinaryReader.ReadInt32();

            SaveBinaryReader.Dispose();
        }

        void WriteSave()
        {
            if(File.Exists(SavePath))
            {
                File.Delete(SavePath);
            }

            BinaryWriter SaveBinaryWriter = new BinaryWriter(File.Open(SavePath, FileMode.Create));

            //Name
            SaveBinaryWriter.Write(Name0);
            SaveBinaryWriter.Write(Name1);

            //Spells
            SaveBinaryWriter.Write(Spell0);
            SaveBinaryWriter.Write(Spell1);

            //Health
            SaveBinaryWriter.Write(HP0);
            SaveBinaryWriter.Write(HP1);
            SaveBinaryWriter.Write(MaxHP0);
            SaveBinaryWriter.Write(MaxHP1);
            SaveBinaryWriter.Write(AddHP0);
            SaveBinaryWriter.Write(AddHP1);

            //Level
            SaveBinaryWriter.Write(Lvl0);
            SaveBinaryWriter.Write(Lvl1);
            SaveBinaryWriter.Write(XP0);
            SaveBinaryWriter.Write(XP1);

            //Damage
            SaveBinaryWriter.Write(Damage0);
            SaveBinaryWriter.Write(Damage1);
            SaveBinaryWriter.Write(AdditionalDamage0);
            SaveBinaryWriter.Write(AdditionalDamage1);
            SaveBinaryWriter.Write(Shield0);
            SaveBinaryWriter.Write(Shield1);

            //Special
            SaveBinaryWriter.Write(Poisoning0);
            SaveBinaryWriter.Write(Poisoning1);

            //Time
            SaveBinaryWriter.Write(Second);
            SaveBinaryWriter.Write(Minute);

            SaveBinaryWriter.Dispose();
        }

        //Parameters
        void SetStandartParameters()
        {
            //Health
            HP0 = 100;
            HP1 = 100;
            MaxHP0 = 100;
            MaxHP1 = 100;
            AddHP0 = 10; 
            AddHP1 = 10;

            //Level
            Lvl0 = 1;
            Lvl1 = 1;
            XP0 = 0; 
            XP1 = 0;

            //Damage
            Damage0 = 10;
            Damage1 = 10;
            AdditionalDamage0 = 0;
            AdditionalDamage1 = 0;
            Shield0 = 0;
            Shield1 = 0;

            //Special
            Poisoning0 = 0; 
            Poisoning1 = 0;

            //Time
            Second = 0; 
            Minute = 0;
        }

        void SetParametersInUI()
        {
            //Check
            LvlCheck();
            HPCheck();

            //Names
            Name0TB.Text = Name0;
            Name1TB.Text = Name1;

            //Health
            HP0TB.Text = "HP: " + HP0 + "/" + MaxHP0;
            HP1TB.Text = "HP: " + HP1 + "/" + MaxHP1;

            //Level
            Lvl0TB.Text = "Level: " + Lvl0;
            Lvl1TB.Text = "Level: " + Lvl1;

            //Spells
            if(Spell0 == 0)
            {
                Effect0TB.Text = "Grenade.";
            }
            else if (Spell0 == 1)
            {
                Effect0TB.Text = "Poison: " + Poisoning1;
            }
            else if (Spell0 == 2)
            {
                Effect0TB.Text = "Super HP Regen.";
            }
            else if (Spell0 == 3)
            {
                Effect0TB.Text = "Additional damage: " + AdditionalDamage0;
            }
            else if (Spell0 == 4)
            {
                Effect0TB.Text = "Shield: " + Shield0;
            }
            else if (Spell0 == 5)
            {
                Effect0TB.Text = "XP Power up.";
            }

            if (Spell1 == 0)
            {
                Effect1TB.Text = "Grenade.";
            }
            else if (Spell1 == 1)
            {
                Effect1TB.Text = "Poison: " + Poisoning0;
            }
            else if (Spell1 == 2)
            {
                Effect1TB.Text = "Super HP Regen.";
            }
            else if (Spell1 == 3)
            {
                Effect1TB.Text = "Additional damage: " + AdditionalDamage1;
            }
            else if (Spell1 == 4)
            {
                Effect1TB.Text = "Shield: " + Shield1;
            }
            else if (Spell1 == 5)
            {
                Effect1TB.Text = "XP Power up.";
            }

            //Time
            MinuteTB.Text = Convert.ToString(Minute);
            if(Second < 10)
            {
                SecondsTB.Text = "0" + Second;
            }
            else
            {
                SecondsTB.Text = Convert.ToString(Second);
            }
        }

        void LvlCheck()
        {
            if(XP0 >= 100)
            {
                XP0 -= 100;
                Lvl0++;
                MaxHP0 += 50;
                Damage0 += 5;
                AddHP0 += 5;
            }

            if (XP1 >= 100)
            {
                XP1 -= 100;
                Lvl1++;
                MaxHP1 += 50;
                Damage1 += 5;
                AddHP1 += 5;
            }
        }

        void HPCheck()
        {
            if(HP0 > MaxHP0)
            {
                HP0 = MaxHP0;
            }
            if (HP1 > MaxHP1)
            {
                HP1 = MaxHP1;
            }

            if (HP0 <= 0)
            {
                if (File.Exists(SavePath))
                {
                    File.Delete(SavePath);
                }

                OutputTxtBx1.Text = MinuteTB.Text + ":" + SecondsTB.Text + " - " + Name1 + " win!\n" + OutputTxtBx1.Text;
                OutputTxtBx0.Text = "\n" + OutputTxtBx0.Text;
                IsEnd = true;
            }
            if (HP1 <= 0)
            {
                if (File.Exists(SavePath))
                {
                    File.Delete(SavePath);
                }

                OutputTxtBx0.Text = Name1 + " win!" + MinuteTB.Text + ":" + SecondsTB.Text + " - " + "\n" + OutputTxtBx0.Text;
                OutputTxtBx1.Text = "\n" + OutputTxtBx1.Text;
                IsEnd = true;
            }
        }

        //Btns logic
        private void ConsoleOnBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            if(IsPaused == true)
            {
                PauseBtn.Content = "⏸";
                IsPaused = false;
            }
            else
            {
                PauseBtn.Content = "⏩";
                IsPaused = true;
            }
        }

        private void SpellBtn_Click(object sender, RoutedEventArgs e)
        {
            RandomResult = 2;
            ResultFromPlayerRecieved = true;
        }

        private void HealBtn_Click(object sender, RoutedEventArgs e)
        {
            RandomResult = 1;
            ResultFromPlayerRecieved = true;
        }

        private void HitBtn_Click(object sender, RoutedEventArgs e)
        {
            RandomResult = 0;
            ResultFromPlayerRecieved = true;
        }
    }
}
