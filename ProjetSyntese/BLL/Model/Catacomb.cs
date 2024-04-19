using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSyntese.BLL.Model
{
    internal class Catacomb
    {
        int CatacombId { get; set; }
        string CuteName { get; set; }
        int PlayerID { get; set; }
        float CatacombLevel { get; set; }
        float HealerLevel { get; set; }
        float TankLevel { get; set; }
        float BerserkerLevel { get; set; }
        float MageLevel { get; set;}
        float ArcherLevel { get;}
    }
}
