using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogDemo
{
    class LogHelper
    {
        private static string _path= "E:\\Log";
        private static string _fileName = "logTest.txt";
        private static string _totalName = $"{_path}\\{ _fileName}";
        static public void setPath(string path)
        {
            _path = path;
            _totalName = $"{_path}\\{ _fileName}";
        }

        static public void log(string msg)
        {
            StreamWriter sw = null;
            try
            {
                if(!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);//一次生成多个子文件夹
                }
                sw = File.AppendText(_totalName);//打开文件，并在尾端插入message
                sw.WriteLine($"{DateTime.Now}:{msg}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(sw!=null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }





        }



    }
}
