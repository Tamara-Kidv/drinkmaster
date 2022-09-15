using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.Model
{
    public class Appcolours
    {

        private static List<Color> _randomColorList = new List<Color>()
        {
            Colors.Orange,
            Colors.Yellow,
            Colors.Violet,
            Colors.Green,
            Colors.Honeydew,
            Colors.Magenta,
            Colors.Blue
        };

        public static Color GetRandomColor()
        {
            return _randomColorList[new Random().Next(_randomColorList.Count)];
        }
    }
}
