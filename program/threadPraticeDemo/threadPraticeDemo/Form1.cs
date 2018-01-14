using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace threadPraticeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Task task = new Task(() => { });
            task.Start();

            TaskFactory taskFactory = new TaskFactory();

            Console.WriteLine($"主ID：{Thread.CurrentThread.ManagedThreadId.ToString()}");
            
            taskFactory.StartNew(() => 
            {
                Console.WriteLine($"子ID：{Thread.CurrentThread.ManagedThreadId.ToString()}");
                this.Invoke(new Action( ()=> { lblBullBall.Text = Thread.CurrentThread.ManagedThreadId.ToString(); })); 
            });

            Console.WriteLine($"主ID END：{Thread.CurrentThread.ManagedThreadId.ToString()}");
        }
    }
}
