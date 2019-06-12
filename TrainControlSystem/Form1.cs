using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainControlSystem
{
    public partial class Form1 : Form
    {
        public double x = 0, y = 0, t = 0;
        public Form1()
        {
            InitializeComponent();

            chart1.Series[1].Color = Color.Orange;
            chart1.Series[1].BorderWidth = 2;
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[0].BorderWidth = 2;
            
            draw_safe_line();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (x <= 4000)
            {
                y = -1 / 320000.0 * (x - 4000) * (x - 4000) + 200;
                chart1.Series[1].Points.AddXY(x, y);
                x += 100 + 20*t;
                t += 1;
            }
            else if (x > 2000 && x <= 16000)
            {
                t = 0;
                y = 200;
                chart1.Series[1].Points.AddXY(x, 200);
                x += 200;
            }
            else if (x < 20000)
            {
                y = -1 / 80000.0 * (x - 16000) * (x - 16000) + 200;
                chart1.Series[1].Points.AddXY(x, y);
                x += 200 - 5 * t;
                t += 1;
            }
            pictureBox1.Left += (int)(y / 20.0);
        }

        private void draw_safe_line()
        {
            int y = 200;
            int x = 0;
            while(x < 20000)
            {
                if (x < 16000)
                {
                    chart1.Series[0].Points.AddXY(x, y);
                    x += 100;
                }
                else if(x >= 16000)
                {
                    chart1.Series[0].Points.AddXY(x, -1/80000.0*(x-16000)*(x-16000)+200);
                    x += 100;
                }
            }
        }
    }
    
}
