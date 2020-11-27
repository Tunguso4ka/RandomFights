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
    /// <summary>
    /// Логика взаимодействия для help.xaml
    /// </summary>
    public partial class help : Page
    {
        string AppLanguage;
        bool saveIsReal, enableSave, isBetaOn;
        public help(string appLanguage, bool SaveIsReal, bool EnableSave, bool IsBetaOn)
        {
            InitializeComponent();
            AppLanguage = appLanguage;
            saveIsReal = SaveIsReal;
            enableSave = EnableSave;
            isBetaOn = IsBetaOn;
            setText();
            translate();
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).frame0.Content = new mainmenu(AppLanguage, saveIsReal, enableSave, isBetaOn);
        }

        void setText()
        {
            if (AppLanguage == "eng")
            {
                TB.Text = "Training (for version 0.6.0.1):\n\n1.User interface. \n1.1.When the application starts, the main menu opens with the buttons \"Single\", \"Online\", \" Settings \", \" Help \", \" Exit \". \n\n1.2. Clicking on \"Single\" opens classic mode. \n1.3. \n1.4. Clicking on \"Settings\" opens settings. \n1 .5.Clicking on \"Help\" opens help. \n1.6.Clicking on \"Exit\" closes the application. \n2.Game. \n2.1 In classic mode, you must first enter names in white boxes Then write the number of one of the spells. \n2.2. Spells are the character's abilities. There are 6 of them in total.Grenade, 1.Poisoning, 2.Additional health regeneration, 3.Additional damage, 4.Shield, 5.Level increase. \n2.3 In classic mode, the one who survives wins. \n2.4 In the game there is a leveling system.Each level adds maximum health, health, damage, and restored health.";
            }
            else if (AppLanguage == "ru")
            {
                TB.Text = "Обучение(на версию 0.6.0.1):\n\n1.Пользовательский интерфейс.\n1.1.При запуске приложения открывается главное меню с кнопками \"Single\", \"Online\', \"Settings\", \"Help\", \"Exit\".\n1.2.При нажатии на \"Single\" открывается классический режим.\n1.3.\n1.4.При нажатии на \"Settings\" открываются настройки.\n1.5.При нажатии на \"Help\" открывается помощь.\n1.6.При нажатии на \"Exit\" приложение закрывается.\n\n2.Игра.\n2.1.В классическом режиме сначала надо ввести в белых прямоугольниках имена.Затем написать номер одного из спелов.\n2.2.Спелы это способности персонажа.Всего их 6. 0.Граната, 1.Отравление, 2.Дополнительная регенерация здоровья, 3.Дополнительный урон, 4.Щит, 5.Повышение уровня.\n2.3.В классическом режиме побеждает тот кто выживет.\n2.4.В игре присутствует система повышения уровня.Каждый уровень прибавляет максимальное здоровье, здоровье, урон, восстановливаемое здоровье.";
            }
            else
            {
                TB.Text = "Ошибка " + AppLanguage;
            }
        }

        void translate()
        {
            if(AppLanguage == "eng")
            {
                homeBtn.Content = "Home.";
            }
            else if(AppLanguage == "ru")
            {
                homeBtn.Content = "Назад.";
            }
        }
    }
}
