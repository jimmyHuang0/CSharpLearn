using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delegateDemo
{
    public partial class FormChild : Form
    {
        public FormChild()
        {
            InitializeComponent();
        }

        private int cntt = 0;
        /// <summary>
        /// 【3】在调用方中，声明一个委托变量
        /// </summary>
        public showCnt showcnt;
        /// <summary>
        /// 【4】调用委托方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            cntt++;
            if(showcnt!=null)
            {
                showcnt(cntt.ToString());
            }
        }
    }
}
