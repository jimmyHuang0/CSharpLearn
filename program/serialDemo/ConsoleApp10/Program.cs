using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            ComSerial com = new ComSerial();
            com.Open();
            byte[] data = { 0x01, 0x03, 0x00, 0x01, 0x00, 0x01, 0xD5, 0xCA };
            

            var s= Console.ReadLine();
            while(s!="q")
            {
                com.send(data);
                s = Console.ReadLine();
            }


            com.Close();

            Console.ReadLine();
        }

       
    }

    class ComSerial
    {
        private SerialPort ComDevice = new SerialPort();

        public ComSerial()
        {
            var names= SerialPort.GetPortNames();
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }

            
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }

        public void Open()
        {
            ComDevice.PortName = "COM1";
            ComDevice.BaudRate = 19200;
            ComDevice.Parity = Parity.None;
            ComDevice.DataBits =8;
            ComDevice.StopBits = StopBits.One;
            try
            {
                ComDevice.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "未能成功开启串口");
                return;
            }
        }
        public void Close()
        {
            try
            {
                ComDevice.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "未能成功关闭串口");
                return;
            }
        }

        public bool send(byte[] data)
        {
             if (ComDevice.IsOpen)
             {
                 try
                 {
                    
                     //将消息传递给串口
                     ComDevice.Write(data, 0, data.Length);
                     return true;
                 }
                 catch (Exception ex)
                 {
                    Console.WriteLine(ex.Message, "发送失败");
                 }
             }
             else
             {
                Console.WriteLine("串口未开启", "错误");
             }
             return false;
         }


        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //开辟接收缓冲区
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            //从串口读取数据
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            //实现数据的解码与显示
            AddData(ReDatas);
        }

        public void AddData(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.AppendFormat("{0:x2}" + " ", data[i]);
            }
            AddContent(sb.ToString().ToUpper());
        }

        private void AddContent(string content)
        {
            Console.WriteLine(content);
        }


    }
}
