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

namespace asyncDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action<string> act = doSomeThing;

            {
                Console.WriteLine("------------- 开始同步调用 ----------------");
                act.Invoke("aaa");
                act("ccc");
                Console.WriteLine("------------- 结束同步调用 ----------------\n");
            }


            {

                Console.WriteLine("------------- 开始异步调用 ----------------");
                AsyncCallback callFun = t => { Console.WriteLine($"回调函数 , thread ID =  { Thread.CurrentThread.ManagedThreadId}"); };
                act.BeginInvoke("异步",callFun,null);
                Console.WriteLine("------------- 结束异步调用 ----------------\n");

                Console.WriteLine("------------- 开始异步等待调用 ----------------");               
                IAsyncResult IResult= act.BeginInvoke("异步", callFun, null);
                act.EndInvoke(IResult);
                Console.WriteLine("------------- 结束异步等待调用 ----------------\n");
            }

        }


        private void doSomeThing(string name)
        {
            Console.WriteLine($"begin { name}, thread ID =  { Thread.CurrentThread.ManagedThreadId}");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"end { name}, thread ID =  { Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
