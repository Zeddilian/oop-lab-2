using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace oop_lab_1.Figures
{
    //inherited class 
    public class Circle : Form1.Figure
    {
        //overridden method. Gets Figure list and data from textbox'es, then returns the points, ready to draw
        public override Point[] ReturnPoints(List<string> figarray, int X0, int Y0, int X1, int Y1)
        {

            Point[] points = new Point[2];
            foreach (string s in figarray)
                if (s == "Cir")
                {
                    points[0].X = X0;
                    points[0].Y = Y0;
                    points[1].X = X1;
                    points[1].Y = Y1;

                }
            return points;
        }
    }
}
