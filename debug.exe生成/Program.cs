using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace debug.exe生成
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "QwQ";
                Console.WriteLine("这个软件可以把文件变成bat，用debug生成");
                Console.Write("请输入文件名称：");
                string file = Console.ReadLine(); //指定文件
                FileStream FileMaxClass = new FileStream(file, FileMode.Open); //fef0 65264
                long tempi = (FileMaxClass.Length / 65264) + 1;
                FileMaxClass.Close();
                string H = char.ConvertFromUtf32(13) + char.ConvertFromUtf32(10); //换行
                BinaryReader binaryReader = new BinaryReader(new FileStream(file, FileMode.Open), Encoding.ASCII); //读取文件

                long COMSize = 0;
                int L = 0;
                string enddel = "";
                StreamWriter bat = new StreamWriter("bin.bat");
                bat.WriteLine("debug<%0");
                string batcopy = "echo y|copy/b ";
                string batdel = "";
                for (int temp2= 0;temp2< tempi; temp2++)
                {
                    batdel += "del/f/q " + (temp2 + 1) + "temp.com & ";
                    batcopy += (temp2 + 1) + "temp.com + ";
                }
                batdel = batdel.Substring(0, batdel.Length - 3);
                batcopy = batcopy.Substring(0, batcopy.Length - 2);
                batcopy += file;
                bat.WriteLine(batcopy);
                bat.WriteLine(batdel);
                bat.WriteLine("exit");
                try
                {
                    long IP = 256;
                    for (int x = 0; ; x++)
                    {
                        string CodeLine = "";
                        for (int i = 0; i < 16; i++)
                        {
                            COMSize++;
                            CodeLine += " " + Convert.ToString(binaryReader.ReadByte(), 16); //每一行的命令
                        }

                        bat.Write("e" + Convert.ToString(IP, 16) + " " + CodeLine + H); //W
                        IP += 16;
                        if (Convert.ToString(IP, 16) == "fff0") //如果达到fff0
                        {
                            L++;
                            enddel += "del /f " + L + "temp.com & ";
                            bat.Write("rcx" + H + Convert.ToString(COMSize, 16) + H + "n" + L + "temp.com" + H + "w" + H); //W
                            IP = 256;
                            COMSize = 0;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
                enddel += "del /f " + (L + 1) + "temp.com";
                bat.Write("rcx" + H + Convert.ToString(COMSize, 16) + H + "n" + (L + 1) + "temp.com" + H + "w" + H + "q" + H); //W
                bat.Close();
            }
            catch (Exception e2)
            {
                //Console.WriteLine(e2.Message);
            }
        }
    }
}