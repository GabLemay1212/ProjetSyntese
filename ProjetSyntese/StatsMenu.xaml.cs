using ProjetSyntese.BLL.Model;
using ProjetSyntese.DAL;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetSyntese
{
    /// <summary>
    /// Interaction logic for StatsMenu.xaml
    /// </summary>
    public partial class StatsMenu : Window
    {
        public StatsMenu(int Id)
        {

            InitializeComponent();


            using (var context = new AppDbContext())
            {
                
                
                
                var player = context.Players.FirstOrDefault(p => p.PlayerID == Id);

                var player2 = new Player();
                { 
                    float Fishing = player.Fishing;
                    float Carpentry = player.Carpentry;
                    float Combat = player.Combat;
                    float Enchanting = player.Enchanting;
                    float Farming = player.Farming;
                    float Taming = player.Taming;
                    float Alchemy = player.Alchemy;
                    float Mining = player.Mining;
                    float Social = player.Social;
                    float SkyblockLevel = player.SkyblockLevel;
                    string Username = player.Username;
                    string CuteName = player.CuteName;
                }
               
               
                this.DataContext = player;
            }
        }
    }
}
