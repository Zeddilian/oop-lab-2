using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oop_lab_1.Figures;

namespace oop_lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region Figure & FigureList

        //the main "figure" class, all other classes inherited from it
        public class Figure
        {

            //this method can be overridden in inherited classes. Gets Figure list and data from textbox'es, then returns the points, ready to draw
            public virtual Point[] ReturnPoints(List<string> figarray, int X0, int Y0, int X1, int Y1)
            {
                Point[] points = new Point[2];
                foreach (string s in figarray)
                    if (s == "Lin")
                    {
                        points[0].X = X0;
                        points[0].Y = Y0;
                        points[1].X = X1;
                        points[1].Y = Y1;
                    }
                return points;
            }
        }

        //Contains class objects and redirecting methods
        public class FigureList
        {
            public List<string> figarray = new List<string>();

            //class objects
            public Figure fig1 = new Figure();
            private Figure fig2 = new Square();
            private Figure fig3 = new Figures.Rectangle();
            private Figure fig4 = new Ellipse();
            private Figure fig5 = new Circle();
            private Figure fig6 = new Curve();


            //the method gets data from textbox'es and sends that data to the desired "figure" class (Figure class), then returns the finished figure
            public Point[] GetLine(int X0, int Y0, int X1, int Y1)
            {
                return fig1.ReturnPoints(figarray, X0, Y0, X1, Y1);
            }

            //same, but this method works, if length and width are equal (Square class)
            public System.Drawing.Rectangle GetSquare(int X0, int Y0, int X1, int Y1)
            {
                if (X1 != Y1)
                {
                    MessageBox.Show("not a square");
                    return new System.Drawing.Rectangle(0,0,0,0);
                }
                else
                {
                    Point[] pointsSqu = fig2.ReturnPoints(figarray, X0, Y0, X1, Y1);
                    System.Drawing.Rectangle square = new System.Drawing.Rectangle(pointsSqu[0].X, pointsSqu[0].Y, pointsSqu[1].X, pointsSqu[1].Y);
                    return square;
                }
                  
            }

            //Rectangle class
            public System.Drawing.Rectangle GetRectangle(int X0, int Y0, int X1, int Y1)
            {
                Point[] pointsRec = fig3.ReturnPoints(figarray, X0, Y0, X1, Y1);
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(pointsRec[0].X, pointsRec[0].Y, pointsRec[1].X, pointsRec[1].Y);
                return rectangle;
            }

            //Ellipse class
            public System.Drawing.Rectangle GetEllipse(int X0, int Y0, int X1, int Y1)
            {
                Point[] pointsEll = fig4.ReturnPoints(figarray, X0, Y0, X1, Y1);
                System.Drawing.Rectangle ellipse = new System.Drawing.Rectangle(pointsEll[0].X, pointsEll[0].Y, pointsEll[1].X, pointsEll[1].Y);
                return ellipse;
            }

            //Circle class
            public System.Drawing.Rectangle GetCircle(int X0, int Y0, int X1, int Y1)
            {
                if (X1 != Y1)
                {
                    MessageBox.Show("not a circle");
                    return new System.Drawing.Rectangle(0, 0, 0, 0);
                }
                else
                {
                    Point[] pointsCir = fig5.ReturnPoints(figarray, X0, Y0, X1, Y1);
                    System.Drawing.Rectangle circle = new System.Drawing.Rectangle(pointsCir[0].X, pointsCir[0].Y, pointsCir[1].X, pointsCir[1].Y);
                    return circle;
                }
            }

            //Curve class
            public Point[] GetCurve(int X0, int Y0, int X1, int Y1)
            {
                return fig6.ReturnPoints(figarray, X0, Y0, X1, Y1);
            }
        }
        #endregion

        public FigureList figlist = new FigureList();

        public Bitmap bmp;
        public Graphics grx;

        #region "draw-done" zone

        //the method adds a figure to the FigureList class, and draws the desired figure (Line)
        private void button1_Click(object sender, EventArgs e)
        {
            figlist.figarray.Add("Lin");
            using (grx = Graphics.FromImage(bmp))
            {
                        grx.DrawPolygon(Pens.Black, figlist.GetLine(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox3.Text)));
            }
            pictureBox1.Image = bmp;
        }

        //the method adds a figure to the FigureList class, and draws the desired figure (Rectangle)
        private void button2_Click(object sender, EventArgs e)
        {
            figlist.figarray.Add("Rec");
            using (grx = Graphics.FromImage(bmp))
            {
                    grx.DrawRectangle(Pens.Black, figlist.GetRectangle(Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text)));
            }
            pictureBox1.Image = bmp;
        }

        //the method adds a figure to the FigureList class, and draws the desired figure (Square)
        private void button3_Click(object sender, EventArgs e)
        {
            figlist.figarray.Add("Squ");
            using (grx = Graphics.FromImage(bmp))
            {
                grx.DrawRectangle(Pens.Black, figlist.GetSquare(Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox10.Text), Convert.ToInt32(textBox9.Text)));
            }
            pictureBox1.Image = bmp;
        }

        //the method adds a figure to the FigureList class, and draws the desired figure (Ellipse)
        private void button4_Click(object sender, EventArgs e)
        {
            figlist.figarray.Add("Ell");
            using (grx = Graphics.FromImage(bmp))
            {
                grx.DrawEllipse(Pens.Black, figlist.GetEllipse(Convert.ToInt32(textBox16.Text), Convert.ToInt32(textBox15.Text), Convert.ToInt32(textBox14.Text), Convert.ToInt32(textBox13.Text)));
            }
            pictureBox1.Image = bmp;
        }

        //the method adds a figure to the FigureList class, and draws the desired figure (Circle)
        private void button5_Click(object sender, EventArgs e)
        {
            figlist.figarray.Add("Cir");
            using (grx = Graphics.FromImage(bmp))
            {
                grx.DrawEllipse(Pens.Black, figlist.GetCircle(Convert.ToInt32(textBox20.Text), Convert.ToInt32(textBox19.Text), Convert.ToInt32(textBox18.Text), Convert.ToInt32(textBox17.Text)));
            }
            pictureBox1.Image = bmp;
        }

        //the method adds a figure to the FigureList class, and draws the desired figure (Curve)
        private void button6_Click(object sender, EventArgs e)
        {
            figlist.figarray.Add("Cur");
            using (grx = Graphics.FromImage(bmp))
            {
                grx.DrawCurve(Pens.Black, figlist.GetCurve(Convert.ToInt32(textBox24.Text), Convert.ToInt32(textBox23.Text), Convert.ToInt32(textBox22.Text), Convert.ToInt32(textBox21.Text)));
            }
            pictureBox1.Image = bmp;
        }
        #endregion

        //this method creates a Bitmap image and fills the image with white color, then image assigns the pictureBox. The method works like a "Clear" button
        private void button7_Click(object sender, EventArgs e)
        {
            using (grx = Graphics.FromImage(bmp))
            {
                grx.Clear(Color.White);
            }
            pictureBox1.Image = bmp;
        }

        //this method creates a Bitmap image and fills the image with white color, then image assigns the pictureBox. The method needed to create a start image
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (grx = Graphics.FromImage(bmp))
            {
                grx.Clear(Color.White);
            }
            pictureBox1.Image = bmp;
        }
    }
}
