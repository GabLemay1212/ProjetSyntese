using ProjetSyntese.BLL.Model;
using Newtonsoft.Json;
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
using ProjetSyntese.DAL.ApiServices;
using ProjetSyntese.DAL;
using System.Reflection;
using System;

namespace ProjetSyntese
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private readonly HypixelApiService _hypixelApiService;
        private readonly MojangApiService _mojangApiService;
        public MainWindow()
        {
            InitializeComponent();
            _hypixelApiService = new HypixelApiService();
            _mojangApiService = new MojangApiService();
        }
        private async void hypixelApiClick(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string Name = Username.Text;
                string apiKey = "61304290-6e77-44d4-921c-1f0301c7ca24";
                string jsonResponse = await _mojangApiService.GetUUIDFromName(Name); ;
                dynamic responseObject = JsonConvert.DeserializeObject(jsonResponse);
                string uuid = responseObject.id;
                string jsonResponseHypixel = await _hypixelApiService.GetSkyblockProfile(apiKey, uuid);
                dynamic responseObjectHypixel = JsonConvert.DeserializeObject(jsonResponseHypixel);
                int profileCount = responseObjectHypixel.profiles.Count;

                for (int i = 0; i < profileCount; i++)
                {
                    ColumnDefinition column = new ColumnDefinition();
                    GridProfile.ColumnDefinitions.Add(column);
                    Button button = new Button();
                    Grid.SetColumn(button, i); 
                    GridProfile.Children.Add(button);
                    button.Content = responseObjectHypixel.profiles[i].cute_name;
                    int profileId = i;
                    button.Click += (sender, e) => Profile_Click(sender, e, profileId, jsonResponseHypixel);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
                
            }
        }
        private async void mojangApiClick(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string Name = Username.Text;
                string jsonResponse = await _mojangApiService.GetUUIDFromName(Name);

                dynamic responseObject = JsonConvert.DeserializeObject(jsonResponse);
                string uuid = responseObject.id;
                // Process the jsonResponse as needed
                MessageBox.Show("Data fetched successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");

            }
        }
        private async void Button_Click(object sender, RoutedEventArgs e) 
        { 
            StatsMenu statsMenu = new StatsMenu(1);
            statsMenu.Show();
            this.Close();
        }
        private async void Profile_Click(object sender, RoutedEventArgs e, int profileId,string jsonResponseHypixel)
        {
            

            using (var context = new AppDbContext())
            {
                // Create a new Player object
                string Name = Username.Text;
                string apiKey = "61304290-6e77-44d4-921c-1f0301c7ca24";
                string jsonResponse = await _mojangApiService.GetUUIDFromName(Name); ;
                dynamic responseObject = JsonConvert.DeserializeObject(jsonResponse);
                string uuid = responseObject.id;
                dynamic responseObjectHypixel = JsonConvert.DeserializeObject(jsonResponseHypixel);
                
                
                var member = responseObjectHypixel.profiles[profileId].members[uuid];

               
                var player = new Player
                {
                    Fishing = member?.experience_skill_fishing ?? 0,
                    Carpentry = member?.experience_skill_carpentry ?? 0,
                    Combat = member?.experience_skill_combat ?? 0,
                    Enchanting = member?.experience_skill_enchanting ?? 0,
                    Farming = member?.experience_skill_farming ?? 0,
                    Taming = member?.experience_skill_taming ?? 0,
                    Alchemy = member?.experience_skill_alchemy ?? 0,
                    Mining = member?.experience_skill_mining ?? 0,
                    Social = member?.experience_skill_social2 ?? 0,
                    SkyblockLevel = member?.leveling?.experience ?? 0,
                    Username = Name, 
                    CuteName = responseObjectHypixel.profiles[profileId].cute_name

                };
               

                context.Players.Add(player);
                context.SaveChanges();
                
                StatsMenu statsMenu = new StatsMenu(player.PlayerID);
                statsMenu.Show();
                this.Close();

            }


            // Process the jsonResponse as needed
            MessageBox.Show("Data fetched successfully!");

        }
    }
}