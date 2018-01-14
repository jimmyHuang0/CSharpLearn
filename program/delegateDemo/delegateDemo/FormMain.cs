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
    public partial class FormMain : Form
    {
        /// <summary>
        /// 【5】建立委托关系，也就是把委托指向委托函数。
        /// 通过在被调用方声明一个变量来获取调用方的方法。
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            FormChild child = new FormChild();
          
            child.showcnt = this.show;

            child.Show();

        }

        /// <summary>
        /// 【2】创建被别人调用的方法，也即委托实际调用的方法
        /// 注意参数与委托保持一致
        /// </summary>
        /// <param name="cnt"></param>
        private void show(string cnt)
        {
            this.lbnum.Text = cnt;
        }
    }
    /// <summary>
    /// 【1】在调用方中，声明一个委托，能够让调用方来调用你的方法
    /// </summary>
    /// <param name="cnt"></param>
    public delegate void showCnt(string cnt);
}
