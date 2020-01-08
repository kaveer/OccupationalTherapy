using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model.Commun
{
    public static class clsHelper
    {
        public static readonly Color navigationBackground = Color.DeepSkyBlue;
        public static readonly Color formBackground = Color.White;


        /// <summary>
        /// Button configuration
        /// </summary>
        public static readonly Color buttonBackground = Color.LightSkyBlue;
        public static readonly Color hoverBackground = Color.SteelBlue;
        public static readonly Color bottonTextColor = Color.Black;
        public static Color HoverTextColor = Color.White;

        public static Font SetFont(Button item)
        {
            Font result = new Font(item.Font.FontFamily, 12, FontStyle.Bold);

            return result;
        }
    }
}
