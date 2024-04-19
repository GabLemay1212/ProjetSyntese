using ProjetSyntese.BLL.Model;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSyntese.DAL
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Test> Tests { get; set; }

        public AppDbContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gable\\source\\repos\\ProjetSyntese\\ProjetSyntese\\DL\\Database.mdf;Integrated Security=True")
        {
            
        }
    }
}
