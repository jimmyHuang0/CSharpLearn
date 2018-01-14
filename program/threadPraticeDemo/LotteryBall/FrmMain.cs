using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryBall
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Task task = new Task(()=> 
                {
                   // Random random = new Random();
                    //int ret = random.Next(1, 51);
                    Console.WriteLine(RandomHelper.getRandomNum());
                });
                task.Start();
            }
             




          // RandomHelper.getRandomNum();
        }
    }
}
