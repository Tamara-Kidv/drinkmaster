using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.Model
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

}
