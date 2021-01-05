using System;
using System.Windows.Controls;

namespace RandomFights
{
    /// <summary>
    /// Interaction logic for SingleGamePage.xaml
    /// </summary>
    public partial class SingleGamePage : Page
    {
        public SingleGamePage()
        {
            InitializeComponent();
            Player0.Text = "&#128519;";
            Player1.Text = "&#U+1F970;";
        }
    }
}
