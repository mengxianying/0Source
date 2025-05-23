using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime;
using System.Diagnostics;
using System.Reflection;

namespace qcloudsms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process current = Process.GetCurrentProcess();
            bool newinstance = true;
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            foreach (Process process in processes)
            {
                //忽略现有的例程  
                if (process.Id != current.Id)
                {
                    //确保例程从EXE文件运行  
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //返回另一个例程实例  
                        current = process;
                        newinstance = false;
                        break;
                    }
                }
            }
            if (newinstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("目前已有一个程序在运行，请勿重复运行程序", "提示");
                Application.Exit();
            }

        }
    }
}
