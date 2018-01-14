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
    public partial class FrmChild3 : Form
    {
        public FrmChild3()
        {
            InitializeComponent();
        }
        public void showCnt(string cnt)
        {
            this.label1.Text = cnt;
        }
    }
}
