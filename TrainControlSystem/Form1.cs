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
        public int x = 0, y = 0;
        public Form1()
        {
            InitializeComponent();
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[0].BorderWidth = 2;
            chart1.Series[1].Color = Color.Orange;
            chart1.Series[1].BorderWidth = 2;
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
            x += 100;
            y += 1;
            pictureBox1.Left += 4;
            chart1.Series[0].Points.AddXY(x, y);
        }  
    }
    
}
