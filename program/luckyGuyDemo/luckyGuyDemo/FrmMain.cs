using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luckyGuyDemo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        studentList stdList = new studentList();
        int cnt = 50;

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            student std = new student();
            std.name = txtName.Text;
            std.id = txtID.Text;
            stdList.add(std);
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;           
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            student std = stdList.getRanStd();
            txtName.Text = std.name;
            txtID.Text = std.id;
            
            if (cnt / 10 * 10 == cnt)
                LblTime.Text = (cnt / 10).ToString();

            cnt--;

            if (cnt == 0)
            {
                LblTime.Text = (cnt / 10).ToString();
                timer1.Stop();
                cnt = 50;
            }


        }
    }
}
