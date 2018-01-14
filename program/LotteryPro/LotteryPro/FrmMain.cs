using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LotteryPro
{
    public partial class FrmMain : Form
    {
     

        #region 初始化
        public FrmMain()
        {
            InitializeComponent();


        }

        #endregion

        #region  拖动窗体的实现

        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        #endregion

        #region 窗体最小化、最大化、关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMax_Click(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Maximized;
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private Seleter seleter = new Seleter();

   
        private void setRanNum()
        {
            List<int> nums = seleter.getRandomNums();
            lblNum1.Text = nums[0].ToString();
            lblNum2.Text = nums[1].ToString();
            lblNum3.Text = nums[2].ToString();
            lblNum4.Text = nums[3].ToString();
            lblNum5.Text = nums[4].ToString();
            lblNum6.Text = nums[5].ToString();
            lblNum7.Text = nums[6].ToString();
        }

        

        //private Thread t;
        //手写号码
        private void btnWriteSelf_Click(object sender, EventArgs e)
        {
            List<int> nums = new List<int>();
            try
            {
                nums.Add(Convert.ToInt32(txtNum1.Text));
                nums.Add(Convert.ToInt32(txtNum2.Text));
                nums.Add(Convert.ToInt32(txtNum3.Text));
                nums.Add(Convert.ToInt32(txtNum4.Text));
                nums.Add(Convert.ToInt32(txtNum5.Text));
                nums.Add(Convert.ToInt32(txtNum6.Text));
                nums.Add(Convert.ToInt32(txtNum7.Text));

                seleter.setListTemp(nums);
                lbNumberList.Items.Add(seleter.getListTempStr());
            }
            catch (Exception )
            {
                MessageBox.Show("num empty");
            }

           

        }

        //启动选号
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
     
        //开始选号
        private void btnSelect_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            lbNumberList.Items.Add(seleter.getListTempStr());
        }

        //生成指定组的号码
        private int times = 0;
        private bool p = false;
        private void btnGroupSelect_Click(object sender, EventArgs e)
        {
            try
            {
                lbNumberList.Items.Clear();
                times = Convert.ToInt32(txtGroup.Text);
                p = true;
                timer1.Start();
                
            }
            catch(Exception)
            {
                MessageBox.Show("enter wrong!!!");
            }
        }

        //删除当前所选
        private void btnDel_Click(object sender, EventArgs e)
        {
            int i = lbNumberList.SelectedIndex;
            if (i < 0) i = 0;
            lbNumberList.Items.RemoveAt(i);
            i--;
            lbNumberList.SelectedIndex = i;
        }
        //清空选号
        private void btnClear_Click(object sender, EventArgs e)
        {
            lbNumberList.Items.Clear();
        }

        //使用小票打印机打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("print OK!!!"); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            setRanNum();                       
            if (times <= 0)
            {
                p = false;
                timer1.Stop();
            }
            times--;
            if (p) lbNumberList.Items.Add(seleter.getListTempStr());
        }
    }
}
