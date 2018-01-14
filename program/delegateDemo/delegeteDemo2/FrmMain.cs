using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delegeteDemo2
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            FrmChild1 frm1 = new FrmChild1();
            FrmChild2 frm2 = new FrmChild2();
            FrmChild3 frm3 = new FrmChild3();

            frm1.Show();
            frm2.Show();
            frm3.Show();

            //可以使用+=，把三个委托都关联，与函数指针不一样
            sho += frm1.showCnt;
            sho += frm2.showCnt;
            sho += frm3.showCnt;
        }


        showCntDelegate sho;

        private int cnt = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            cnt++;
            this.sho.Invoke(cnt.ToString()); //可以通过invoke方法，通知所有关联的方法         
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cnt = 0;
            this.sho.Invoke(cnt.ToString());
        }

    }

    public delegate void showCntDelegate(string cnt);
}
