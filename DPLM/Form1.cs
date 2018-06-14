using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPLM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void graph(Pen pB, Pen pR, StreamReader sr)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            int counter = 0;
            int[] mass = new int[1000];
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                mass[counter] = Convert.ToInt32(line);
                counter++;
            }
            for (int i = 0; i < counter; i++)
            {
                label1.Text += " " + Convert.ToString(mass[i]);
                mass[i] = 400 - mass[i] * 10 + 100;
            }
            PointF[] pnts = new PointF[counter];
            for (int i = 0; i < counter; i++)
            {
                pnts[i] = new PointF(50 + 2 + i * 10, mass[i]);
            }
            for (int i = 0; i < counter; i++)
            {
                g.DrawEllipse(pR, 50 + i * 10, mass[i] - 2, 4, 4);
            }
            g.DrawCurve(pB, pnts);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen os = new Pen(Color.DarkGray, 3);
            Pen osm = new Pen(Color.LightGray, 3);
            for (int i = 0; i < 40; i++)
            {
                g.DrawLine(osm, 40, 500 - 10 * i, 50, 500 - 10 * i);
            }
            for (int i = 0; i < 100; i++)
            {
                g.DrawLine(osm, 2 + 50 + 10 * i, 500, 2 + 50 + 10 * i, 510);
            }
            for (int i = 0; i < 40; i++)
            {
                g.DrawLine(osm, 50, 500 - 10 * i, 1050, 500 - 10 * i);
            }
            for (int i = 0; i < 100; i++)
            {
                g.DrawLine(osm, 2 + 50 + 10 * i, 500, 2 + 50 + 10 * i, 100);
            }
            g.DrawLine(os, 50, 500, 1100, 500);
            g.DrawLine(os, 50, 500, 50, 50);
            g.DrawLine(os, 45, 60, 50, 50);
            g.DrawLine(os, 55, 60, 50, 50);
            g.DrawLine(os, 1090, 505, 1100, 500);
            g.DrawLine(os, 1090, 495, 1100, 500);
            Pen[] pB = new Pen[]
            {
                new Pen(Color.DarkBlue, 1),
                new Pen(Color.DarkRed, 1),
                new Pen(Color.DarkOrange, 1),
                new Pen(Color.DarkGreen, 1)
            };
            Pen[] pR = new Pen[]
{
                new Pen(Color.Blue, 1),
                new Pen(Color.Red, 1),
                new Pen(Color.Orange, 1),
                new Pen(Color.Green, 1)
};
            string[] path = new string[]
            {
                @"data1.txt",
                @"data2.txt",
                @"data3.txt",
                @"data4.txt"
            };
            StreamReader[] sr = new StreamReader[]
            {
                new StreamReader(path[0], System.Text.Encoding.Default),
                new StreamReader(path[1], System.Text.Encoding.Default),
                new StreamReader(path[2], System.Text.Encoding.Default),
                new StreamReader(path[3], System.Text.Encoding.Default)
            };
            graph(pB[0], pR[0], sr[0]);
            graph(pB[1], pR[1], sr[1]);
            graph(pB[2], pR[2], sr[2]);
            graph(pB[3], pR[3], sr[3]);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            double pos_X = Cursor.Position.X / 10.0 - 8.6;
            double pos_Y = 65.0 - Cursor.Position.Y / 10.0 - 9.2;
            label2.Text = "X = " + Convert.ToString(pos_X);
            label3.Text = "Y = " + Convert.ToString(pos_Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}