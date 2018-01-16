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

namespace taskAsyncDemo_hjm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 实现逻辑：
        ///     task1 -->  task3 --->|
        ///     task2 -------------->|-->task 4
        ///     
        /// 方式一：
        ///     使用task实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask_Click(object sender, EventArgs e)
        {
            TaskFactory taskFactory = new TaskFactory();
            List<Task> list = new List<Task>();

            Task task1 = taskFactory.StartNew(new Action(() => funTask(1)));
            Task task2 = taskFactory.StartNew(new Action(() => funTask(2)));

            task1.Wait();
            Task task3 = taskFactory.StartNew(new Action(() => funTask(3)));

            list.Add(task1);
            list.Add(task2);
            list.Add(task3);
            Task.WaitAll(list.ToArray());
            Task task4 = taskFactory.StartNew(new Action(() => funTask(4)));
        }
        private void funTask(int i)
        {
            try
            {
                Console.WriteLine($"funTask{i} in {DateTime.Now.TimeOfDay.ToString()}");
                switch (i)
                {
                    case 1:
                        Thread.Sleep(int.Parse(tboxTask1Time.Text));
                        break;
                    case 2:
                        Thread.Sleep(int.Parse(tboxTask2Time.Text));
                        break;
                    case 3:
                        Thread.Sleep(int.Parse(tboxTask3Time.Text));
                        break;
                    case 4:
                        Thread.Sleep(int.Parse(tboxTask4Time.Text));
                        break;
                    default:
                        Thread.Sleep(1000);
                        break;
                }
                Console.WriteLine($"funTask{i} out {DateTime.Now.TimeOfDay.ToString()}");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// 实现逻辑：
        ///     task1 -->  task3 --->|
        ///     task2 -------------->|-->task 4
        ///     
        /// 方式一：
        ///     使用task实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAsync_Click(object sender, EventArgs e)
        {
            List<Task> list = new List<Task>();

            list.Add(funAsync(2));
            list.Add(Task.Run(async () =>
            {
                await funAsync(1);
                await funAsync(3);
            }));
            await Task.WhenAll(list.ToArray());
            await funAsync(4);
        }
        async private Task funAsync(int i)
        {
            try
            {
                Console.WriteLine($"funAsync{i} in {DateTime.Now.TimeOfDay.ToString()}");
                switch (i)
                {
                    case 1:
                        await Task.Delay(int.Parse(tboxTask1Time.Text));//没有使用tryParse，因此放到try-catch模块里面
                        break;
                    case 2:
                        await Task.Delay(int.Parse(tboxTask2Time.Text));
                        break;
                    case 3:
                        await Task.Delay(int.Parse(tboxTask3Time.Text));
                        break;
                    case 4:
                        await Task.Delay(int.Parse(tboxTask4Time.Text));
                        break;
                    default:
                        await Task.Delay(1000);
                        break;
                }
                Console.WriteLine($"funAsync{i} out {DateTime.Now.TimeOfDay.ToString()}");
            }
            catch (Exception)
            {

                throw;
            }     
        }
    }
}
