using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace RandomFights
{
    /// <summary>
    /// Interaction logic for OnlineFindRoomPage.xaml
    /// </summary>
    public partial class OnlineFindRoomPage : Page
    {
        string AppLanguage;
        bool SaveIsReal, isBetaOn;
        int ScreenMode;
        public OnlineFindRoomPage(string appLanguage, bool saveIsReal, bool IsBetaOn, int screenMode)
        {
            InitializeComponent();
            AppLanguage = appLanguage;
            SaveIsReal = saveIsReal;
            isBetaOn = IsBetaOn;
            ScreenMode = screenMode;
            FindOnlineServers();
            ServersList();
        }

        void FindOnlineServers()
        {

        }

        void ConnectToServer()
        {
            
        }

        private void ServersList()
        {
            List<ServersData> ListWithServersData = new List<ServersData>();
            ListWithServersData.Add(new ServersData() { ThisServerName = "000000", ThisServerPlayerNumber = "0/2", ThisServerLike = "🤍" });
            ServersListView.ItemsSource = ListWithServersData;
        }

        private void SearchStartBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ServerConnectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ServerLikeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class ServersData
    {
        public string ThisServerName { get; set; }
        public string ThisServerPlayerNumber { get; set; }
        public bool ThisServerIsLiked { get; set; }
        public string ThisServerLike { get; set; }
    }

}
