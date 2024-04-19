using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSyntese.BLL.Model
{
    internal class Player
    {
        public int PlayerID { get; set; }
        public string CuteName { get; set; }
        public string Username { get; set; }
        public float SkyblockLevel { get; set; }
        public float Social { get; set; }
        public float Combat { get; set; }
        public float Fishing { get; set; }
        public float Enchanting { get; set; }
        public float Taming { get; set; }
        public float Farming { get; set; }
        public float Carpentry { get; set; }
        public float Alchemy { get; set; }
        public float Mining { get; set; }
    }
}
