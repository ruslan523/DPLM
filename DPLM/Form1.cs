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

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen pB = new Pen(Color.Blue, 1);
            Pen pR = new Pen(Color.Red, 3);
            string path = @"data1.txt";
            int counter = 0;
            int[] mass = new int[1000];
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    mass[counter] = Convert.ToInt32(line);
                    counter++;
                }
            }
            for (int i = 0; i < counter; i++)
            {
                label1.Text += " " + Convert.ToString(mass[i]);
                mass[i] = 400 - mass[i] * 100 + 100;
            }
            PointF[] pnts = new PointF[1000];
            for (int i = 0; i < counter; i++)
            {
                pnts[i] = new PointF(2 + i * 10, mass[i]);
            }
            for (int i = 0; i < counter; i++)
            {
                g.DrawEllipse(pR, i * 10, mass[i], 4, 4);
            }
            g.DrawCurve(pB, pnts);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}